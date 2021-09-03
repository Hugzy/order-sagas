namespace Shared.Events
{
    public class OrderPlaced : IEventId
    {

        public int OrderId { get; set; }
        public string IAmAnOrderPlacedEvent => nameof(IAmAnOrderPlacedEvent);
        public OrderPlaced(int orderId)
        {
            OrderId = orderId;
        }
    }
}