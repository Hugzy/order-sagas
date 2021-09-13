using System;
using System.Threading.Tasks;
using Rebus.Bus;
using Rebus.Handlers;
using Shared.Events;

namespace OrderingSystemWithSagas.Orders
{
    public class PaymentReadyHandler : IHandleMessages<OrderCreatedEvent>
    {
        private IBus _bus { get; set; }

        public PaymentReadyHandler(IBus bus)
        {
            _bus = bus;
        }
        
        public async Task Handle(OrderCreatedEvent message)
        {
            SimpleLogger.Info(message);

            // await _bus.Publish(new OrderReadyForPaymentEvent(message.OrderId));
        }
    }
}