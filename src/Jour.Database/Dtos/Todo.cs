using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Jour.Database.Dtos
{
    [Index(nameof(CompletedUtc))]
    public class Todo
    {
        [Key]
        public int TodoId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public DateTime CreatedUtc { get; set; }

        public DateTime? CompletedUtc { get; set; }

        [Range(0, 23)]
        public int Hours { get; set; }

        [Range(0, 59)]
        public int Minutes { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}