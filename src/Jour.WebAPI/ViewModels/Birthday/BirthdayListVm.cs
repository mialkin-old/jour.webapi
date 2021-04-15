namespace Jour.WebAPI.ViewModels.Birthday
{
    public class BirthdayListVm
    {
        public int BirthdayId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Day { get; set; }
        
        public int DayOfYear { get; set; }

        public int Month { get; set; }
        
        public int Year { get; set; }

        public bool IsActive { get; set; }
    }
}