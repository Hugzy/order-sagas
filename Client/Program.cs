using System;
using System.Threading.Tasks;
using Rebus.Activation;
using Rebus.Config;
using Shared;
using Shared.Events;

namespace Client
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            
            using var activator = new BuiltinHandlerActivator();

            var bus = Configure.With(activator)
                .ConfigureEndpoint(EndpointRole.Client)
                .Start();

            activator.Handle<OrderPlaced>(async order =>
            {
                // DO Stuff
                Console.WriteLine(order.OrderId);
            });
            Console.WriteLine("Enter a command");
            var command = Console.ReadLine();

            while (command?.ToLower() != "q" && command?.ToLower() != "0")
            {
                switch (command)
                {
                    case "new" or "1":
                        var randInt = new Random().Next(1000);
                        await bus.Publish(new OrderPlaced(randInt));
                        break;
                    case "pay" or "2":
                        Console.WriteLine("Please enter the OrderId you'd like to pay for");
                        var orderId = Console.ReadLine();
                        var tryParse = int.TryParse(orderId, out var orderIdint);
                        if (!tryParse)
                        {
                            Console.WriteLine("Please enter a valid orderid");
                            continue;
                        }
                        await bus.Publish(new OrderPayment(orderIdint));
                        break;
                    case "fail" or "3":
                        await bus.Publish(new OrderFailed());
                        break;
                    case "export" or "4":
                        await bus.Publish(new OrderExported(0));
                        break;
                    case "exportready" or "rexport" or "5":
                        await bus.Publish(new OrderReadyForExport(0));
                        break;
                    default:
                        PrintHelp();
                        break;
                }
                
                Console.WriteLine("Enter a command");
                command = Console.ReadLine();
            }
        }
        
        private static void PrintHelp()
        {
            Console.WriteLine(@"
            Available commands:

            q or 0                          - Quit the application
            new or 1                        - Publish a new PlaceOrder event
            Pay or 2                        - Publish a new PayOrder event
            fail or 3                       - Publish a new OrderFailed event
            export or 4                     - Publish a new ExportOrder event
            exportready or rexport or 5     - Publish a new OrderReadyToExport event
");
        }
    }
}