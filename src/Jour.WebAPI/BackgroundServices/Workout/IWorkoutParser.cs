namespace Jour.WebAPI.BackgroundServices.Workout
{
    public interface IWorkoutParser
    {
        bool TryParse(string message, out WorkoutMessage result);
    }
}