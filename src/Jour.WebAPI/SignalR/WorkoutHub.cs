using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Jour.WebAPI.SignalR
{
    public class WorkoutHub : Hub<IWorkoutClient>
    {
        public WorkoutHub()
        {
            
        }
        public Task SendMessage(string user, string message)
        {
            return Task.CompletedTask;
        }
    }
}