using System.Collections.Generic;

namespace Jour.WebAPI.ViewModels.Birthday
{
    public class BirthdayListVm
    {
        public int Month { get; set; }

        public string MonthText { get; set; }

        public bool HasActiveBirthdays { get; set; }

        public List<BirthdayVm> Birthdays { get; set; }
    }
}