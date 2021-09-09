using System.Threading.Tasks;
using Rebus.Handlers;
using Serilog;
using Shared.Events;

namespace Logger
{
    public class EventLogger : IHandleMessages<IEventId>
    {
        static readonly ILogger Logger = Log.ForContext<EventLogger>();

        public async Task Handle(IEventId message)
        {
            Logger.Information("Got event {EventName} for order {OrderId}", message.GetType().Name, message.OrderId);

        }
    }
}