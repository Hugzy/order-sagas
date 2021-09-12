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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Paying order: {message.OrderId}");
            Console.ResetColor();

            var orderId = message.OrderId;
            
            await _bus.Publish(new OrderPaymentEvent(orderId));
        }
    }
}