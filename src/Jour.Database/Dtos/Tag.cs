using System.Collections.Generic;
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
        public string Title { get; set; }

        public ICollection<Goal> Goals { get; set; }
        public ICollection<Todo> Todos { get; set; }
    }
}