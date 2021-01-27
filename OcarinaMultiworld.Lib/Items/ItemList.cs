namespace OcarinaMultiworld.Lib.Items
{
    public static class ItemList
    {
        // Meta Items
        public static readonly Item Empty               = new(ItemName.Empty,               null, 0xFF);
        public static readonly Item Invalid             = new(ItemName.Invalid,             null, null);

        // Equipment and Inventory Items (Excluding Bottles and Trade Sequence Items)
        public static readonly Item BiggoronSword       = new(ItemName.BiggoronSword,       0x57, null);
        public static readonly Item Boomerang           = new(ItemName.Boomerang,           0x06, 0x0E);
        public static readonly Item Bombchus            = new(ItemName.Bombchus,            0x89, 0x09);
        public static readonly Item BombBag             = new(ItemName.BombBag,             0x82, null);
        public static readonly Item Bombs               = new(ItemName.Bombs,               null, 0x02);
        public static readonly Item Bow                 = new(ItemName.Bow,                 0x83, 0x03);
        public static readonly Item DekuNutCapacity     = new(ItemName.DekuNutCapacity,     0x87, null);
        public static readonly Item DekuNuts            = new(ItemName.DekuNuts,            null, 0x01);
        public static readonly Item DekuShield          = new(ItemName.DekuShield,          0x29, null);
        public static readonly Item DekuStickCapacity   = new(ItemName.DekuStickCapacity,   0x88, null);
        public static readonly Item DekuSticks          = new(ItemName.DekuSticks,          null, 0x00);
        public static readonly Item DinsFire            = new(ItemName.DinsFire,            0x5C, 0x05);
        public static readonly Item DoubleDefense       = new(ItemName.DoubleDefense,       0xB8, null);
        public static readonly Item FaroresWind         = new(ItemName.FaroresWind,         0x5D, 0x0D);
        public static readonly Item FireArrows          = new(ItemName.FireArrows,          0x58, 0x04);
        public static readonly Item GiantsKnife         = new(ItemName.GiantsKnife,         0x28, null);
        public static readonly Item GoronTunic          = new(ItemName.GoronTunic,          0x2C, null);
        public static readonly Item Hookshot            = new(ItemName.Hookshot,            null, 0x0A);
        public static readonly Item HoverBoots          = new(ItemName.HoverBoots,          0x2F, null);
        public static readonly Item HylianShield        = new(ItemName.HylianShield,        0x2A, null);
        public static readonly Item IceArrows           = new(ItemName.IceArrows,           0x59, 0x0C);
        public static readonly Item IronBoots           = new(ItemName.IronBoots,           0x2E, null);
        public static readonly Item KokiriSword         = new(ItemName.KokiriSword,         0x27, null);
        public static readonly Item LensOfTruth         = new(ItemName.LensOfTruth,         0x0A, 0x0F);
        public static readonly Item LightArrows         = new(ItemName.LightArrows,         0x5A, 0x12);
        public static readonly Item Longshot            = new(ItemName.Longshot,            null, 0x0B);
        public static readonly Item MagicBeanPack       = new(ItemName.MagicBeanPack,       0xC9, null);
        public static readonly Item MagicMeter          = new(ItemName.MagicMeter,          0x8A, null);
        public static readonly Item MegatonHammer       = new(ItemName.MegatonHammer,       0x0D, 0x11);
        public static readonly Item MirrorShield        = new(ItemName.MirrorShield,        0x2B, null);
        public static readonly Item NayrusLove          = new(ItemName.NayrusLove,          0x5E, 0x13);
        public static readonly Item Ocarina             = new(ItemName.Ocarina,             0x8B, null);
        public static readonly Item OcarinaFairy        = new(ItemName.OcarinaFairy,        null, 0x07);
        public static readonly Item OcarinaTime         = new(ItemName.OcarinaTime,         null, 0x08);
        public static readonly Item ProgressiveHookshot = new(ItemName.ProgressiveHookshot, 0x80, null);
        public static readonly Item ProgressiveScale    = new(ItemName.ProgressiveScale,    0x86, null);
        public static readonly Item ProgressiveStrength = new(ItemName.ProgressiveStrength, 0x81, null);
        public static readonly Item ProgressiveWallet   = new(ItemName.ProgressiveWallet,   0x85, null);
        public static readonly Item Slingshot           = new(ItemName.Slingshot,           0x84, 0x06);
        public static readonly Item ZoraTunic           = new(ItemName.ZoraTunic,           0x2D, null);

        // Bottles
        public static readonly Item BottleEmpty         = new(ItemName.BottleEmpty,         0x0F, 0x14);
        public static readonly Item BottleBigPoe        = new(ItemName.BottleBigPoe,        0x93, 0x1E);
        public static readonly Item BottleBlueFire      = new(ItemName.BottleBlueFire,      0x91, 0x1C);
        public static readonly Item BottleBluePotion    = new(ItemName.BottleBluePotion,    0x8E, 0x17);
        public static readonly Item BottleBugs          = new(ItemName.BottleBugs,          0x92, 0x1D);
        public static readonly Item BottleFairy         = new(ItemName.BottleFairy,         0x8F, 0x18);
        public static readonly Item BottleFish          = new(ItemName.BottleFish,          0x90, 0x19);
        public static readonly Item BottleGreenPotion   = new(ItemName.BottleGreenPotion,   0x8D, 0x16);
        public static readonly Item BottleMilk          = new(ItemName.BottleMilk,          0x14, 0x1A);
        public static readonly Item BottleMilkHalf      = new(ItemName.BottleMilkHalf,      null, 0x1F);
        public static readonly Item BottlePoe           = new(ItemName.BottlePoe,           0x94, 0x20);
        public static readonly Item BottleRedPotion     = new(ItemName.BottleRedPotion,     0x8C, 0x15);
        public static readonly Item BottleRutosLetter   = new(ItemName.BottleRutosLetter,   0x15, 0x1B);

        // Child Trading Sequence
        public static readonly Item WeirdEgg            = new(ItemName.WeirdEgg,            0x47, 0x21);
        public static readonly Item Chicken             = new(ItemName.Chicken,             null, 0x22);
        public static readonly Item ZeldasLetter        = new(ItemName.ZeldasLetter,        0x0B, 0x23);
        public static readonly Item MaskKeaton          = new(ItemName.MaskKeaton,          0x1A, 0x24);
        public static readonly Item MaskSkull           = new(ItemName.MaskSkull,           0x17, 0x25);
        public static readonly Item MaskSpooky          = new(ItemName.MaskSpooky,          0x18, 0x26);
        public static readonly Item MaskBunny           = new(ItemName.MaskBunny,           0x1B, 0x27);
        public static readonly Item MaskTruth           = new(ItemName.MaskTruth,           0x1C, 0x2B);
        public static readonly Item MaskGoron           = new(ItemName.MaskGoron,           0x51, 0x28);
        public static readonly Item MaskZora            = new(ItemName.MaskZora,            0x52, 0x29);
        public static readonly Item MaskGerudo          = new(ItemName.MaskGerudo,          0x53, 0x2A);
        public static readonly Item SoldOut             = new(ItemName.SoldOut,             null, 0x2C);

        // Adult Trading Sequence
        public static readonly Item PocketEgg           = new(ItemName.PocketEgg,           0x1D, 0x2D);
        public static readonly Item PocketCucco         = new(ItemName.PocketCucco,         0x1E, 0x2E);
        public static readonly Item Cojiro              = new(ItemName.Cojiro,              0x0E, 0x2F);
        public static readonly Item OddMushroom         = new(ItemName.OddMushroom,         0x1F, 0x30);
        public static readonly Item OddPotion           = new(ItemName.OddPotion,           0x20, 0x31);
        public static readonly Item PoachersSaw         = new(ItemName.PoachersSaw,         0x21, 0x32);
        public static readonly Item BrokenSword         = new(ItemName.BrokenSword,         0x22, 0x33);
        public static readonly Item Prescription        = new(ItemName.Prescription,        0x23, 0x34);
        public static readonly Item EyeballFrog         = new(ItemName.EyeballFrog,         0x24, 0x35);
        public static readonly Item Eyedrops            = new(ItemName.Eyedrops,            0x25, 0x36);
        public static readonly Item ClaimCheck          = new(ItemName.ClaimCheck,          0x26, 0x37);

        // Songs
        public static readonly Item SongLullaby         = new(ItemName.SongLullaby,         0xC1, null);
        public static readonly Item SongSarias          = new(ItemName.SongSarias,          0xC3, null);
        public static readonly Item SongEponas          = new(ItemName.SongEponas,          0xC2, null);
        public static readonly Item SongSuns            = new(ItemName.SongSuns,            0xC4, null);
        public static readonly Item SongTime            = new(ItemName.SongTime,            0xC5, null);
        public static readonly Item SongStorms          = new(ItemName.SongStorms,          0xC6, null);
        public static readonly Item SongMinuet          = new(ItemName.SongMinuet,          0xBB, null);
        public static readonly Item SongBolero          = new(ItemName.SongBolero,          0xBC, null);
        public static readonly Item SongSerenade        = new(ItemName.SongSerenade,        0xBD, null);
        public static readonly Item SongRequiem         = new(ItemName.SongRequiem,         0xBE, null);
        public static readonly Item SongNocturne        = new(ItemName.SongNocturne,        0xBF, null);
        public static readonly Item SongPrelude         = new(ItemName.SongPrelude,         0xC0, null);

        // Quest Items and Permanent Link Upgrades
        public static readonly Item HeartContainer      = new(ItemName.HeartContainer,      0x3D, null);
        public static readonly Item HeartContainerBoss  = new(ItemName.HeartContainerBoss,  0x4F, null);
        public static readonly Item HeartPiece          = new(ItemName.HeartPiece,          0x3E, null);
        public static readonly Item HeartPieceTreasure  = new(ItemName.HeartPieceTreasure,  0x76, null);
        public static readonly Item MembershipCard      = new(ItemName.MembershipCard,      0x3A, null);
        public static readonly Item SkulltulaToken      = new(ItemName.SkulltulaToken,      0x5B, null);
        public static readonly Item StoneOfAgony        = new(ItemName.StoneOfAgony,        0x39, null);
        public static readonly Item TriforcePiece       = new(ItemName.TriforcePiece,       0xCA, null);

        // Consumables
        public static readonly Item Arrows5             = new(ItemName.Arrows5,             0x49, null);
        public static readonly Item Arrows10            = new(ItemName.Arrows10,            0x4A, null);
        public static readonly Item Arrows30            = new(ItemName.Arrows30,            0x4B, null);
        public static readonly Item Bombchus5           = new(ItemName.Bombchus5,           0x6A, null);
        public static readonly Item Bombchus10          = new(ItemName.Bombchus10,          0x03, null);
        public static readonly Item Bombchus20          = new(ItemName.Bombchus20,          0x6B, null);
        public static readonly Item Bombs5              = new(ItemName.Bombs5,              0x01, null);
        public static readonly Item Bombs10             = new(ItemName.Bombs10,             0x66, null);
        public static readonly Item Bombs20             = new(ItemName.Bombs20,             0x67, null);
        public static readonly Item DekuNuts5           = new(ItemName.DekuNuts5,           0x02, null);
        public static readonly Item DekuNuts10          = new(ItemName.DekuNuts10,          0x64, null);
        public static readonly Item DekuSeeds30         = new(ItemName.DekuSeeds30,         0x69, null);
        public static readonly Item DekuSticks1         = new(ItemName.DekuSticks1,         0x07, null);
        public static readonly Item RecoveryHeart       = new(ItemName.RecoveryHeart,       0x48, null);
        public static readonly Item RupeeTreasure       = new(ItemName.RupeeTreasure,       0x72, null);
        public static readonly Item Rupees1             = new(ItemName.Rupees1,             0x4C, null);
        public static readonly Item Rupees5             = new(ItemName.Rupees5,             0x4D, null);
        public static readonly Item Rupees20            = new(ItemName.Rupees20,            0x4E, null);
        public static readonly Item Rupees50            = new(ItemName.Rupees50,            0x55, null);
        public static readonly Item Rupees200           = new(ItemName.Rupees200,           0x56, null);

        // Purchasable Items
        public static readonly Item BuyArrows10         = new(ItemName.BuyArrows10,         null, null);
        public static readonly Item BuyArrows30         = new(ItemName.BuyArrows30,         null, null);
        public static readonly Item BuyArrows50         = new(ItemName.BuyArrows50,         null, null);
        public static readonly Item BuyBlueFire         = new(ItemName.BuyBlueFire,         null, null);
        public static readonly Item BuyBombchus5        = new(ItemName.BuyBombchus5,        null, null);
        public static readonly Item BuyBombchus10       = new(ItemName.BuyBombchus10,       null, null);
        public static readonly Item BuyBombchus20       = new(ItemName.BuyBombchus20,       null, null);
        public static readonly Item BuyBombs5C25        = new(ItemName.BuyBombs5C25,        null, null);
        public static readonly Item BuyBombs5C35        = new(ItemName.BuyBombs5C35,        null, null);
        public static readonly Item BuyBombs10          = new(ItemName.BuyBombs10,          null, null);
        public static readonly Item BuyBombs20          = new(ItemName.BuyBombs20,          null, null);
        public static readonly Item BuyBottleBugs       = new(ItemName.BuyBottleBugs,       null, null);
        public static readonly Item BuyDekuNuts5        = new(ItemName.BuyDekuNuts5,        null, null);
        public static readonly Item BuyDekuNuts10       = new(ItemName.BuyDekuNuts10,       null, null);
        public static readonly Item BuyDekuSeeds30      = new(ItemName.BuyDekuSeeds30,      null, null);
        public static readonly Item BuyDekuShield       = new(ItemName.BuyDekuShield,       null, null);
        public static readonly Item BuyDekuSticks1      = new(ItemName.BuyDekuSticks1,      null, null);
        public static readonly Item BuyFairy            = new(ItemName.BuyFairy,            null, null);
        public static readonly Item BuyFish             = new(ItemName.BuyFish,             null, null);
        public static readonly Item BuyGoronTunic       = new(ItemName.BuyGoronTunic,       null, null);
        public static readonly Item BuyGreenPotion      = new(ItemName.BuyGreenPotion,      null, null);
        public static readonly Item BuyHeart            = new(ItemName.BuyHeart,            null, null);
        public static readonly Item BuyHylianShield     = new(ItemName.BuyHylianShield,     null, null);
        public static readonly Item BuyPoe              = new(ItemName.BuyPoe,              null, null);
        public static readonly Item BuyRedPotionC30     = new(ItemName.BuyRedPotionC30,     null, null);
        public static readonly Item BuyRedPotionC40     = new(ItemName.BuyRedPotionC40,     null, null);
        public static readonly Item BuyRedPotionC50     = new(ItemName.BuyRedPotionC50,     null, null);
        public static readonly Item BuyZoraTunic        = new(ItemName.BuyZoraTunic,        null, null);

        // Dungeon Items
        public static readonly Item BossKey             = new(ItemName.BossKey,             0x3F, null);
        public static readonly Item BossKeyForest       = new(ItemName.BossKeyForest,       0x95, null);
        public static readonly Item BossKeyFire         = new(ItemName.BossKeyFire,         0x96, null);
        public static readonly Item BossKeyWater        = new(ItemName.BossKeyWater,        0x97, null);
        public static readonly Item BossKeySpirit       = new(ItemName.BossKeySpirit,       0x98, null);
        public static readonly Item BossKeyShadow       = new(ItemName.BossKeyShadow,       0x99, null);
        public static readonly Item BossKeyGanon        = new(ItemName.BossKeyGanon,        0x9A, null);

        public static readonly Item Compass             = new(ItemName.Compass,             0x40, null);
        public static readonly Item CompassDeku         = new(ItemName.CompassDeku,         0x9B, null);
        public static readonly Item CompassDodongo      = new(ItemName.CompassDodongo,      0x9C, null);
        public static readonly Item CompassJabu         = new(ItemName.CompassJabu,         0x9D, null);
        public static readonly Item CompassForest       = new(ItemName.CompassForest,       0x9E, null);
        public static readonly Item CompassFire         = new(ItemName.CompassFire,         0x9F, null);
        public static readonly Item CompassWater        = new(ItemName.CompassWater,        0xA0, null);
        public static readonly Item CompassSpirit       = new(ItemName.CompassSpirit,       0xA1, null);
        public static readonly Item CompassShadow       = new(ItemName.CompassShadow,       0xA2, null);
        public static readonly Item CompassWell         = new(ItemName.CompassWell,         0xA3, null);
        public static readonly Item CompassIceCavern    = new(ItemName.CompassIceCavern,    0xA4, null);

        public static readonly Item Map                 = new(ItemName.Map,                 0x41, null);
        public static readonly Item MapDeku             = new(ItemName.MapDeku,             0xA5, null);
        public static readonly Item MapDodongo          = new(ItemName.MapDodongo,          0xA6, null);
        public static readonly Item MapJabu             = new(ItemName.MapJabu,             0xA7, null);
        public static readonly Item MapForest           = new(ItemName.MapForest,           0xA8, null);
        public static readonly Item MapFire             = new(ItemName.MapFire,             0xA9, null);
        public static readonly Item MapWater            = new(ItemName.MapWater,            0xAA, null);
        public static readonly Item MapSpirit           = new(ItemName.MapSpirit,           0xAB, null);
        public static readonly Item MapShadow           = new(ItemName.MapShadow,           0xAC, null);
        public static readonly Item MapWell             = new(ItemName.MapWell,             0xAD, null);
        public static readonly Item MapIceCavern        = new(ItemName.MapIceCavern,        0xAE, null);

        public static readonly Item SmallKey            = new(ItemName.SmallKey,            0x42, null);
        public static readonly Item SmallKeyForest      = new(ItemName.SmallKeyForest,      0xAF, null);
        public static readonly Item SmallKeyFire        = new(ItemName.SmallKeyFire,        0xB0, null);
        public static readonly Item SmallKeyWater       = new(ItemName.SmallKeyWater,       0xB1, null);
        public static readonly Item SmallKeySpirit      = new(ItemName.SmallKeySpirit,      0xB2, null);
        public static readonly Item SmallKeyShadow      = new(ItemName.SmallKeyShadow,      0xB3, null);
        public static readonly Item SmallKeyWell        = new(ItemName.SmallKeyWell,        0xB4, null);
        public static readonly Item SmallKeyTraining    = new(ItemName.SmallKeyTraining,    0xB5, null);
        public static readonly Item SmallKeyFortress    = new(ItemName.SmallKeyFortress,    0xB6, null);
        public static readonly Item SmallKeyGanon       = new(ItemName.SmallKeyGanon,       0xB7, null);

        // Dungeon Rewards
        public static readonly Item KokiriEmerald       = new(ItemName.KokiriEmerald,       null, null);
        public static readonly Item GoronRuby           = new(ItemName.GoronRuby,           null, null);
        public static readonly Item ZoraSapphire        = new(ItemName.ZoraSapphire,        null, null);
        public static readonly Item LightMedallion      = new(ItemName.LightMedallion,      null, null);
        public static readonly Item ForestMedallion     = new(ItemName.ForestMedallion,     null, null);
        public static readonly Item FireMedallion       = new(ItemName.FireMedallion,       null, null);
        public static readonly Item WaterMedallion      = new(ItemName.WaterMedallion,      null, null);
        public static readonly Item SpiritMedallion     = new(ItemName.SpiritMedallion,     null, null);
        public static readonly Item ShadowMedallion     = new(ItemName.ShadowMedallion,     null, null);

        // Misc.
        public static readonly Item Milk                = new(ItemName.Milk,                0x50, null);
        public static readonly Item IceTrap             = new(ItemName.IceTrap,             0x7C, null);
        public static readonly Item MagicBeans          = new(ItemName.MagicBeans,          0x16, 0x10);
        public static readonly Item SellBigPoe          = new(ItemName.SellBigPoe,          null, null);
        public static readonly Item DeliverLetter       = new(ItemName.DeliverLetter,       null, null);

        /// <summary>
        /// Returns true or false if the following item is a bottle.
        /// </summary>
        /// <param name="item">Item to check.</param>
        /// <param name="allowLetter">Determine if Ruto's Letter counts as a bottle for this check. Defaults to false.</param>
        /// <returns>True or false if item is a bottle.</returns>
        public static bool IsBottle(Item item, bool allowLetter = false)
        {
            switch (item.Name)
            {
                case ItemName.BottleEmpty:
                case ItemName.BottleBigPoe:
                case ItemName.BottleBlueFire:
                case ItemName.BottleBluePotion:
                case ItemName.BottleBugs:
                case ItemName.BottleFairy:
                case ItemName.BottleFish:
                case ItemName.BottleGreenPotion:
                case ItemName.BottleMilk:
                case ItemName.BottleMilkHalf:
                case ItemName.BottlePoe:
                case ItemName.BottleRedPotion:
                    return true;

                case ItemName.BottleRutosLetter:
                    return allowLetter;

                default:
                    return false;
            }
        }
    }
}
