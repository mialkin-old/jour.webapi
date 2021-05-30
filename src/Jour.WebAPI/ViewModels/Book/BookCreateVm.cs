using System.ComponentModel.DataAnnotations;

namespace Jour.WebAPI.ViewModels.Book
{
    public class BookCreateVm
    {
        [Required] 
        [MaxLength(500)]
        public string Title { get; set; }
        
        [Required] 
        [MaxLength(100)]
        public string Author { get; set; }
    }
}