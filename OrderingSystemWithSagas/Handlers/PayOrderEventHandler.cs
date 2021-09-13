using System;
using System.Threading.Tasks;
using Rebus.Bus;
using Rebus.Handlers;
using Shared.Events;

namespace OrderingSystemWithSagas
{
    public class PayOrderEventHandler : IHandleMessages<PayOrderEvent>
    {
        private readonly IBus _bus;

        public PayOrderEventHandler(IBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(PayOrderEvent message)
        {
            var random = new Random();

            var fail = random.Next(0, 100);

            /*
             * Handle payments idempotently
             * Set a failure rate of 20%
             * Publish either a PaymentSucceededEvent or a PaymentFailedEvent
             */
            if (fail < 50)
            {
                await _bus.Publish(new PaymentFailedEvent() {OrderId = message.OrderId});
            }

            await _bus.Publish(new PaymentSucceededEvent() { OrderId = message.OrderId });
        }
    }
}