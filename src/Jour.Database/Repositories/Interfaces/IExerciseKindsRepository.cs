using Jour.Database.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jour.Database.Repositories.Interfaces
{
    public interface IExerciseKindsRepository
    {
        Task<IEnumerable<ExerciseKindDto>> ListAsync();
    }
}
