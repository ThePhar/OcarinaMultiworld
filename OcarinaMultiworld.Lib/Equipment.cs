namespace OcarinaMultiworld.Lib
{
    public class Equipment
    {
        public bool KokiriSword    { get; set; } = false;
        public bool MasterSword    { get; set; } = false;
        public bool BiggoronSword  { get; set; } = false;
        public bool GiantsKnife    { get; set; } = false;
        public bool DekuShield     { get; set; } = false;
        public bool HylianShield   { get; set; } = false;
        public bool MirrorShield   { get; set; } = false;
        public bool KokiriTunic    { get; set; } = true;
        public bool GoronTunic     { get; set; } = false;
        public bool ZoraTunic      { get; set; } = false;
        public bool KokiriBoots    { get; set; } = true;
        public bool IronBoots      { get; set; } = false;
        public bool HoverBoots     { get; set; } = false;
        public int  StrengthLevel  { get; set; } = 0;
        public int  ScaleLevel     { get; set; } = 0;
        public int  MagicLevel     { get; set; } = 0;
        public int  WalletLevel    { get; set; } = 0;
        public int  SticksUpgrade  { get; set; } = 0;
        public int  NutsUpgrade    { get; set; } = 0;
        public int  BombBagUpgrade { get; set; } = 0;
        public int  QuiverUpgrade  { get; set; } = 0;
        public int  SeedBagUpgrade { get; set; } = 0;

        public override string ToString() => this.PropertyList(1);
    }
}
