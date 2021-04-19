using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jour.Database.Dtos
{
    public class Goal
    {
        [Key]
        public int GoalId { get; set; }

        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateCreated { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Deadline { get; set; }
        
        public ICollection<Tag> Tags { get; set; }
    }
}