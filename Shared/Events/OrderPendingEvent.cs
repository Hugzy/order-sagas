namespace Shared.Events
{
    public class OrderPendingEvent : IEventBase
    {
        public override int OrderId { get; set; }
    }
}