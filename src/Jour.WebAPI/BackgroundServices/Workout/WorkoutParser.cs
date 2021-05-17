using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Jour.Database.Dtos;
using Jour.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Jour.WebAPI.BackgroundServices.Workout
{
    public class WorkoutParser : IWorkoutParser
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private List<Exercise> _exercises = new();

        public WorkoutParser(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public async ValueTask<WorkoutMessage?> Parse(string message)
        {
            try
            {
                WorkoutMessage? result = JsonSerializer.Deserialize<WorkoutMessage>(message);

                if (result == null)
                    return null;

                if (SearchExercise(result.MessageText) != null)
                    return result;

                await ReloadExercisesFromDb();

                if (SearchExercise(result.MessageText) != null)
                    return result;

                return null;
            }
            catch
            {
                return null;
            }
        }

        private async Task ReloadExercisesFromDb()
        {
            using var scope = _scopeFactory.CreateScope();
            IExerciseRepository exerciseRepository =
                scope.ServiceProvider.GetRequiredService<IExerciseRepository>();

            _exercises = await exerciseRepository.GetAll();
        }

        private Exercise? SearchExercise(string message)
        {
            return  _exercises.FirstOrDefault(s => string.Equals(s.Title, message, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}