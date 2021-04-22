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

        private readonly JourContext _context;

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

            var context = new JourContext(_options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            _context = context;
        }

        public static readonly object[][] ActiveBirthdays =
        {
            new object[] {new DateTime(2010, 1, 10, 20, 30, 0), new DateTime(1990, 10, 9)},
            new object[] {new DateTime(2010, 1, 10), new DateTime(1990, 1, 10)},
            new object[] {new DateTime(2010, 12, 31, 21, 30, 0), new DateTime(1990, 1, 1)},
            new object[] {new DateTime(2010, 2, 27, 21, 30, 0), new DateTime(1992, 2, 29)},
            new object[] {new DateTime(2010, 2, 28), new DateTime(1992, 2, 29)},
            new object[] {new DateTime(2010, 3, 1), new DateTime(1992, 2, 29)},
            new object[] {new DateTime(2020, 2, 29), new DateTime(1992, 2, 29)},
        };

        [Theory, MemberData(nameof(ActiveBirthdays))]
        public async Task List_HasActiveBirthdaysForMoscowTime(DateTime machineUtcDate, DateTime birthdayDate)
        {
            var now = new Mock<IDateTime>();
            now.Setup(x => x.UtcNow).Returns(machineUtcDate);

            _context.Birthdays.Add(new Birthday {DateOfBirth = birthdayDate});
            await _context.SaveChangesAsync();

            BirthdayController controller = new(_context, now.Object);

            JsonResult jsonResult = (JsonResult) await controller.List();
            var result = (List<BirthdaysInMonthVm>) jsonResult.Value;

            Assert.True(result.First().HasActiveBirthdays);
        }

        public static readonly object[][] InactiveBirthdays =
        {
            new object[] {new DateTime(2010, 1, 10, 21, 30, 0), new DateTime(1990, 1, 10)},
            new object[] {new DateTime(2010, 1, 10), new DateTime(1990, 1, 9)},
            new object[] {new DateTime(2010, 12, 31, 20, 30, 0), new DateTime(1990, 1, 1)},
            new object[] {new DateTime(2010, 3, 1, 21, 30, 0), new DateTime(1992, 2, 29)},
        };

        [Theory, MemberData(nameof(InactiveBirthdays))]
        public async Task List_DoesNotHaveActiveBirthdaysForMoscowTime(DateTime machineUtcDate, DateTime birthdayDate)
        {
            var now = new Mock<IDateTime>();
            now.Setup(x => x.UtcNow).Returns(machineUtcDate);

            _context.Birthdays.Add(new Birthday {DateOfBirth = birthdayDate});
            await _context.SaveChangesAsync();

            BirthdayController controller = new(_context, now.Object);

            JsonResult jsonResult = (JsonResult) await controller.List();
            var result = (List<BirthdaysInMonthVm>) jsonResult.Value;

            Assert.False(result.First().HasActiveBirthdays);
        }
    }
}