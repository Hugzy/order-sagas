namespace Shared.Events
{
    public class OrderCanceledEvent : IEventBase
    {
        public override int OrderId { get; set; }

        public OrderCanceledEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}