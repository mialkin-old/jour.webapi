using System;
using System.ComponentModel.DataAnnotations;

namespace Jour.Database.Dtos
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }

        [Required]
        public DateTime WorkoutDate { get; set; }
    }
}