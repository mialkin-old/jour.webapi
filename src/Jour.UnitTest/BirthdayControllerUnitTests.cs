using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Jour.Database;
using Jour.Database.Dtos;
using Jour.WebAPI.Controllers;
using Jour.WebAPI.Infrastructure;
using Jour.WebAPI.ViewModels.Birthday;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Jour.UnitTest
{
    public class BirthdayControllerUnitTests
    {
        private readonly DbContextOptions<JourContext> _options;

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        public BirthdayControllerUnitTests()
        {
            _options = new DbContextOptionsBuilder<JourContext>()
                .UseSqlite(CreateInMemoryDatabase())
                .Options;
        }

        [Fact]
        public async Task List_HasActiveBirthdaysForMoscowTime()
        {
            var now = new Mock<IDateTime>();
            now.Setup(x => x.UtcNow).Returns(new DateTime(2021, 4, 15, 21, 30, 0));
            
            using (var context = new JourContextWrapper(_options))
            {
                context.Birthdays.Add(new Birthday {DateOfBirth = new DateTime(1960, 4, 16)});
                await context.SaveChangesAsync();

                BirthdayController controller = new(context, now.Object);

                JsonResult jsonResult = (JsonResult) await controller.List();
                var result = (List<BirthdaysInMonthVm>) jsonResult.Value;

                Assert.True(result.First().HasActiveBirthdays);
            }
        }
        
        [Fact]
        public async Task List_DoesNotHaveActiveBirthdaysForMoscowTime()
        {
            var now = new Mock<IDateTime>();
            now.Setup(x => x.UtcNow).Returns(new DateTime(2021, 4, 16, 21, 30, 0));
            
            using (var context = new JourContextWrapper(_options))
            {
                context.Birthdays.Add(new Birthday {DateOfBirth = new DateTime(1960, 4, 16)});
                await context.SaveChangesAsync();

                BirthdayController controller = new(context, now.Object);

                JsonResult jsonResult = (JsonResult) await controller.List();
                var result = (List<BirthdaysInMonthVm>) jsonResult.Value;

                Assert.False(result.First().HasActiveBirthdays);
            }
        }
    }
}