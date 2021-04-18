using System.ComponentModel.DataAnnotations;

namespace Jour.Database.Dtos
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
