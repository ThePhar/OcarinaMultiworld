// ReSharper disable PossibleNullReferenceException

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OcarinaMultiworld.Lib;
using OcarinaMultiworld.Lib.Locations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace OcarinaMultiworld.Server
{
    internal static class Program
    {
        public static List<Player> Players = new();
        
        public static void Main(string[] args)
        {
            // Server must have a spoiler.json file to start.
            if (args.Length == 0)
            {
                Console.WriteLine($"Usage: OcarinaMultiworld.Server [path/to/Spoiler.json]");
                Console.Read();
                return;
            }
            
            // Server must have accepted a JSON file.
            var path = Path.GetFullPath(args[0]);
            var spoiler = JObject.Parse(File.ReadAllText(path));
            
            // Create players based on spoiler log.
            var playerCount = spoiler["settings"]?["world_count"]?.Value<int>();
            if (playerCount <= 1)
                throw new Exception("You must submit a spoiler with more than 1 world");

            // Generate players from spoiler log.
            for (var i = 1; i <= playerCount; i++)
            {
                var locations = new List<LocationCheck>();
                var spoilerLocations = spoiler["locations"][$"World {i}"].Children();

                foreach (var locationToken in spoilerLocations)
                {
                    // Oh boy, this is a mouth-full.
                    var location = LocationDictionary.FetchByName((locationToken as JProperty).Name);

                    if (location != null)
                    {
                        locations.Add(new LocationCheck(location, false));
                    }
                    else
                        throw new Exception($"{locationToken} is invalid!");
                }
                
                // Get player name.
                string name;
                var valid = false;
                do
                {
                    Console.Write($"Please enter a name for Player {i}: ");
                    name = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("You must enter a name for this player.");
                        continue;
                    }

                    if (name.Length > 8)
                    {
                        Console.WriteLine("Names must be 8 or fewer characters. This is a Ocarina of Time Randomizer limitation.");
                        continue;
                    }

                    if (Regex.IsMatch(name, "[^A-Za-z0-9._\\s]"))
                    {
                        Console.WriteLine("Names can only contain simple letters, numbers, periods, dashes, or spaces.");
                        continue;
                    }

                    valid = true;
                } while (!valid);
                

                var player = new Player(name, (byte) i, locations);
                Players.Add(player);
            }

            Console.WriteLine(Players);
        }
    }
}
