namespace OcarinaMultiworld.Lib
{
    public class Songs
    {
        public bool Lullaby  { get; set; } = false;
        public bool Sarias   { get; set; } = false;
        public bool Eponas   { get; set; } = false;
        public bool Suns     { get; set; } = false;
        public bool Time     { get; set; } = false;
        public bool Storms   { get; set; } = false;
        public bool Minuet   { get; set; } = false;
        public bool Bolero   { get; set; } = false;
        public bool Serenade { get; set; } = false;
        public bool Requiem  { get; set; } = false;
        public bool Nocturne { get; set; } = false;
        public bool Prelude  { get; set; } = false;
        
        public override string ToString() => this.PropertyList(1);
    }
}
