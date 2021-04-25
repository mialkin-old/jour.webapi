using System.Collections.Generic;
using Jour.WebAPI.ViewModels.Tag;

namespace Jour.WebAPI.ViewModels.Todo
{
    public class TodoVm
    {
        public int TodoId { get; set; }
        public string Title { get; set; }
        public TodoDuration Duration { get; set; }
        public List<TagVm> Tags { get; set; }
    }
}