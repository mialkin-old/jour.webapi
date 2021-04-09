using Jour.Database.Dtos;
using Jour.Database.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jour.Database.Repositories
{
    public class ExerciseKindsRepository : IExerciseKindsRepository
    {
        public Task<IEnumerable<ExerciseKindDto>> ListAsync()
        {
            IEnumerable<ExerciseKindDto> kinds = new List<ExerciseKindDto> { 
                new ExerciseKindDto { Id = 1, Name = "Бег" }, 
                new ExerciseKindDto { Id = 2, Name = "Подтягивания" },
                new ExerciseKindDto { Id = 3, Name = "Отжимания" } 
            };

            return Task.FromResult(kinds);
        }
    }
}
