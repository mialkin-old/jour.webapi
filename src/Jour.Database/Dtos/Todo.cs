using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Jour.Database.Dtos
{
    [Index(nameof(CompletedUtc))]
    public class Todo
    {
        [Key]
        public int ToDoId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        
        public DateTime CreatedUtc { get; set; }
        
        public DateTime? CompletedUtc { get; set; }
    }
}