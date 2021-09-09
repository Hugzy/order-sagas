using System;
using System.Threading.Tasks;
using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Sagas;
using Shared.Events;
using Shared.Extensions;

namespace OrderingSystemWithSagas.Orders
{
    public class OrderSaga : Saga<OrderSagaData>,
        IAmInitiatedBy<PlaceOrderEvent>,
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
            config.Correlate<PlaceOrderEvent>(m => m.OrderId, d => d.OrderId);
            config.Correlate<OrderPayment>(m => m.OrderId, d => d.OrderId);
            config.Correlate<OrderReadyForExport>(m => m.OrderId, d => d.OrderId);
            
        }

        public async Task Handle(PlaceOrderEvent message)
        {
            if (!IsNew) return;

            Data.OrderId = message.OrderId;
            Data.StartDate = DateTimeOffset.Now;
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Placing order with id {message.OrderId}");
            Console.ResetColor();
            
            await _bus.Publish(new OrderCreated(Data.OrderId));
        }

        public async Task Handle(OrderPayment message)
        {
            Data.PaymentReceived = true;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Payed for order {message.OrderId}");
            Console.ResetColor();
            
            await _bus.Publish(new OrderReadyForExport(Data.OrderId));
        }

        public async Task Handle(OrderReadyForExport message)
        {
            Data.ReadyToBeExported = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Order is ready to be exported, sending order to ERP System {Data.OrderId}");
            Console.ResetColor();
            
            MarkAsComplete();
        }

        public Task Handle(OrderFailed message)
        {
            throw new NotImplementedException();
        }
    }
    
    public class OrderSagaData : ISagaBase
    {
        public Guid Id { get; set; }
        public int Revision { get; set; }
        
        public int OrderId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public bool PaymentReceived { get; set; }
        public bool Failed { get; set; }
        public string Cause { get; set; }
        public bool WaitingForApproval { get; set; }
        public bool ReadyToBeExported { get; set; }
        public bool IsExported { get; set; }
        
    }
}