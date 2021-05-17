using System;
using Jour.WebAPI.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Jour.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    //[Authorize]
    public class WorkoutController : AppController
    {
        private readonly IHubContext<WorkoutHub, IWorkoutClient> _hubContext;

        public WorkoutController(IHubContext<WorkoutHub, IWorkoutClient> hubContext)
        {
            _hubContext = hubContext;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            _hubContext.Clients.All.UpdateWorkouts("Your workout" + DateTime.Now.ToString("O"));
            return Ok(new {key = "Hello from Jour.WebAPI"});
        }
    }
}