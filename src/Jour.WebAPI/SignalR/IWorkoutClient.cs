using System.Threading.Tasks;

namespace Jour.WebAPI.SignalR
{
    public interface IWorkoutClient
    {
        Task UpdateWorkouts(string message);
    }
}