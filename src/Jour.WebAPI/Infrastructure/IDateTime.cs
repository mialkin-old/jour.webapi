using System;

namespace Jour.WebAPI.Infrastructure
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
        DateTime MoscowTimeNow { get; }
    }
}