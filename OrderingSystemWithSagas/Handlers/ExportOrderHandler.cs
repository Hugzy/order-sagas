using System;
using System.Threading.Tasks;
using Rebus.Bus;
using Rebus.Handlers;
using Shared.Events;


namespace OrderingSystemWithSagas.Orders
{
    public class ExportOrderHandler : IHandleMessages<ExportOrderEvent>
    {
        private readonly IBus _bus;

        public ExportOrderHandler(IBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(ExportOrderEvent message)
        {
            SimpleLogger.Info(message);

            await _bus.Publish(new OrderExportedEvent(message.OrderId));
        }

    }
}