using System.Collections.Generic;
using System.Threading.Tasks;
using Jour.Database;
using Jour.Database.Dtos;
using Jour.WebAPI.Infrastructure;
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
            return Json(list);
        }
    }
}