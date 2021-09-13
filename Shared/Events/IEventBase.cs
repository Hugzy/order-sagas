namespace Shared.Events
{
    public abstract class IEventBase
    {
        public abstract int OrderId { get; set;}

        public override string ToString()
        {
            return $"Event: {GetType()} - OrderId: {OrderId}";
        }
    }
}