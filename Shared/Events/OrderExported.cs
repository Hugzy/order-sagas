namespace Shared.Events
{
    public class OrderExported : IEventId
    {

        public int OrderId { get; }
        public string IAmAnOrderExportedEvent => nameof(IAmAnOrderExportedEvent);
        public OrderExported(int id)
        {
            OrderId = id;
        }
    }
}