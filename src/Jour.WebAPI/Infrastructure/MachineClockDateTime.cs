using System;

namespace Jour.WebAPI.Infrastructure
{
    public class MachineClockDateTime : IDateTime
    {
        public DateTime UtcNow { get; private set; }
        public DateTime MoscowTimeNow { get; private set; }
        public MachineClockDateTime()
        {
            UtcNow = DateTime.UtcNow;
            MoscowTimeNow = UtcNow.AddHours(3);
        }
    }
}