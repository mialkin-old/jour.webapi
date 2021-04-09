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
        private readonly IExerciseKindsRepository _exerciseKindsRepository;

        public ExerciseKindController(IExerciseKindsRepository exerciseKindsRepository)
        {
            _exerciseKindsRepository = exerciseKindsRepository;
        }

        [Route("list")]
        public async Task<IActionResult> List()
        {
            IEnumerable<ExerciseKindDto> list = await _exerciseKindsRepository.ListAsync();

            return Json(list);
        }
    }
}
