using System.Threading.Tasks;

namespace Jour.WebAPI.BackgroundServices.Workout
{
    public interface IWorkoutParser
    {
        ValueTask<WorkoutMessage?> Parse(string message);
    }
}