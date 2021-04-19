using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Jour.Database;

namespace Jour.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ExerciseController : Controller
    {
        private readonly JourContext _context;

        public ExerciseController(JourContext context)
        {
            _context = context;
        }

        [Route("list")]
        public async Task<IActionResult> List()
        {
            return Json(null);
        }
    }
}