using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jour.Database;
using Jour.Database.Dtos;
using Jour.WebAPI.Infrastructure;
using Jour.WebAPI.ViewModels;
using Jour.WebAPI.ViewModels.Tag;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jour.WebAPI.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    public class TagController : AppController
    {
        private readonly JourContext _context;
        private readonly IDateTime _dateTime;

        public TagController(JourContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            List<Tag> list = await _context.Tags.ToListAsync();
            IEnumerable<TagVm> result = list.Select(x => new TagVm {TagId = x.TagId, Title = x.Title});
            
            return Json(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] TagCreateVm model)
        {
            var tag = new Tag
            {
                Title = model.Title,
            };

            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return SuccessResult();
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] IdVm model)
        {
            Tag tag = await _context.Tags.FirstAsync(x => x.TagId == model.Id);
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            return SuccessResult();
        }
    }
}