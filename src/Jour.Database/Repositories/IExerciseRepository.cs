using System.Collections.Generic;
using System.Threading.Tasks;
using Jour.Database.Dtos;

namespace Jour.Database.Repositories
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAll();
    }
}