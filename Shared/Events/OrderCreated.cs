namespace Shared.Events
{
    public class OrderCreated : IEventId
    {
        public int OrderId { get; }

        public OrderCreated(int orderId)
        {
            OrderId = orderId;
        }
    }
}