using OcarinaMultiworld.Lib.Locations;
using System;

namespace OcarinaMultiworld.Lib
{
    public class LocationCheck
    {
        public Location Location { get; }
        public bool     Checked  { get; private set; }

        public LocationCheck(Location location, bool @checked)
        {
            Location = location;
            Checked = @checked;
        }

        public void CheckLocation(int count, int total)
        {
            // Do not post anything if we already checked this location.
            if (Checked) return;
            
            Console.WriteLine($"New Check: {Location.Name} ({++count}/{total})");
            Checked = true;
        }
    }
}
