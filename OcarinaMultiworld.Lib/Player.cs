namespace OcarinaMultiworld.Lib
{
    public class Player
    {
        public string Name   { get; set; }
        public byte   Number { get; set; }

        public bool     DefeatedGanon { get; set; } = false;
        public Dungeons Keyrings      { get; set; } = new();
    }
}
