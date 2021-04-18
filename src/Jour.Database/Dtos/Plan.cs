using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jour.Database.Dtos
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime DateCreated { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime DateCompleted { get; set; }
        
        public bool IsCompleted { get; set; }
    }
}