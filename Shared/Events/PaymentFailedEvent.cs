namespace Shared.Events
{
    public class PaymentFailedEvent : IEventBase
    {
        public override int OrderId { get; set; }
        public int RetryCount { get; set; }
    }
}