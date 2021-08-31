namespace RebusTest
{
    public class ConnectionFactory
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string VHost { get; set; }

        public string GetConnectionString => $"amqp://{User}:{Password}@{Host}:{Port}/{VHost}";

    }
}