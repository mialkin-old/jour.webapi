using Microsoft.AspNetCore.Mvc;

namespace Jour.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class WorkoutController : Controller
    {
        public IActionResult Index()
        {
            return Ok(new { key = "Hello from Jour.WebAPI" });
        }
    }
}
