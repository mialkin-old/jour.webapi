using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Jour.Database.Dtos
{
    [Index(nameof(Title), IsUnique = true)]
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        
        [Required]
        public int Title { get; set; }
    }
}