namespace Jour.WebAPI.Infrastructure
{
    public class Months
    {
        private readonly string[] _months =
        {
            "n/a", "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь",
            "Ноябрь", "Декабрь"
        };

        public string this[int i] => _months[i];
    }
}