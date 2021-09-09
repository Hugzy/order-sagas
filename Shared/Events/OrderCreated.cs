namespace Shared.Events
{
    public class OrderCreated : IEventId
    {
        public int OrderId { get; set; }

        public OrderCreated(int orderId)
        {
            OrderId = orderId;
        }
    }
}