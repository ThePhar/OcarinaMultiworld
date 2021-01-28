using OcarinaMultiworld.Lib;
using OcarinaMultiworld.Lib.Locations;
using System;
using System.Collections.Generic;
using System.IO;
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

            var player = new Player("Phar", 1, CreateLocations());

            while (true)
            {
                if (server.State != ListenState.Ready)
                    continue;

                try
                {
                    if (Parser.IsStateSafeToUpdate(server) && Parser.TryUpdatePlayer(ref player, server))
                    {
                        // Console.Clear();
                        // Console.WriteLine(player);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Failed to read from ootr-bridge.lua. Closing connection and retrying to connect...");
                    server.CloseClient();;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error has occurred: {e}");
                }
            }
        }

        private static List<LocationCheck> CreateLocations()
        {
            var list = new List<LocationCheck>();
            var fields = typeof(LocationList).GetFields();
            
            foreach (var field in fields)
            {
                if (field.FieldType != typeof(Location))
                    continue;

                var location = field.GetValue(null) as Location;
                
                if (location != null)
                    list.Add(new LocationCheck(location, false));
            }

            return list;
        }
    }
}
