using System.Threading.Tasks;
using Rebus.Handlers;
using Shared.Events;

namespace OrderingSystemWithSagas
{
    public class PayOrderEventHandler : IHandleMessages<PayOrderEvent>
    {
        public Task Handle(PayOrderEvent message)
        {
            /*
             * Handle payments idempotently
             * Set a failure rate of 20%
             * Publish either a PaymentSucceededEvent or a PaymentFailedEvent
             */
            throw new System.NotImplementedException();
        }
    }
}