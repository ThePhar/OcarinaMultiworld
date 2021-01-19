﻿namespace OcarinaMultiworld.Lib
{
    public static class ItemList
    {
          public static readonly Item Empty                 = new("Empty",                                null, 0xFF);
          public static readonly Item Invalid               = new("Invalid Item",                         null, null);
          
          public static readonly Item BiggoronSword         = new("Biggoron Sword",                       0x57, null);
          public static readonly Item Boomerang             = new("Boomerang",                            0x06, 0x0E);
          public static readonly Item Bombchus              = new("Bombchus",                             0x89, 0x09);
          public static readonly Item BombBag               = new("Bomb Bag",                             0x82, null);
          public static readonly Item Bombs                 = new("Bombs",                                null, 0x02);
          public static readonly Item Bow                   = new("Bow",                                  0x83, 0x03);
          public static readonly Item DekuNuts              = new("Deku Nuts",                            null, 0x01);
          public static readonly Item DekuNutCapacity       = new("Deku Nut Capacity",                    0x87, null);
          public static readonly Item DekuShield            = new("Deku Shield",                          0x29, null);
          public static readonly Item DekuSticks            = new("Deku Sticks",                          null, 0x00);
          public static readonly Item DekuStickCapacity     = new("Deku Stick Capacity",                  0x88, null);
          public static readonly Item DinsFire              = new("Dins Fire",                            0x5C, 0x05);
          public static readonly Item DoubleDefense         = new("Double Defense",                       0xB8, null);
          public static readonly Item FaroresWind           = new("Farores Wind",                         0x5D, 0x0D);
          public static readonly Item FireArrows            = new("Fire Arrows",                          0x58, 0x04);
          public static readonly Item GiantsKnife           = new("Giants Knife",                         0x28, null);
          public static readonly Item GoronTunic            = new("Goron Tunic",                          0x2C, null);
          public static readonly Item HeartContainer        = new("Heart Container",                      0x3D, null);
          public static readonly Item HeartContainerBoss    = new("Heart Container (Boss)",               0x4F, null);
          public static readonly Item Hookshot              = new("Hookshot",                             null, 0x0A);
          public static readonly Item HoverBoots            = new("Hover Boots",                          0x2F, null);
          public static readonly Item HylianShield          = new("Hylian Shield",                        0x2A, null);
          public static readonly Item IceArrows             = new("Ice Arrows",                           0x59, 0x0C);
          public static readonly Item IronBoots             = new("Iron Boots",                           0x2E, null);
          public static readonly Item KokiriSword           = new("Kokiri Sword",                         0x27, null);
          public static readonly Item LensOfTruth           = new("Lens of Truth",                        0x0A, 0x0F);
          public static readonly Item LightArrows           = new("Light Arrows",                         0x5A, 0x12);
          public static readonly Item Longshot              = new("Longshot",                             null, 0x0B);
          public static readonly Item MagicBeanPack         = new("Magic Bean Pack",                      0xC9, null);
          public static readonly Item MagicMeter            = new("Magic Meter",                          0x8A, null);
          public static readonly Item MegatonHammer         = new("Megaton Hammer",                       0x0D, 0x11);
          public static readonly Item MirrorShield          = new("Mirror Shield",                        0x2B, null);
          public static readonly Item NayrusLove            = new("Nayrus Love",                          0x5E, 0x13);
          public static readonly Item Ocarina               = new("Ocarina",                              0x8B, null);
          public static readonly Item OcarinaFairy          = new("Fairy Ocarina",                        null, 0x07);
          public static readonly Item OcarinaOfTime         = new("Ocarina of Time",                      null, 0x08);
          public static readonly Item ProgressiveHookshot   = new("Progressive Hookshot",                 0x80, null);
          public static readonly Item ProgressiveScale      = new("Progressive Scale",                    0x86, null);
          public static readonly Item ProgressiveStrength   = new("Progressive Strength Upgrade",         0x81, null);
          public static readonly Item ProgressiveWallet     = new("Progressive Wallet",                   0x85, null);
          public static readonly Item Slingshot             = new("Slingshot",                            0x84, 0x06);
          public static readonly Item ZoraTunic             = new("Zora Tunic",                           0x2D, null);
          
          public static readonly Item BottleEmpty           = new("Bottle",                               0x0F, 0x14);
          public static readonly Item BottlePoe             = new("Bottle with Poe",                      0x94, 0x20);
          public static readonly Item BottleBigPoe          = new("Bottle with Big Poe",                  0x93, 0x1E);
          public static readonly Item BottleBlueFire        = new("Bottle with Blue Fire",                0x91, 0x1C);
          public static readonly Item BottleBluePotion      = new("Bottle with Blue Potion",              0x8E, 0x17);
          public static readonly Item BottleBugs            = new("Bottle with Bugs",                     0x92, 0x1D);
          public static readonly Item BottleGreenPotion     = new("Bottle with Green Potion",             0x8D, 0x16);
          public static readonly Item BottleRedPotion       = new("Bottle with Red Potion",               0x8C, 0x15);
          public static readonly Item BottleMilk            = new("Bottle with Milk",                     0x14, 0x1A);
          public static readonly Item BottleMilkHalf        = new("Bottle with Milk (Half)",              null, 0x1F);
          public static readonly Item BottleFairy           = new("Bottle with Fairy",                    0x8F, 0x18);
          public static readonly Item BottleFish            = new("Bottle with Fish",                     0x90, 0x19);
          public static readonly Item DeliverLetter         = new("Deliver Letter",                       null, null);
          public static readonly Item RutosLetter           = new("Rutos Letter",                         0x15, 0x1B);
          
          public static readonly Item WeirdEgg              = new("Weird Egg",                            0x47, 0x21);
          public static readonly Item Chicken               = new("Chicken",                              null, 0x22);
          public static readonly Item ZeldasLetter          = new("Zeldas Letter",                        0x0B, 0x23);
          public static readonly Item KeatonMask            = new("Keaton Mask",                          0x1A, 0x24);
          public static readonly Item SkullMask             = new("Skull Mask",                           0x17, 0x25);
          public static readonly Item SpookyMask            = new("Spooky Mask",                          0x18, 0x26);
          public static readonly Item BunnyHood             = new("Bunny Hood",                           0x1B, 0x27);
          public static readonly Item MaskOfTruth           = new("Mask of Truth",                        0x1C, 0x2B);
          public static readonly Item GoronMask             = new("Goron Mask",                           0x51, 0x28);
          public static readonly Item ZoraMask              = new("Zora Mask",                            0x52, 0x29);
          public static readonly Item GerudoMask            = new("Gerudo Mask",                          0x53, 0x2A);
          public static readonly Item SoldOut               = new("Sold Out",                             null, 0x2C);
          
          public static readonly Item PocketEgg             = new("Pocket Egg",                           0x1D, 0x2D);
          public static readonly Item PocketCucco           = new("Pocket Cucco",                         0x1E, 0x2E);
          public static readonly Item Cojiro                = new("Cojiro",                               0x0E, 0x2F);
          public static readonly Item OddMushroom           = new("Odd Mushroom",                         0x1F, 0x30);
          public static readonly Item OddPotion             = new("Odd Potion",                           0x20, 0x31);
          public static readonly Item PoachersSaw           = new("Poachers Saw",                         0x21, 0x32);
          public static readonly Item BrokenSword           = new("Broken Sword",                         0x22, 0x33);
          public static readonly Item Prescription          = new("Prescription",                         0x23, 0x34);
          public static readonly Item EyeballFrog           = new("Eyeball Frog",                         0x24, 0x35);
          public static readonly Item Eyedrops              = new("Eyedrops",                             0x25, 0x36);
          public static readonly Item ClaimCheck            = new("Claim Check",                          0x26, 0x37);
          
          public static readonly Item SongBolero            = new("Bolero of Fire",                       0xBC, null);
          public static readonly Item SongEponas            = new("Eponas Song",                          0xC2, null);
          public static readonly Item SongMinuet            = new("Minuet of Forest",                     0xBB, null);
          public static readonly Item SongNocturne          = new("Nocturne of Shadow",                   0xBF, null);
          public static readonly Item SongPrelude           = new("Prelude of Light",                     0xC0, null);
          public static readonly Item SongRequiem           = new("Requiem of Spirit",                    0xBE, null);
          public static readonly Item SongSarias            = new("Sarias Song",                          0xC3, null);
          public static readonly Item SongSerenade          = new("Serenade of Water",                    0xBD, null);
          public static readonly Item SongStorms            = new("Song of Storms",                       0xC6, null);
          public static readonly Item SongTime              = new("Song of Time",                         0xC5, null);
          public static readonly Item SongSuns              = new("Suns Song",                            0xC4, null);
          public static readonly Item SongLullaby           = new("Zeldas Lullaby",                       0xC1, null);
          
          public static readonly Item MembershipCard        = new("Gerudo Membership Card",               0x3A, null);
          public static readonly Item PieceOfHeartTreasure  = new("Piece of Heart (Treasure Chest Game)", 0x76, null);
          public static readonly Item PieceOfHeart          = new("Piece of Heart",                       0x3E, null);
          public static readonly Item SkulltulaToken        = new("Gold Skulltula Token",                 0x5B, null);
          public static readonly Item StoneOfAgony          = new("Stone of Agony",                       0x39, null);
          public static readonly Item TriforcePiece         = new("Triforce Piece",                       0xCA, null);
          
          public static readonly Item Arrows5               = new("Arrows (5)",                           0x49, null);
          public static readonly Item Arrows10              = new("Arrows (10)",                          0x4A, null);
          public static readonly Item Arrows30              = new("Arrows (30)",                          0x4B, null);
          public static readonly Item Bombchus5             = new("Bombchus (5)",                         0x6A, null);
          public static readonly Item Bombchus10            = new("Bombchus (10)",                        0x03, null);
          public static readonly Item Bombchus20            = new("Bombchus (20)",                        0x6B, null);
          public static readonly Item Bombs5                = new("Bombs (5)",                            0x01, null);
          public static readonly Item Bombs10               = new("Bombs (10)",                           0x66, null);
          public static readonly Item Bombs20               = new("Bombs (20)",                           0x67, null);
          public static readonly Item DekuNuts5             = new("Deku Nuts (5)",                        0x02, null);
          public static readonly Item DekuNuts10            = new("Deku Nuts (10)",                       0x64, null);
          public static readonly Item DekuSeeds30           = new("Deku Seeds (30)",                      0x69, null);
          public static readonly Item DekuStick1            = new("Deku Stick (1)",                       0x07, null);
          public static readonly Item RecoveryHeart         = new("Recovery Heart",                       0x48, null);
          public static readonly Item Rupee                 = new("Rupee (1)",                            0x4C, null);
          public static readonly Item RupeeTreasure         = new("Rupee (Treasure Chest Game)",          0x72, null);
          public static readonly Item Rupees5               = new("Rupees (5)",                           0x4D, null);
          public static readonly Item Rupees20              = new("Rupees (20)",                          0x4E, null);
          public static readonly Item Rupees50              = new("Rupees (50)",                          0x55, null);
          public static readonly Item Rupees200             = new("Rupees (200)",                         0x56, null);
          
          public static readonly Item BuyArrows10           = new("Buy Arrows (10)",                      null, null);
          public static readonly Item BuyArrows30           = new("Buy Arrows (30)",                      null, null);
          public static readonly Item BuyArrows50           = new("Buy Arrows (50)",                      null, null);
          public static readonly Item BuyBlueFire           = new("Buy Blue Fire",                        null, null);
          public static readonly Item BuyBombchu5           = new("Buy Bombchu (5)",                      null, null);
          public static readonly Item BuyBombchu10          = new("Buy Bombchu (10)",                     null, null);
          public static readonly Item BuyBombchu20          = new("Buy Bombchu (20)",                     null, null);
          public static readonly Item BuyBombs5C25          = new("Buy Bombs (5) [25]",                   null, null);
          public static readonly Item BuyBombs5C35          = new("Buy Bombs (5) [35]",                   null, null);
          public static readonly Item BuyBombs10            = new("Buy Bombs (10)",                       null, null);
          public static readonly Item BuyBombs20            = new("Buy Bombs (20)",                       null, null);
          public static readonly Item BuyBottleBug          = new("Buy Bottle Bug",                       null, null);
          public static readonly Item BuyDekuNut5           = new("Buy Deku Nut (5)",                     null, null);
          public static readonly Item BuyDekuNut10          = new("Buy Deku Nut (10)",                    null, null);
          public static readonly Item BuyDekuSeeds30        = new("Buy Deku Seeds (30)",                  null, null);
          public static readonly Item BuyDekuShield         = new("Buy Deku Shield",                      null, null);
          public static readonly Item BuyDekuStick          = new("Buy Deku Stick (1)",                   null, null);
          public static readonly Item BuyFairy              = new("Buy Fairy's Spirit",                   null, null);
          public static readonly Item BuyFish               = new("Buy Fish",                             null, null);
          public static readonly Item BuyGoronTunic         = new("Buy Goron Tunic",                      null, null);
          public static readonly Item BuyGreenPotion        = new("Buy Green Potion",                     null, null);
          public static readonly Item BuyHeart              = new("Buy Heart",                            null, null);
          public static readonly Item BuyHylianShield       = new("Buy Hylian Shield",                    null, null);
          public static readonly Item BuyPoe                = new("Buy Poe",                              null, null);
          public static readonly Item BuyRedPotionC30       = new("Buy Red Potion [30]",                  null, null);
          public static readonly Item BuyRedPotionC40       = new("Buy Red Potion [40]",                  null, null);
          public static readonly Item BuyRedPotionC50       = new("Buy Red Potion [50]",                  null, null);
          public static readonly Item BuyZoraTunic          = new("Buy Zora Tunic",                       null, null);
          
          public static readonly Item SmallKeyForest        = new("Small Key (Forest Temple)",            0xAF, null);
          public static readonly Item SmallKeyFire          = new("Small Key (Fire Temple)",              0xB0, null);
          public static readonly Item SmallKeyWater         = new("Small Key (Water Temple)",             0xB1, null);
          public static readonly Item SmallKeyShadow        = new("Small Key (Shadow Temple)",            0xB3, null);
          public static readonly Item SmallKeySpirit        = new("Small Key (Spirit Temple)",            0xB2, null);
          public static readonly Item SmallKeyBottomWell    = new("Small Key (Bottom of the Well)",       0xB4, null);
          public static readonly Item SmallKeyTraining      = new("Small Key (Gerudo Training Grounds)",  0xB5, null);
          public static readonly Item SmallKeyFortress      = new("Small Key (Gerudo Fortress)",          0xB6, null);
          public static readonly Item SmallKeyGanon         = new("Small Key (Ganons Castle)",            0xB7, null);
          public static readonly Item BossKeyForest         = new("Boss Key (Forest Temple)",             0x95, null);
          public static readonly Item BossKeyFire           = new("Boss Key (Fire Temple)",               0x96, null);
          public static readonly Item BossKeyWater          = new("Boss Key (Water Temple)",              0x97, null);
          public static readonly Item BossKeyShadow         = new("Boss Key (Shadow Temple)",             0x99, null);
          public static readonly Item BossKeySpirit         = new("Boss Key (Spirit Temple)",             0x98, null);
          public static readonly Item BossKeyGanon          = new("Boss Key (Ganons Castle)",             0x9A, null);
          public static readonly Item MapDekuTree           = new("Map (Deku Tree)",                      0xA5, null);
          public static readonly Item MapDodongosCavern     = new("Map (Dodongos Cavern)",                0xA6, null);
          public static readonly Item MapJabuJabusBelly     = new("Map (Jabu Jabus Belly)",               0xA7, null);
          public static readonly Item MapForest             = new("Map (Forest Temple)",                  0xA8, null);
          public static readonly Item MapFire               = new("Map (Fire Temple)",                    0xA9, null);
          public static readonly Item MapWater              = new("Map (Water Temple)",                   0xAA, null);
          public static readonly Item MapShadow             = new("Map (Shadow Temple)",                  0xAC, null);
          public static readonly Item MapSpirit             = new("Map (Spirit Temple)",                  0xAB, null);
          public static readonly Item MapBottomWell         = new("Map (Bottom of the Well)",             0xAD, null);
          public static readonly Item MapIceCavern          = new("Map (Ice Cavern)",                     0xAE, null);
          public static readonly Item CompassDekuTree       = new("Compass (Deku Tree)",                  0x9B, null);
          public static readonly Item CompassDodongosCavern = new("Compass (Dodongos Cavern)",            0x9C, null);
          public static readonly Item CompassJabuJabusBelly = new("Compass (Jabu Jabus Belly)",           0x9D, null);
          public static readonly Item CompassForest         = new("Compass (Forest Temple)",              0x9E, null);
          public static readonly Item CompassFire           = new("Compass (Fire Temple)",                0x9F, null);
          public static readonly Item CompassWater          = new("Compass (Water Temple)",               0xA0, null);
          public static readonly Item CompassShadow         = new("Compass (Shadow Temple)",              0xA2, null);
          public static readonly Item CompassSpirit         = new("Compass (Spirit Temple)",              0xA1, null);
          public static readonly Item CompassBottomWell     = new("Compass (Bottom of the Well)",         0xA3, null);
          public static readonly Item CompassIceCavern      = new("Compass (Ice Cavern)",                 0xA4, null);
          
          public static readonly Item KokiriEmerald         = new("Kokiri Emerald",                       null, null);
          public static readonly Item GoronRuby             = new("Goron Ruby",                           null, null);
          public static readonly Item ZoraSapphire          = new("Zora Sapphire",                        null, null);
          public static readonly Item LightMedallion        = new("LightMedallion",                       null, null);
          public static readonly Item ForestMedallion       = new("ForestMedallion",                      null, null);
          public static readonly Item FireMedallion         = new("FireMedallion",                        null, null);
          public static readonly Item WaterMedallion        = new("WaterMedallion",                       null, null);
          public static readonly Item ShadowMedallion       = new("ShadowMedallion",                      null, null);
          public static readonly Item SpiritMedallion       = new("SpiritMedallion",                      null, null);
          
          public static readonly Item Compass               = new("Compass",                              0x40, null);
          public static readonly Item Map                   = new("Map",                                  0x41, null);
          public static readonly Item SmallKey              = new("Small Key",                            0x42, null);
          public static readonly Item BossKey               = new("Boss Key",                             0x3F, null);
          public static readonly Item Milk                  = new("Milk",                                 0x50, null);
          public static readonly Item IceTrap               = new("Ice Trap",                             0x7C, null);
          public static readonly Item MagicBean             = new("Magic Bean",                           0x16, 0x10);
          public static readonly Item SellBigPoe            = new("Sell Big Poe",                         null, null);
    }
}
