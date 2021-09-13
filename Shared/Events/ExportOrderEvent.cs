namespace Shared.Events {

    public class ExportOrderEvent : IEventBase
    {
        public override int OrderId { get; set; }

        public ExportOrderEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}