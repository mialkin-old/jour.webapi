using Jour.WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jour.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class LoginController : Controller
    {
        [Route("status")]
        public async Task<IActionResult> Status()
        {
            var isAuthenticated = false;

            return Ok(isAuthenticated);
        }

        public async Task<IActionResult> SignIn()
        {
            return Ok();
        }

        public async Task<IActionResult> SignOut()
        {
            return Ok();
        }
    }
}
