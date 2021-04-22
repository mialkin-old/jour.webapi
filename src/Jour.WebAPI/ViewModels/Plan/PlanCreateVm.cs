using System.ComponentModel.DataAnnotations;

namespace Jour.WebAPI.ViewModels.Plan
{
    public class ToDoCreateVm
    {
        [Required] 
        [MaxLength(50)]
        public string Title { get; set; }
    }
}