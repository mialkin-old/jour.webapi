using System.Collections.Generic;
using System.Threading.Tasks;
using Jour.Database;
using Jour.Database.Dtos;
using Jour.WebAPI.Infrastructure;
using Jour.WebAPI.ViewModels;
using Jour.WebAPI.ViewModels.Goal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jour.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class GoalController : AppController
    {
        private readonly JourContext _context;
        private readonly IDateTime _dateTime;

        public GoalController(JourContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        [Route("list")]
        public async Task<IActionResult> List()
        {
            List<Goal> list = await _context.Goals.ToListAsync();

            return Json(list);
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] GoalCreateVm model)
        {
            var todo = new Goal
            {
                Title = model.Title,
                Created = _dateTime.UtcNow
            };

            _context.Goals.Add(todo);
            await _context.SaveChangesAsync();

            return SuccessResult();
        }
        
        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] IdVm model)
        {
            Goal goal = await _context.Goals.FirstAsync(x => x.GoalId == model.Id);
            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();

            return SuccessResult();
        }
    }
}