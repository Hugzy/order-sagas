﻿using System;
using System.Collections.Generic;
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
        IHandleMessages<PayOrderEvent>,
        IHandleMessages<PaymentSucceededEvent>,
        IHandleMessages<PaymentFailedEvent>,
        IHandleMessages<OrderReadyForExportEvent>,
        IHandleMessages<OrderExportedEvent>,
        IHandleMessages<OrderFailedEvent>
    {
        private IBus _bus { get; set; }

        public OrderSaga(IBus bus)
        {
            _bus = bus;
        }

        protected override void CorrelateMessages(ICorrelationConfig<OrderSagaData> config)
        {
            config.Correlate<PlaceOrderEvent>(m => m.OrderId, d => d.OrderId);
            config.Correlate<PayOrderEvent>(m => m.OrderId, d => d.OrderId);
            config.Correlate<PaymentSucceededEvent>(m => m.OrderId, d => d.OrderId);
            config.Correlate<PaymentFailedEvent>(m => m.OrderId, d => d.OrderId);
            config.Correlate<OrderReadyForExportEvent>(m => m.OrderId, d => d.OrderId);
            config.Correlate<OrderExportedEvent>(m => m.OrderId, d => d.OrderId);
            config.Correlate<OrderFailedEvent>(m => m.OrderId, d => d.OrderId);
        }

        public async Task Handle(PlaceOrderEvent message)
        {
            if (!IsNew) return;
            Data.OrderId = message.OrderId;
            Data.StartDate = DateTimeOffset.Now;

            Data.Log.Push(message.Log());
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Placing order with id {message.OrderId}");
            Console.ResetColor();

            await _bus.Publish(new OrderCreatedEvent(Data.OrderId));
        }

        public async Task Handle(PayOrderEvent message)
        {
            Data.PaymentReceived = true;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Payed for order {message.OrderId}");
            Console.ResetColor();

            await _bus.Publish(new OrderReadyForExportEvent(Data.OrderId));
        }

        public async Task Handle(OrderReadyForExportEvent message)
        {
            Data.ReadyToBeExported = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Order is ready to be exported, sending order to ERP System {Data.OrderId}");
            Console.ResetColor();

            MarkAsComplete();
        }

        public async Task Handle(PaymentSucceededEvent message)
        {
            Data.PaymentReceived = true;
            Data.Log.Push(message.Log());

            await _bus.Publish(new OrderReadyForExportEvent(Data.OrderId));
        }

        public async Task Handle(PaymentFailedEvent message)
        {
            Data.PaymentFailed = true;
            Data.PaymentRetryCount++;
            Data.Log.Push(message.Log($"Retry count: {Data.PaymentRetryCount}"));

            switch (Data.PaymentRetryCount)
            {
                case >= 5:
                    await _bus.Publish(new OrderFailedEvent(Data.OrderId));
                    break;
                default:
                    await _bus.Publish(new OrderPaymentEvent(Data.OrderId));
                    break;
            }
        }

        public async Task Handle(OrderExportedEvent message)
        {
            Data.IsExported = true;
            Data.Log.Push(message.Log());
            
            MarkAsComplete();
        }

        public async Task Handle(OrderFailedEvent message)
        {
            Data.Log.Push(message.Log());
            Data.Cause = "Cause";
            
            MarkAsComplete();
        }
        
    }
    
    public class OrderSagaData : ISagaBase
    {
        public Guid Id { get; set; }
        public int Revision { get; set; }
        
        public int OrderId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public Stack<string> Log { get; set; }
        public bool PaymentReceived { get; set; }
        public bool OrderIsPending { get; set; }
        public bool IsCancelled { get; set; }
        public bool PaymentFailed { get; set; }
        public string Cause { get; set; }
        public bool ReadyToBeExported { get; set; }
        public bool IsExported { get; set; }
        public int PaymentRetryCount { get; set; }
        
    }
}