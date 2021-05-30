using System.Threading.Tasks;
using Jour.Database;
using Jour.Database.Dtos;
using Jour.WebAPI.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jour.WebAPI.Controllers
{
    [Authorize]
    [Microsoft.AspNetCore.Components.Route("api/v1/[controller]")]
    public class BookController : AppController
    {
        private readonly JourContext _context;

        public BookController(JourContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] BookCreateVm model)
        {
            var book = new Book
            {
                Title = model.Title,
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return SuccessResult();
        }
    }
}