using System.Collections.Generic;

namespace OcarinaMultiworld.Lib.Locations
{
    public static class LocationDictionary
    {
        private static readonly Dictionary<string, Location> NamedDict = GenerateNamedDictionary();

        public static Location FetchByName(string name)
        {
            if (NamedDict.TryGetValue(name, out var location))
                return location;

            return null;
        }

        private static Dictionary<string, Location> GenerateNamedDictionary()
        {
            var dict = new Dictionary<string, Location>();
            var fields = typeof(LocationList).GetFields();
            
            foreach (var field in fields)
            {
                // Ignore non-items.
                if (field.FieldType != typeof(Location))
                    continue;

                var location = field.GetValue(null) as Location;
                
                // Ignore null locations. Unsure how this would happen in practice, but better safe than sorry.
                if (location == null)
                    continue;
                
                dict.Add(location.Name, location);
            }

            return dict;
        }
    }
}
