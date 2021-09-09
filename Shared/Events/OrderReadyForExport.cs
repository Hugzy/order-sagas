namespace Shared.Events
{
    public class OrderReadyForExport : IEventId
    {
        public string IAmAnOrderReadyExportedEvent => nameof(IAmAnOrderReadyExportedEvent);

        public int OrderId { get; set; }

        public OrderReadyForExport(int orderId)
        {
            OrderId = orderId;
        }
    }
}