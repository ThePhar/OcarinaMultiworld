namespace OcarinaMultiworld.Lib
{
    public class Keyring
    {
        public bool BossKey   { get; set; } = false;
        public bool Map       { get; set; } = false;
        public bool Compass   { get; set; } = false;

        private byte _keys = 0;
        public byte SmallKeys
        {
            get => _keys == byte.MaxValue ? 0 : _keys;
            set => _keys = value;
        }
        
        public override string ToString() => this.PropertyList(2);
    }
}
