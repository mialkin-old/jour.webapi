using System;
using System.ComponentModel.DataAnnotations;

namespace Jour.WebAPI.ViewModels.Tag
{
    public class TagCreateVm
    {
        [Required] 
        [MaxLength(50)]
        public string Title { get; set; }
    }
}