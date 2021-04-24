using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jour.Database;
using Jour.Database.Dtos;
using Jour.WebAPI.Infrastructure;
using Jour.WebAPI.ViewModels;
using Jour.WebAPI.ViewModels.Todo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jour.WebAPI.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    public class TodoController : AppController
    {
        private readonly JourContext _context;
        private readonly IDateTime _dateTime;

        public TodoController(JourContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] TodoCreateVm model)
        {
            var todo = new Todo
            {
                Title = model.Title,
                CreatedUtc = _dateTime.UtcNow
            };

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return SuccessResult();
        }

        [HttpGet]
        [Route("active")]
        public async Task<IActionResult> Active()
        {
            List<Todo> list = await _context.Todos
                .Where(x => x.CompletedUtc == null)
                .OrderByDescending(x => x.CreatedUtc)
                .ToListAsync();
            return Json(list);
        }
        
        [HttpGet]
        [Route("inactive")]
        public async Task<IActionResult> Inactive()
        {
            List<Todo> list = await _context.Todos
                .Where(x => x.CompletedUtc != null)
                .OrderByDescending(x => x.CompletedUtc)
                .ToListAsync();
            return Json(list);
        }

        [HttpPost]
        [Route("complete")]
        public async Task<IActionResult> Complete(int id)
        {
            Todo todo = await _context.Todos.FirstAsync(x => x.ToDoId == id);
            todo.CompletedUtc = _dateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("uncomplete")]
        public async Task<IActionResult> UnComplete(int id)
        {
            Todo todo = await _context.Todos.FirstAsync(x => x.ToDoId == id);
            todo.CompletedUtc = null;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] IdVm model)
        {
            Todo todo = await _context.Todos.FirstAsync(x => x.ToDoId == model.Id);
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return SuccessResult();
        }
    }
}