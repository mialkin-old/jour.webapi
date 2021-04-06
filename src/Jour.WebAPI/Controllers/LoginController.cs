using Jour.WebAPI.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jour.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class LoginController : Controller
    {
        [Route("status")]
        public async Task<IActionResult> Status()
        {
            return Ok(User.Identity.IsAuthenticated);
        }

        [Route("sign-in")]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody]SignInVm model)
        {
            if (User.Identity.IsAuthenticated)
                return Json(new { success = false, errorMessage = "You are already authenticated!" });


            if (model.Username != "a" || model.Password != "a")
                return Json(new { success = false, errorMessage = "Invalid credentials!" });

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, "admin")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties
            {
                IsPersistent = true,
                //ExpiresUtc = DateTime.UtcNow.AddYears(1),
                
            });

            return Json(new { success = true });
        }

        [Route("sign-out")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }
    }
}
