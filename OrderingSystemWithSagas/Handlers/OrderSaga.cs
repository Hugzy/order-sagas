using System;
using System.Threading.Tasks;
using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Sagas;
using Shared.Events;

namespace OrderingSystemWithSagas.Orders
{
    public class OrderSaga : Saga<OrderSagaData>
        ,IAmInitiatedBy<OrderPlaced>,
        IHandleMessages<OrderPayment>,
        IHandleMessages<OrderReadyForExport>,
        IHandleMessages<OrderFailed>
    {
        private IBus _bus { get; set; }
        
        public OrderSaga(IBus bus)
        {
            _bus = bus;
        }

        protected override void CorrelateMessages(ICorrelationConfig<OrderSagaData> config)
        {
            config.Correlate<OrderPlaced>(m => m.OrderId, d => d.OrderId);
            
            config.Correlate<OrderPayment>(m => m.OrderId, d => d.OrderId);
        }

        public async Task Handle(OrderPlaced message)
        {
            if (!IsNew) return;

            Data.OrderId = message.OrderId;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Placing order with id {message.OrderId}");
            Console.ResetColor();
            
            await _bus.Publish(new OrderCreated(Data.OrderId));
        }

        public async Task Handle(OrderPayment message)
        {
            Data.ReceivedPayment = true;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Payed for order {message.OrderId}");
            Console.ResetColor();
            
            await _bus.Publish(new OrderReadyForExport(Data.OrderId));
            
            MarkAsComplete();
        }

        public async Task Handle(OrderReadyForExport message)
        {
            Data.IsReadyForExport = true;

            await _bus.Publish(new OrderExported(Data.OrderId));
            
            MarkAsComplete();
        }

        public async Task Handle(OrderFailed message)
        {
        }
    }
}