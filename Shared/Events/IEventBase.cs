namespace Shared.Events
{
    public abstract class IEventBase
    {
        public abstract int OrderId { get; set;}

        public string Log(string optionalMessage = "")
        {
            return $"Event: {GetType()} - Additional Message: {optionalMessage} - OrderId: {OrderId}";
        }
    }
}