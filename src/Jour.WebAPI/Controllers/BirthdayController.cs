using System;
using System.Collections.Generic;
using System.Linq;
using Jour.Database;
using Jour.Database.Dtos;
using Jour.WebAPI.ViewModels.Birthday;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult List()
        {
            List<Birthday> list = _context.Birthdays.ToList();

            string[] months = new[]
            {
                "n/a", "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь",
                "Ноябрь", "Декабрь"
            };

            var result = list.Select(x => new BirthdayListVm
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
                .Select(x => new
                {
                    month = x.Key,
                    monthText = months[x.Key],
                    hasActive = x.Any(y => y.IsActive),
                    birthdays = x.OrderBy(y => y.DayOfYear)
                })
                .OrderBy(x => x.month);

            return Json(result);
        }
    }
}