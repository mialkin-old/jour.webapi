using System.ComponentModel.DataAnnotations;

namespace Jour.WebAPI.ViewModels.Todo
{
    public class TodoCompleteVm : IdVm
    {
        [Required]
        public TodoDuration Duration { get; set; }
    }
}