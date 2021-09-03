namespace Shared.Events
{
    public class OrderPayment : IEventId
    {
        public int OrderId { get; }
        public string IAmAnOrderPaymentEvent => nameof(IAmAnOrderPaymentEvent);


        public OrderPayment(int id)
        {
            OrderId = id;
        }
    }
}