using System.Collections.Generic;

namespace OcarinaMultiworld.Lib
{
    public class Player
    {
        public string Name   { get; set; }
        public byte   Number { get; }

        public bool DefeatedGanon { get; init; } = false;

        public List<LocationCheck> Locations { get; }

        public Equipment Equipment { get; init; } = new();
        public Dungeons  Keyrings  { get; init; } = new();
        public Inventory Inventory { get; init; } = new();
        public Quest     Quest     { get; init; } = new();
        public Songs     Songs     { get; init; } = new();

        public Player(string name, byte number, List<LocationCheck> locations)
        {
            Name = name;
            Number = number;
            Locations = locations;
        }

        public override string ToString() => this.PropertyList();
    }
}
