namespace Shared.Events
{
    public class OrderReadyForExportEvent : IEventBase
    {
        public override int OrderId { get; set; }

        public OrderReadyForExportEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}