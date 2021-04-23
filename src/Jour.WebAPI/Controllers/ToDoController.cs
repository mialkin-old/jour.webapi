using System.Collections.Generic;
using System.Threading.Tasks;
using Jour.Database;
using Jour.Database.Dtos;
using Jour.WebAPI.Infrastructure;
using Jour.WebAPI.ViewModels.Plan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jour.WebAPI.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    public class ToDoController : Controller
    {
        private readonly JourContext _context;
        private readonly IDateTime _dateTime;

        public ToDoController(JourContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(ToDoCreateVm model)
        {
            var todo = new ToDo
            {
                Title = model.Title,
                CreatedUtc = _dateTime.UtcNow
            };

            _context.ToDos.Add(todo);
            await _context.SaveChangesAsync();

            return Ok();
        }
        
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            List<ToDo> list = await _context.ToDos.ToListAsync();
            return Json(list);
        }
        
        [HttpPost]
        [Route("complete")]
        public async Task<IActionResult> Complete(int id)
        {
            ToDo toDo = await _context.ToDos.FirstAsync(x => x.ToDoId == id);
            toDo.CompletedUtc = _dateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok();
        }
        
        [HttpPost]
        [Route("uncomplete")]
        public async Task<IActionResult> UnComplete(int id)
        {
            ToDo toDo = await _context.ToDos.FirstAsync(x => x.ToDoId == id);
            toDo.CompletedUtc = null;
            await _context.SaveChangesAsync();

            return Ok();
        }
        
        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            ToDo toDo = await _context.ToDos.FirstAsync(x => x.ToDoId == id);
            _context.ToDos.Remove(toDo);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}