using System;
using System.ComponentModel.DataAnnotations;

namespace Jour.WebAPI.ViewModels
{
    public class IdVm
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int Id { get; set; }
    }
}