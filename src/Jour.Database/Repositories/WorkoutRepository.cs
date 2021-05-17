using System.Threading.Tasks;
using Jour.Database.Dtos;

namespace Jour.Database.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly JourContext _context;

        public WorkoutRepository(JourContext context)
        {
            _context = context;
        }
        
        public async Task SaveAsync(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
        }
    }
}