using OcarinaMultiworld.Lib.Settings;
using System;

namespace OcarinaMultiworld.Lib
{
    public record SettingsFile
    {
        // Required Fields
        public string   Version                { get; }
        public string[] FileHash               { get; }
        public string   Seed                   { get; }
        public string   SettingsString         { get; }
        public bool     EnableDistributionFile { get; }

        public SettingsFile(string version, string[] fileHash, string seed, string settingsString, bool enableDistributionFile)
        {
            Version = version;
            FileHash = fileHash;
            Seed = seed;
            SettingsString = settingsString;
            EnableDistributionFile = enableDistributionFile;
        }

        public int                      WorldCount                        { get; init; } = 1;
        public bool                     CreateSpoiler                     { get; init; } = true;
        public bool                     RandomizeSettings                 { get; init; } = false;
        public OpenForest               OpenForest                        { get; init; } = OpenForest.Closed;
        public OpenKakariko             OpenKakariko                      { get; init; } = OpenKakariko.Closed;
        public bool                     OpenDoorOfTime                    { get; init; } = false;
        public ZoraFountain             ZoraFountain                      { get; init; } = ZoraFountain.Closed;
        public GerudoFortress           GerudoFortress                    { get; init; } = GerudoFortress.Normal;
        public BridgeRequirement        BridgeRequirement                 { get; init; } = BridgeRequirement.Medallions;
        public int                      BridgeMedallions                  { get; init; } = 6;
        public int                      BridgeStones                      { get; init; } = 3;
        public int                      BridgeRewards                     { get; init; } = 9;
        public int                      BridgeSkulltulas                  { get; init; } = 100;
        public bool                     TriforceHunt                      { get; init; } = false;
        public int                      TriforcePerWorld                  { get; init; } = 20;
        public LogicRules               LogicRules                        { get; init; } = LogicRules.Glitchless;
        public bool                     AllReachable                      { get; init; } = true;
        public bool                     BombchusInLogic                   { get; init; } = false;
        public bool                     OneItemPerDungeon                 { get; init; } = false;
        public bool                     TrialsRandom                      { get; init; } = false;
        public int                      Trials                            { get; init; } = 6;
        public bool                     SkipChildZelda                    { get; init; } = false;
        public bool                     NoEscapeSequence                  { get; init; } = false;
        public bool                     NoGuardStealth                    { get; init; } = false;
        public bool                     NoEponaRace                       { get; init; } = false;
        public bool                     SkipSomeMinigamePhases            { get; init; } = false;
        public bool                     UsefulCutscenes                   { get; init; } = false;
        public bool                     CompleteMaskQuest                 { get; init; } = false;
        public bool                     FastChests                        { get; init; } = true;
        public bool                     NightSkulltulasRequireSunsSong    { get; init; } = false;
        public bool                     FreeScarecrow                     { get; init; } = false;
        public bool                     FastBunnyHood                     { get; init; } = false;
        public bool                     StartWithRupees                   { get; init; } = false;
        public bool                     StartWithConsumables              { get; init; } = false;
        public int                      StartingHearts                    { get; init; } = 3;
        public bool                     ChickenCountRandom                { get; init; } = false;
        public int                      ChickenCount                      { get; init; } = 7;
        public bool                     BigPoeCountRandom                 { get; init; } = false;
        public int                      BigPoeCount                       { get; init; } = 10;
        public bool                     ShuffleKokiriSword                { get; init; } = true;
        public bool                     ShuffleOcarinas                   { get; init; } = false;
        public bool                     ShuffleWeirdEgg                   { get; init; } = false;
        public bool                     ShuffleGerudoCard                 { get; init; } = false;
        public ShuffleSongs             ShuffleSongs                      { get; init; } = ShuffleSongs.SongLocations;
        public bool                     ShuffleCows                       { get; init; } = false;
        public bool                     ShuffleBeans                      { get; init; } = false;
        public bool                     ShuffleMedigoronAndCarpetSalesman { get; init; } = false;
        public ShuffleInteriorEntrances ShuffleInteriorEntrances          { get; init; } = ShuffleInteriorEntrances.Off;
        public bool                     ShuffleGrottoEntrances            { get; init; } = false;
        public bool                     ShuffleDungeonEntrances           { get; init; } = false;
        public bool                     ShuffleOverworldEntrances         { get; init; } = false;
        public MixEntrancePools         MixEntrancePools                  { get; init; } = MixEntrancePools.Off;
        public bool                     DecoupleEntrances                 { get; init; } = false;
        public bool                     RandomizeOwlDrops                 { get; init; } = false;
        public bool                     RandomizeWarpSongDestinations     { get; init; } = false;
        public bool                     RandomizeSpawnLocations           { get; init; } = false;
        public ShuffleScrubs            ShuffleScrubs                     { get; init; } = ShuffleScrubs.Off;
        public Shopsanity               Shopsanity                        { get; init; } = Shopsanity.Off;
        public Tokensanity              Tokensanity                       { get; init; } = Tokensanity.Off;
        public ShuffleMapAndCompass     ShuffleMapAndCompass              { get; init; } = ShuffleMapAndCompass.Dungeon;
        public ShuffleKeys              ShuffleSmallKeys                  { get; init; } = ShuffleKeys.Dungeon;
        public ShuffleFortressKeys      ShuffleFortressKeys               { get; init; } = ShuffleFortressKeys.Vanilla;
        public ShuffleKeys              ShuffleBossKeys                   { get; init; } = ShuffleKeys.Dungeon;
        public ShuffleGanonBossKey      ShuffleGanonBossKey               { get; init; } = ShuffleGanonBossKey.Dungeon;
        public int                      LacsMedallions                    { get; init; } = 6;
        public int                      LacsStones                        { get; init; } = 3;
        public int                      LacsRewards                       { get; init; } = 9;
        public int                      LacsTokens                        { get; init; } = 100;
        public bool                     EnhanceMapAndCompass              { get; init; } = false;
        public bool                     MasterQuestRandom                 { get; init; } = false;
        public int                      MasterQuestDungeons               { get; init; } = 0;
        public string[]                 DisabledLocations                 { get; init; } = Array.Empty<string>();
        public string[]                 AllowedTricks                     { get; init; } = Array.Empty<string>();
        public string                   EarliestAdultTrade                { get; init; } = "Pocket Egg";
        public string                   LatestAdultTrade                  { get; init; } = "Claim Check";
        public string[]                 StartingEquipment                 { get; init; } = Array.Empty<string>();
        public string[]                 StartingItems                     { get; init; } = Array.Empty<string>();
        public string[]                 StartingSongs                     { get; init; } = Array.Empty<string>();
        public bool                     RandomizeOcarinaNotes             { get; init; } = false;
        public bool                     CorrectChestSizes                 { get; init; } = false;
        public bool                     ClearerHints                      { get; init; } = true;
        public bool                     HeroMode                          { get; init; } = false;
        public Hints                    Hints                             { get; init; } = Hints.Always;
        public string                   HintDistribution                  { get; init; } = "Balanced";
        public TextShuffle              TextShuffle                       { get; init; } = TextShuffle.None;
        public IceTrapAppearance        IceTrapAppearance                 { get; init; } = IceTrapAppearance.Major;
        public IceTraps                 IceTraps                          { get; init; } = IceTraps.Normal;
        public ItemPool                 ItemPool                          { get; init; } = ItemPool.Balanced;
        public DamageMultiplier         DamageMultiplier                  { get; init; } = DamageMultiplier.Normal;
        public StartingTimeOfDay        StartingTimeOfDay                 { get; init; } = StartingTimeOfDay.Default;
        public StartingAge              StartingAge                       { get; init; } = StartingAge.Child;

        // public string GenerateSettingsJson()
        // {
        //     var builder = new StringBuilder("{");
        //     
        //     // Required settings parameters:
        //     builder.Append($" \":version\": {Version}, ");
        //     builder.Append($" \"file_hash\": [{string.Join(',', FileHash)}], ");
        //     builder.Append($" \":seed\": {Seed}, ");
        //     builder.Append($" \":settings_string\": {SettingsString}, ");
        //     builder.Append($" \":enable_distribution_file\": {EnableDistributionFile.ToString().ToLower()}, ");
        //
        //     // Start normal settings.
        //     builder.Append("\"settings\": {");
        //     
        //     
        //
        //     return builder.ToString();
        // }
    }
}
