using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jour.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class WorkoutController : AppController
    {
        public IActionResult Index()
        {
            return Ok(new {key = "Hello from Jour.WebAPI"});
        }
    }
}