using System;
using System.Threading.Tasks;
using Rebus.Activation;
using Rebus.Bus;
using Rebus.Config;
using Serilog;
using Shared;
using Shared.Events;

namespace Logger
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // configure Serilog to log with colors in a fairly compact format
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole(outputTemplate: "{Timestamp:HH:mm:ss} {Message}{NewLine}{Exception}")
                .CreateLogger();

            using (var activator = new BuiltinHandlerActivator())
            {
                activator.Register(() => new EventLogger());


                var bus = Configure.With(activator)
                    .ConfigureEndpoint(EndpointRole.Subscriber)
                    .Start();


                await bus.Subscribe<PlaceOrderEvent>();
                await bus.Subscribe<OrderCreatedEvent>();
                await bus.Subscribe<OrderPaymentEvent>();
                await bus.Subscribe<OrderFailedEvent>();
                await bus.Subscribe<OrderReadyForExportEvent>();
                await bus.Subscribe<OrderExportedEvent>();

                Console.WriteLine("Press ENTER to quit");
                Console.ReadLine();
            }
        }
    }
}