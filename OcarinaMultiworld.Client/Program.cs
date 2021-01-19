using OcarinaMultiworld.Lib;
using System;
using System.Threading;

namespace OcarinaMultiworld.Client
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting listen server...");
            var server = new ListenServer("127.0.0.1", 39876);
            var thread = new Thread(server.StartListener);
            thread.Start();
            
            Console.WriteLine("Listen server created...");

            var player = new Player("Phar", 1);
            
            // TODO: REMOVE THIS GOD AWFUL THING.
            retry:
            if (server.State != ListenState.Ready)
                goto retry;
            
            const uint address = 0x11A5D0;
            const uint bytes = 0x1000;
                
            // server.WriteToMemory(address, "Phar".ConvertToOot());
                
            while (true)
            {
                var updated = Parser.TryUpdatePlayer(ref player, server);

                if (updated)
                {
                    Console.Clear();
                    Console.WriteLine(player);
                }
            }
        }
    }
}
