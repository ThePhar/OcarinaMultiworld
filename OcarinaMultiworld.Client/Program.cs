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

            while (true)
            {
                if (server.State != ListenState.Ready)
                    continue;
                
                // TODO: Remove this debug code.
                const uint address = 0x11A5D0 + 0x24;
                const uint bytes = 0x8;
                
                while (true)
                {
                    var response = server.ReadFromMemory(address, bytes);
                    Console.WriteLine($"Reading address {address}: [ {string.Join(",", response)} ]");

                    var name = response.ConvertToAscii();
                    Console.WriteLine($"Your name is {name}.");
                }
            }
        }
    }
}
