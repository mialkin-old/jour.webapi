using System.ComponentModel.DataAnnotations;

namespace Jour.WebAPI.ViewModels.Todo
{
    public class TodoDuration
    {
        [Range(0, 23)]
        public int Hours { get; set; }

        [Range(0, 59)]
        public int Minutes { get; set; }
    }
}