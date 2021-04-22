using System.Threading.Tasks;
using Jour.Database;
using Jour.Database.Dtos;
using Jour.WebAPI.Infrastructure;
using Jour.WebAPI.ViewModels.Plan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jour.WebAPI.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Create(ToDoCreateVm model)
        {
            var todo = new ToDo
            {
                Title = model.Title,
                DateCreated = _dateTime.UtcNow
            };

            await _context.ToDos.AddAsync(todo);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}