using Jour.Database.Dtos;
using Jour.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jour.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ExerciseKindController : Controller
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseKindController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        [Route("list")]
        public async Task<IActionResult> List()
        {
            IEnumerable<Exercise> list = await _exerciseRepository.ListAsync();

            return Json(list);
        }
    }
}
