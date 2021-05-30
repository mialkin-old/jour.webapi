using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jour.Database.Dtos
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Author { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime Created { get; set; }
        
        public ICollection<Tag> Tags { get; set; }
    }
}