namespace Shared.Events
{
    public class OrderFailed : IEventId
    {

        public int OrderId { get; set; }
        public string IAmAnOrderFailedEvent => nameof(IAmAnOrderFailedEvent);
        public OrderFailed(int orderId)
        {
            OrderId = orderId;
        }
    }
}