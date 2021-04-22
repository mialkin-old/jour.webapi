using System;

namespace Jour.WebAPI.Infrastructure
{
    public class MachineClockDateTime : IDateTime
    {
        public DateTime Now => System.DateTime.Now;
        public DateTime UtcNow => System.DateTime.UtcNow;
    }
}