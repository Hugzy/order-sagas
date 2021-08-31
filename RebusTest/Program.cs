using System;
using System.Threading.Tasks;
using Rebus.Activation;
using Rebus.Config;
using RabbitMQ.Client;

namespace RebusTest
{
    class Event
    {
        public string Msg { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            await EfCore();
        }

        public static async Task EfCore()
        {
            var efcore = new EfCoreFuckery();
            await efcore.Main();
        }

        public static async Task Rebus()
        {
            var rebusrabbitMq = new RabbitMQEventFuckery();
            await rebusrabbitMq.Main();
        }
    }
}