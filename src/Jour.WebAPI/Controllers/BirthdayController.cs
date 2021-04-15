using System.Collections.Generic;
using System.Linq;
using Jour.Database;
using Jour.Database.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Jour.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class BirthdayController : Controller
    {
        private readonly JourContext _context;

        public BirthdayController(JourContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            List<Birthday> context = _context.Birthdays.ToList();
            
            return Json(context);
        }
    }
}