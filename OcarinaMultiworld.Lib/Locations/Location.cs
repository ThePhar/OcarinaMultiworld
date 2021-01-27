namespace OcarinaMultiworld.Lib.Locations
{
    public record Location
    {
        public string       Name       { get; }
        public LocationType Type       { get; }
        public byte?        Scene      { get; }
        public byte?        Flag       { get; }
        public uint[]       Addresses  { get; }
        public string[]     Categories { get; } // TODO: Remove this? Not really used in my script, more of a hold off from original python script.

        internal Location(string name, LocationType type, byte? scene, byte? flag, uint[] addresses, string[] categories = null)
        {
            Name = name;
            Type = type;
            Scene = scene;
            Flag = flag;
            Addresses = addresses;
            Categories = categories;
        }
    }
}
