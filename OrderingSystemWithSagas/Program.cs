using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Castle.Windsor;
using McMaster.Extensions.CommandLineUtils;
using OrderingSystemWithSagas.Installers;
using Rebus.Activation;
using Rebus.Config;
using Shared;

namespace OrderingSystemWithSagas
{
    
    class Program
    {
        public static async Task Main(string[] args)
        {

            using (var container = new WindsorContainer())
            {
                container.Install(new RebusHandlersInstaller())
                    .Install(new RebusInstaller())
                    .Install(new SubscriptionsInstaller());
                
                Console.WriteLine("Press ENTER to quit");
                Console.ReadLine();
            }
        }
    }
}