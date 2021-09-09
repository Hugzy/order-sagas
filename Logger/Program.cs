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
                await bus.Subscribe<OrderCreated>();
                await bus.Subscribe<OrderPayment>();
                await bus.Subscribe<OrderFailed>();
                await bus.Subscribe<OrderReadyForExport>();
                await bus.Subscribe<OrderExported>();

                Console.WriteLine("Press ENTER to quit");
                Console.ReadLine();
            }
        }
    }
}