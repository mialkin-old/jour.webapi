using System;
using System.ComponentModel.DataAnnotations;

namespace Jour.Database.Dtos
{
    public class Birthday
    {
        [Key]
        public int BirthdayId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}