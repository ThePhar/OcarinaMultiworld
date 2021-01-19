namespace OcarinaMultiworld.Lib
{
    public class Player
    {
        public string Name   { get; set; }
        public byte   Number { get; }

        public bool DefeatedGanon { get; init; } = false;

        public Equipment Equipment { get; init; } = new();
        public Dungeons  Keyrings  { get; init; } = new();
        public Inventory Inventory { get; init; } = new();
        public Quest     Quest     { get; init; } = new();
        public Songs     Songs     { get; init; } = new();

        public Player(string name, byte number)
        {
            Name = name;
            Number = number;
        }

        public override string ToString() => this.PropertyList();
    }
}
