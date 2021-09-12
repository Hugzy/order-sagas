using System.Threading.Tasks;
using Rebus.Handlers;
using Serilog;
using Shared.Events;

namespace Logger
{
    public class EventLogger : IHandleMessages<IEventBase>
    {
        static readonly ILogger Logger = Log.ForContext<EventLogger>();

        public async Task Handle(IEventBase message)
        {
            Logger.Information("Got event {EventName} for order {OrderId}", message.GetType().Name, message.OrderId);

        }
    }
}