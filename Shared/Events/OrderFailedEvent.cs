namespace Shared.Events
{
    public class OrderFailedEvent : IEventBase
    {

        public override int OrderId { get; set; }

        public OrderFailedEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}