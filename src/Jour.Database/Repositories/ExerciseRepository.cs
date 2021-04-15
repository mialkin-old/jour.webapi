using Jour.Database.Dtos;
using Jour.Database.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jour.Database.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        public Task<IEnumerable<Exercise>> ListAsync()
        {
            IEnumerable<Exercise> kinds = new List<Exercise> { 
                new Exercise { Id = 1, Name = "Бег" }, 
                new Exercise { Id = 2, Name = "Подтягивания" },
                new Exercise { Id = 3, Name = "Отжимания" } 
            };

            return Task.FromResult(kinds);
        }
    }
}
