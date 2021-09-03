using System;
using System.Threading.Tasks;
using Rebus.Bus;
using Rebus.Handlers;
using Shared.Events;

namespace OrderingSystemWithSagas.Orders
{
    public class PaymentReadyHandler : IHandleMessages<OrderCreated>
    {
        private IBus _bus { get; set; }

        public PaymentReadyHandler(IBus bus)
        {
            _bus = bus;
        }
        
        public async Task Handle(OrderCreated message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Paying order: {message.OrderId}");
            Console.ResetColor();

            await _bus.Publish(new OrderPayment(message.OrderId));
        }
    }
}