using OcarinaMultiworld.Lib.Items;

namespace OcarinaMultiworld.Lib
{
    public class Dungeons
    {
        public Keyring DekuTree              { get; init; } = new();
        public Keyring DodongosCavern        { get; init; } = new();
        public Keyring JabuJabusBelly        { get; init; } = new();
        public Keyring ForestTemple          { get; init; } = new();
        public Keyring FireTemple            { get; init; } = new();
        public Keyring WaterTemple           { get; init; } = new();
        public Keyring ShadowTemple          { get; init; } = new();
        public Keyring SpiritTemple          { get; init; } = new();
        public Keyring GanonsCastle          { get; init; } = new();
        public Keyring BottomOfTheWell       { get; init; } = new();
        public Keyring GerudoFortress        { get; init; } = new();
        public Keyring GerudoTrainingGrounds { get; init; } = new();
        public Keyring IceCavern             { get; init; } = new();

        public override string ToString() => this.PropertyList(1);
    }
}
