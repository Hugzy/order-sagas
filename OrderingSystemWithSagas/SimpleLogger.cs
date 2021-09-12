using System;
using Shared.Events;

namespace OrderingSystemWithSagas
{
    public static class SimpleLogger
    {
        public static void Info<T>(T e) where T: IEventBase
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Completed --- {e.Log()} --- successfully");
            Console.ResetColor();
        }

        public static void Warning<T>(T e) where T : IEventBase
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Completed --- {e.Log()} --- with warnings");
            Console.ResetColor();
        }
        
        public static void Error<T>(T e) where T : IEventBase
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Failed to complete --- {e.Log()}");
            Console.ResetColor();
        }
    }
}