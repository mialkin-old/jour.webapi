using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jour.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class TrainingController : Controller
    {
        public IActionResult Index()
        {
            return Ok(new {key = "Hello from Jour.WebAPI"});
        }
    }
}