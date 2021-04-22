using System;

namespace Jour.WebAPI.Infrastructure
{
    public interface IDateTime
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}