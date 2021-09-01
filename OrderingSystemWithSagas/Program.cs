using System;
using System.Windows.Input;
using McMaster.Extensions.CommandLineUtils;

namespace OrderingSystemWithSagas
{
    interface ICommandable
    {
        void OnExecute(IConsole console);
    }
    
    [Command(Name = "Entry")]
    class Program
    {
        public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        private int OnExecute(CommandLineApplication app, IConsole console)
        {
            console.WriteLine("You must specify at a subcommand.");
            app.ShowHelp();
            return 1;
        } 
        
        [Command("orders", "Manage Orders")]
        private class Order
        {
            private void OnExecute(IConsole console)
            {
                Console.WriteLine("hello world");
            }
        }
    }
}