using System.ComponentModel.DataAnnotations;

namespace Jour.WebAPI.ViewModels.Todo
{
    public class TodoCreateVm
    {
        [Required] 
        [MaxLength(50)]
        public string Title { get; set; }
    }
}