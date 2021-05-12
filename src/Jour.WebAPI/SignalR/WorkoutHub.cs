using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Jour.WebAPI.SignalR
{
    public class WorkoutHub : Hub<IWorkoutClient>
    {
        public Task SendMessage(string user, string message)
        {
            return Clients.All.UpdateWorkouts("Your workout" + DateTime.Now.ToString("O"));
        }
    }
}