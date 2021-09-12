namespace Shared.Events
{
    public class PaymentSucceededEvent : IEventBase
    {
        public override int OrderId { get; set; }
    }
}