namespace Shared.Events
{
    public class PlaceOrderEvent : IEventId
    {

        public int OrderId { get; set; }
        public string IAmAnOrderPlacedEvent => nameof(IAmAnOrderPlacedEvent);
        public PlaceOrderEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}