using System;
using System.Threading.Tasks;
using Rebus.Activation;
using Rebus.Config;

namespace RebusTest
{
    public class RabbitMQEventFuckery
    {
        public async Task Main()
        {
            var factory = new ConnectionFactory
            {
                User = "guest",
                Password = "guest",
                Host = "localhost",
                Port = 5672,
                VHost = "/"
            };


            using var activator = new BuiltinHandlerActivator();
            // add handler for MyEvent
            activator.Handle<Event>(async message =>
            {
                Console.WriteLine(message.Msg);
            });

            // configure subscriber
            var subscriber = Configure.With(activator)
                .Transport(t => t.UseRabbitMq(factory.GetConnectionString, "my-subscriber"))
                .Start();

            await activator.Bus.Publish(new Event() {Msg = "Hello World"});
                
            await subscriber.Subscribe<Event>();
                
            Console.WriteLine("Press enter to quit");
            Console.ReadLine();
        }
    }
}