namespace Shared.Events
{
    public class PlaceOrderEvent : IEventBase
    {
        public override int OrderId { get; set; }
        public PlaceOrderEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}