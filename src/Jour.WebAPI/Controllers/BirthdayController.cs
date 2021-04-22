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
        private readonly IDateTime _dateTime;

        public BirthdayController(JourContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        [Route("list")]
        public async Task<IActionResult> List()
        {
            List<Birthday> list = await _context.Birthdays.ToListAsync();

            var months = new Months();

            List<BirthdaysInMonthVm> result = list.Select(x => new BirthdayVm
                {
                    BirthdayId = x.BirthdayId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Day = x.DateOfBirth.Day,
                    DayOfYear = x.DateOfBirth.DayOfYear,
                    Month = x.DateOfBirth.Month,
                    Year = x.DateOfBirth.Year,
                    IsActive = IsActive(_dateTime.MoscowTimeNow, x.DateOfBirth)
                })
                .GroupBy(x => x.Month)
                .Select(x => new BirthdaysInMonthVm
                {
                    Month = x.Key,
                    MonthText = months[x.Key],
                    HasActiveBirthdays = x.Any(y => y.IsActive),
                    Birthdays = x.OrderBy(y => y.DayOfYear).ToList()
                })
                .OrderBy(x => x.Month).ToList();

            return Json(result);
        }

        private bool IsActive(DateTime moscowTime, DateTime dateOfBirth)
        {
            if (dateOfBirth.Month == 2 && dateOfBirth.Day == 29)
                return moscowTime <= new DateTime(moscowTime.Year, 3, 2);

            DateTime birthdayMoscow = new DateTime(moscowTime.Year, dateOfBirth.Month, dateOfBirth.Day);
            return moscowTime.DayOfYear <= birthdayMoscow.DayOfYear;
        }
    }
}