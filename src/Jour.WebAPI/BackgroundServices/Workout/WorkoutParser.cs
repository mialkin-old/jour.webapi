using System;
using System.Text.Json;

namespace Jour.WebAPI.BackgroundServices.Workout
{
    public class WorkoutParser : IWorkoutParser
    {
        public bool TryParse(string message, out WorkoutMessage result)
        {
            try
            {
                result = JsonSerializer.Deserialize<WorkoutMessage>(message);
                return true;
            }
            catch (Exception e)
            {
                result = null;
                return false;
            }
        }
    }
}