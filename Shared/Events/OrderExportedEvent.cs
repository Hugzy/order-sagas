namespace Shared.Events
{
    public class OrderExportedEvent : IEventBase
    {
        public override int OrderId { get; set; }

        public OrderExportedEvent(int id)
        {
            OrderId = id;
        }
    }
}