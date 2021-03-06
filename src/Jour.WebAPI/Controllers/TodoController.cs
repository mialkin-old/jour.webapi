using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jour.Database;
using Jour.Database.Dtos;
using Jour.WebAPI.Infrastructure;
using Jour.WebAPI.ViewModels;
using Jour.WebAPI.ViewModels.Tag;
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

            if (model.TagId > 0)
            {
                Tag tag = await _context.Tags.FirstAsync(x => x.TagId == model.TagId);
                todo.Tags = new List<Tag> {tag};
            }

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return SuccessResult();
        }

        [HttpGet]
        [Route("active")]
        public async Task<IActionResult> Active()
        {
            List<Todo> list = await _context.Todos
                .Include(x => x.Tags)
                .Where(x => x.CompletedUtc == null)
                .OrderByDescending(x => x.TodoId)
                .ToListAsync();

            IEnumerable<TodoVm> result = list.Select(x => new TodoVm
            {
                TodoId = x.TodoId,
                Title = x.Title,
                Duration = new TodoDuration {Hours = x.Hours, Minutes = x.Minutes},
                Tags = x.Tags.Select(y => new TagVm {TagId = y.TagId, Title = y.Title}).ToList()
            });

            return Json(result);
        }

        [HttpGet]
        [Route("inactive")]
        public async Task<IActionResult> Inactive()
        {
            List<Todo> list = await _context.Todos
                .Include(x => x.Tags)
                .Where(x => x.CompletedUtc != null)
                .OrderByDescending(x => x.CompletedUtc)
                .ToListAsync();

            IEnumerable<TodoVm> result = list.Select(x => new TodoVm
            {
                TodoId = x.TodoId,
                Title = x.Title,
                Duration = new TodoDuration {Hours = x.Hours, Minutes = x.Minutes},
                Tags = x.Tags.Select(y => new TagVm {TagId = y.TagId, Title = y.Title}).ToList()
            });

            return Json(result);
        }

        [HttpPost]
        [Route("complete")]
        public async Task<IActionResult> Complete([FromBody] TodoCompleteVm model)
        {
            Todo todo = await _context.Todos.FirstAsync(x => x.TodoId == model.Id);
            todo.CompletedUtc = _dateTime.UtcNow;
            todo.Hours = model.Duration.Hours;
            todo.Minutes = model.Duration.Minutes;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("uncomplete")]
        public async Task<IActionResult> UnComplete([FromBody] IdVm model)
        {
            Todo todo = await _context.Todos.FirstAsync(x => x.TodoId == model.Id);
            todo.CompletedUtc = null;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] IdVm model)
        {
            Todo todo = await _context.Todos.FirstAsync(x => x.TodoId == model.Id);
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return SuccessResult();
        }
    }
}