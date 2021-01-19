using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OcarinaMultiworld.Client
{
    internal static class Program
    {
        public static async Task Main(string[] args)
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
                const uint address = 0x11A5D0;
                const uint bytes = 0x10;

                var response = server.WriteToMemory(0x400034, new byte[] { 255, 255, 0, 0 });
                if (response[0] == 0)
                {
                    Console.WriteLine("Good!");
                }
                else
                {
                    throw new IOException("Invalid response from client script.");
                }
            
                while (true)
                {
                    response = server.ReadFromMemory(address, bytes);
                    Console.WriteLine($"Reading address {address}: [ {string.Join(",", response)} ]");
                }
            }
            
            await Task.Delay(-1);
        }
    }
}
