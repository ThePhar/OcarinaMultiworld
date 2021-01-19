namespace OcarinaMultiworld.Lib
{
    public record Location
    {
        public string       Name       { get; }
        public LocationType Type       { get; }
        public byte?        Scene      { get; }
        public byte?        Flag       { get; }
        public uint[]       Addresses  { get; }
        public string[]     Categories { get; }

        public Location(string name, LocationType type, byte? scene, byte? flag, uint[] addresses, string[] categories = null)
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
