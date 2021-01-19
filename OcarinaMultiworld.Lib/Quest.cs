namespace OcarinaMultiworld.Lib
{
    public class Quest
    {
        public uint SkulltulaTokens { get; set; } = 0;
        public uint TriforcePieces  { get; set; } = 0;

        public bool Emerald  { get; set; } = false;
        public bool Ruby     { get; set; } = false;
        public bool Sapphire { get; set; } = false;
        public bool Light    { get; set; } = false;
        public bool Forest   { get; set; } = false;
        public bool Fire     { get; set; } = false;
        public bool Water    { get; set; } = false;
        public bool Shadow   { get; set; } = false;
        public bool Spirit   { get; set; } = false;

        public bool GerudoCard   { get; set; } = false;
        public bool StoneOfAgony { get; set; } = false;
        
        public override string ToString() => this.PropertyList(1);
    }
}
