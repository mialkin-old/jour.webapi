using System.Threading.Tasks;
using Jour.Database.Dtos;

namespace Jour.Database.Repositories
{
    public interface IWorkoutRepository
    {
        Task SaveAsync(Workout workout);
    }
}