namespace Shared.Events
{
    public class PayOrderEvent : IEventBase
    {
        public override int OrderId { get; set; }

        public PayOrderEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}