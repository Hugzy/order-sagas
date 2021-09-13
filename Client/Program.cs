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
            
            PrintHelp();
            
            Console.WriteLine("Enter a command");
            var command = Console.ReadLine();

            while (command?.ToLower() != "q" && command?.ToLower() != "0")
            {
                switch (command)
                {
                    case "new" or "1":
                        var randInt = new Random().Next(1000);
                        await bus.Publish(new PlaceOrderEvent(randInt));
                        break;
                    case "2" or "list":
                        break;
                    case "3" or "pay":
                        Console.WriteLine("Please enter the OrderId you'd like to pay for");
                        var orderId = Console.ReadLine();
                        var tryParse = int.TryParse(orderId, out var orderIdint);
                        if (!tryParse)
                        {
                            Console.WriteLine("Please enter a valid orderid");
                            continue;
                        }
                        await bus.Publish(new PayOrderEvent(orderIdint));
                        break;
                    case "4" or "cancel":
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
            new or 1                        - Place a new order
            list or 2                       - List all orders currently not completed
            pay or 3                        - Pay for an order
            cancel or 4                     - Cancel an order
");
        }
    }
}