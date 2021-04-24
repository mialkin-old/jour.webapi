using System.ComponentModel.DataAnnotations;

namespace Jour.WebAPI.ViewModels.Goal
{
    public class GoalCreateVm
    {
        [Required] 
        [MaxLength(50)]
        public string Title { get; set; }
    }
}