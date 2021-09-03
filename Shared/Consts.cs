namespace Shared
{
    public static class Consts
    {
        public static string GetRabbitMQConnectionstring(
            string user = "guest",
            string password = "guest",
            string host = "localhost",
            string port = "5672",
            string vHost = "/") => $"amqp://{user}:{password}@{host}:{port}/{vHost}";

        public static string MSSQLConnectionString() => $"";
        
        public static string OrderQueue => "order-queue";

        public static string OrderSagaTableName => "ordertable";
        public static string OrderSagaIndexName => "indextable";

        public static string QueueName = "sagademo_server";
        public static string SubscriptionsTableName = "Rebus_Subscriptions";
        public static string SagaDataTableName = "Rebus_SagaData";
        public static string SagaIndexTableName = "Rebus_SagaIndex";
        public static string TimeoutsTableName = "Rebus_Timeouts";
    }
}