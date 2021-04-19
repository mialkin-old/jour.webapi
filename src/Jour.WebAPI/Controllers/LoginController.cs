using Jour.WebAPI.Infrastructure;
using Jour.WebAPI.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jour.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class LoginController : Controller
    {
        private readonly LoginSettings _loginSettings;

        public LoginController(IOptions<LoginSettings> loginSettings)
        {
            _loginSettings = loginSettings.Value;
        }

        [Route("status")]
        [AllowAnonymous]
        public IActionResult Status()
        {
            return Ok(User.Identity.IsAuthenticated);
        }

        [Route("sign-in")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInVm model)
        {
            if (User.Identity.IsAuthenticated)
                return Json(new {success = false, errorMessage = "You are already authenticated!"});

            if (model.Username != _loginSettings.Username || model.Password != _loginSettings.Password)
                return Json(new {success = false, errorMessage = "Invalid credentials!"});

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "admin")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties {IsPersistent = true});

            return Json(new {success = true});
        }

        [Route("sign-out")]
        [HttpPost]
        public new async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }
    }
}