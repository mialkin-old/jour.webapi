using Jour.WebAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Jour.WebAPI.Controllers
{
    public class AppController : Controller
    {
        public JsonResult SuccessResult()
        {
            return Json(new SuccessResult());
        }
    }
}