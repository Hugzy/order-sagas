namespace Shared.Events
{
    public class OrderCreatedEvent : IEventBase
    {
        
        public override int OrderId { get; set; }

        public OrderCreatedEvent(int orderId)
        {
            OrderId = orderId;
        }

    }
}