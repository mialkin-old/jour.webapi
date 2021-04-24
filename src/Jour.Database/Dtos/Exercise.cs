using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Jour.Database.Dtos
{
    [Index(nameof(Title), IsUnique = true)]
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        
        [Required]
        public string Title { get; set; }
    }
}
