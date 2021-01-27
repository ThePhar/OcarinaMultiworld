using OcarinaMultiworld.Lib.Items;
using OcarinaMultiworld.Lib.Locations;
using System;

namespace OcarinaMultiworld.Server
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var item = ItemDictionary.FetchByInventoryId(0xFF);
            Console.WriteLine(item);

            var location = LocationDictionary.FetchByName("Links Pocket");
            Console.WriteLine(location);
        }
    }
}
