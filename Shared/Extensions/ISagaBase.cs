using System;
using Rebus.Sagas;

namespace Shared.Extensions
{
    public interface ISagaBase : ISagaData 
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}