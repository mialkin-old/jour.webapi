using System.Collections.Generic;
using System.Threading.Tasks;
using Jour.Database;
using Jour.Database.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jour.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class GoalController : Controller
    {
        private readonly JourContext _context;

        public GoalController(JourContext context)
        {
            _context = context;
        }

        [Route("list")]
        public async Task<IActionResult> List()
        {
            List<Goal> list = await _context.Goals.ToListAsync();

            return Json(list);
        }
    }
}