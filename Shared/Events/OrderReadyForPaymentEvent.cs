namespace Shared.Events
{
    public class OrderReadyForPaymentEvent : IEventBase
    {
        public override int OrderId { get; set; }

        public OrderReadyForPaymentEvent(int id)
        {
            OrderId = id;
        }
    }
}