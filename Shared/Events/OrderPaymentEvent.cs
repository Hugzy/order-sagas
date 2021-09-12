namespace Shared.Events
{
    public class OrderPaymentEvent : IEventBase
    {
        public override int OrderId { get; set; }

        public OrderPaymentEvent(int id)
        {
            OrderId = id;
        }
    }
}