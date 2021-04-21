using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jour.Database;
using Jour.Database.Dtos;
using Jour.WebAPI.Infrastructure;
using Jour.WebAPI.ViewModels.Birthday;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jour.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class BirthdayController : Controller
    {
        private readonly JourContext _context;

        public BirthdayController(JourContext context)
        {
            _context = context;
        }

        [Route("list")]
        public async Task<IActionResult> List()
        {
            List<Birthday> list = await _context.Birthdays.ToListAsync();

            var months = new Months();
            
            var result = list.Select(x => new BirthdayVm
                {
                    BirthdayId = x.BirthdayId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Day = x.DateOfBirth.Day,
                    DayOfYear = x.DateOfBirth.DayOfYear,
                    Month = x.DateOfBirth.Month,
                    Year = x.DateOfBirth.Year,
                    IsActive = DateTime.UtcNow.AddHours(3).DayOfYear <= x.DateOfBirth.DayOfYear
                })
                .GroupBy(x => x.Month)
                .Select(x => new BirthdayListVm
                {
                    Month = x.Key,
                    MonthText = months[x.Key],
                    HasActiveBirthdays = x.Any(y => y.IsActive),
                    Birthdays = x.OrderBy(y => y.DayOfYear).ToList()
                })
                .OrderBy(x => x.Month);

            return Json(result);
        }
    }
}