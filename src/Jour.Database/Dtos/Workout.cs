using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jour.Database.Dtos
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime WorkoutDateUtc { get; set; }
    }
}