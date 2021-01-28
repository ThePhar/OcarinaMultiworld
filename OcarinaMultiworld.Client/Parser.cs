using OcarinaMultiworld.Lib;
using OcarinaMultiworld.Lib.Items;
using OcarinaMultiworld.Lib.Locations;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OcarinaMultiworld.Client
{
    public static class Parser
    {
        public static bool TryUpdatePlayer(ref Player player, ListenServer server)
        {
            // ReSharper disable once ReplaceWithSingleAssignment.False
            var updated = false;

            if (TryUpdateInventory(ref player, server))     updated = true;
            if (TryUpdateQuestAndSongs(ref player, server)) updated = true;
            if (TryUpdateEquipment(ref player, server))     updated = true;
            if (TryUpdateDungeons(ref player, server))      updated = true;
            
            CheckLocations(ref player, server);

            return updated;
        }

        private static bool TryUpdateInventory(ref Player player, ListenServer server)
        {
            var updated = false;
            var inventory = player.Inventory;
            
            // Slotted items.
            var invRaw = server.ReadFromMemory(0x11A5D0 + 0x0074, 24);
            for (uint i = 0; i < 24; i++)
            {
                var itemCode = invRaw[i];

                // TODO: Move enumeration to ItemList function?
                var fields = typeof(ItemList).GetFields( BindingFlags.Static | BindingFlags.Public );
                foreach (var field in fields)
                {
                    var value = field.GetValue(null);

                    if (value is Item item)
                    {
                        if (item.InventoryId != itemCode)
                            continue;

                        if (inventory.Slots[i].InventoryId != itemCode)
                            updated = true;
                        
                        inventory.Slots[i] = item;
                        break;
                    }
                }
            }
            
            // Rupees
            var rupees = server.ReadFromMemory(0x11A5D0 + 0x0034, 2).GetShort();
            if (rupees != inventory.Rupees)
            {
                updated = true;
                inventory.Rupees = rupees;
            }
            
            // Amounts
            var amounts = server.ReadFromMemory(0x11A5D0 + 0x008C, 15);
            if (amounts[0] == 0xFF || amounts[0] != inventory.Sticks)   // Sticks 
            {
                updated = true;
                inventory.Sticks = amounts[0];
            }
            if (amounts[1] == 0xFF || amounts[1] != inventory.Nuts)     // Nuts 
            {
                updated = true;
                inventory.Nuts = amounts[1];
            }
            if (amounts[2] == 0xFF || amounts[2] != inventory.Bombs)    // Bombs 
            {
                updated = true;
                inventory.Bombs = amounts[2];
            }
            if (amounts[3] == 0xFF || amounts[3] != inventory.Arrows)   // Arrows 
            {
                updated = true;
                inventory.Arrows = amounts[3];
            }
            if (amounts[6] == 0xFF || amounts[6] != inventory.Seeds)    // Seeds 
            {
                updated = true;
                inventory.Seeds = amounts[6];
            }
            if (amounts[8] == 0xFF || amounts[8] != inventory.Bombchus) // Bombchus 
            {
                updated = true;
                inventory.Bombchus = amounts[8];
            }
            if (amounts[14] == 0xFF || amounts[14] != inventory.Beans)  // Beans 
            {
                updated = true;
                inventory.Beans = amounts[14];
            }
            
            return updated;
        }

        private static bool TryUpdateQuestAndSongs(ref Player player, ListenServer server)
        {
            var updated = false;
            var quest = player.Quest;
            var songs = player.Songs;

            var sram = server.ReadFromMemory(0x11A5D0 + 0x00A5, 3);
            var triforce = server.ReadFromMemory(0x11A5D0 + 0x08C6, 2).GetShort();
            var skulltulas = server.ReadFromMemory(0x11A5D0 + 0x00D0, 2).GetShort();

            quest.StoneOfAgony = sram[0].CheckMask(0x20);
            quest.GerudoCard = sram[0].CheckMask(0x40);
            quest.SkulltulaTokens = skulltulas;
            quest.TriforcePieces = triforce;
            
            // Songs
            songs.Lullaby  = sram[1].CheckMask(0x10);
            songs.Eponas   = sram[1].CheckMask(0x20);
            songs.Sarias   = sram[1].CheckMask(0x40);
            songs.Suns     = sram[1].CheckMask(0x80);
            songs.Time     = sram[0].CheckMask(0x01);
            songs.Storms   = sram[0].CheckMask(0x02);
            songs.Minuet   = sram[2].CheckMask(0x40);
            songs.Bolero   = sram[2].CheckMask(0x80);
            songs.Serenade = sram[1].CheckMask(0x01);
            songs.Requiem  = sram[1].CheckMask(0x02);
            songs.Nocturne = sram[1].CheckMask(0x04);
            songs.Prelude  = sram[1].CheckMask(0x08);
            
            // Medallions + Stones
            quest.Emerald  = sram[0].CheckMask(0x04);
            quest.Ruby     = sram[0].CheckMask(0x08);
            quest.Sapphire = sram[0].CheckMask(0x10);
            quest.Forest   = sram[2].CheckMask(0x01);
            quest.Fire     = sram[2].CheckMask(0x02);
            quest.Water    = sram[2].CheckMask(0x04);
            quest.Spirit   = sram[2].CheckMask(0x08);
            quest.Shadow   = sram[2].CheckMask(0x10);
            quest.Light    = sram[2].CheckMask(0x20);
            
            return updated;
        }

        private static bool TryUpdateEquipment(ref Player player, ListenServer server)
        {
            var updated = false;
            var equipment = player.Equipment;
            
            var equipRaw = server.ReadFromMemory(0x11A5D0 + 0x009C, 2);
            var accRaw = server.ReadFromMemory(0x11A5D0 + 0x00A1, 3);
            var magic = server.ReadFromMemory(0x11A5D0 + 0x0032)[0];
            
            // Swords
            equipment.KokiriSword   = equipRaw[1].CheckMask(0b0000_0001);
            equipment.MasterSword   = equipRaw[1].CheckMask(0b0000_0010);
            equipment.BiggoronSword = equipRaw[1].CheckMask(0b0000_0100);
            
            // Shields
            equipment.DekuShield   = equipRaw[1].CheckMask(0b0001_0000);
            equipment.HylianShield = equipRaw[1].CheckMask(0b0010_0000);
            equipment.MirrorShield = equipRaw[1].CheckMask(0b0100_0000);
            
            // Tunics
            equipment.KokiriTunic = equipRaw[0].CheckMask(0b0000_0001);
            equipment.GoronTunic  = equipRaw[0].CheckMask(0b0000_0010);
            equipment.ZoraTunic   = equipRaw[0].CheckMask(0b0000_1000);
            
            // Boots
            equipment.KokiriBoots = equipRaw[0].CheckMask(0b0001_0000);
            equipment.IronBoots   = equipRaw[0].CheckMask(0b0010_0000);
            equipment.HoverBoots  = equipRaw[0].CheckMask(0b0100_0000);
            
            // Stick Capacity
            equipment.SticksUpgrade =
                (accRaw[0].CheckMask(0x02) ? 1 : 0) +
                (accRaw[0].CheckMask(0x04) ? 2 : 0) +
                (accRaw[0].CheckMask(0x08) ? 3 : 0);
            
            // Nut Capacity
            equipment.NutsUpgrade =
                (accRaw[0].CheckMask(0x10) ? 1 : 0) +
                (accRaw[0].CheckMask(0x20) ? 2 : 0);
            
            // Scale Level
            equipment.ScaleLevel =
                (accRaw[1].CheckMask(0x02) ? 1 : 0) +
                (accRaw[1].CheckMask(0x04) ? 2 : 0);

            // Wallet Level
            equipment.WalletLevel =
                (accRaw[1].CheckMask(0x10) ? 1 : 0) +
                (accRaw[1].CheckMask(0x20) ? 2 : 0);
            
            // Seed Upgrade
            equipment.SeedBagUpgrade =
                (accRaw[1].CheckMask(0x40) ? 1 : 0) +
                (accRaw[1].CheckMask(0x80) ? 2 : 0);

            // Quiver Upgrade
            equipment.QuiverUpgrade =
                (accRaw[2].CheckMask(0x01) ? 1 : 0) +
                (accRaw[2].CheckMask(0x02) ? 2 : 0);
            
            // Bomb Bag Upgrade
            equipment.BombBagUpgrade =
                (accRaw[2].CheckMask(0x08) ? 1 : 0) +
                (accRaw[2].CheckMask(0x10) ? 2 : 0);
            
            // Strength Level
            equipment.StrengthLevel =
                (accRaw[2].CheckMask(0x40) ? 1 : 0) +
                (accRaw[2].CheckMask(0x80) ? 2 : 0);

            // Magic Level
            equipment.MagicLevel = magic;
            
            return updated;
        }

        private static bool TryUpdateDungeons(ref Player player, ListenServer server)
        {
            var updated = false;
            var keyrings = player.Keyrings;
            
            var flags= server.ReadFromMemory(0x11A5D0 + 0x00A8, 15);
            var keys = server.ReadFromMemory(0x11A5D0 + 0x00BC, 15);

            const byte maskBoss = 0x01;
            const byte maskCompass = 0x02;
            const byte maskMap = 0x04;
            
            // Deku Tree
            keyrings.DekuTree.Compass = flags[0x00].CheckMask(maskCompass);
            keyrings.DekuTree.Map     = flags[0x00].CheckMask(maskMap);
            
            // Dodongo's Cavern
            keyrings.DodongosCavern.Compass = flags[0x01].CheckMask(maskCompass);
            keyrings.DodongosCavern.Map     = flags[0x01].CheckMask(maskMap);

            // Jabu Jabu's Belly
            keyrings.JabuJabusBelly.Compass = flags[0x02].CheckMask(maskCompass);
            keyrings.JabuJabusBelly.Map     = flags[0x02].CheckMask(maskMap);

            // Bottom of the Well
            keyrings.BottomOfTheWell.Compass   = flags[0x08].CheckMask(maskCompass);
            keyrings.BottomOfTheWell.Map       = flags[0x08].CheckMask(maskMap);
            keyrings.BottomOfTheWell.SmallKeys =  keys[0x08];
            
            // Ice Cavern
            keyrings.IceCavern.Compass = flags[0x09].CheckMask(maskCompass);
            keyrings.IceCavern.Map     = flags[0x09].CheckMask(maskMap);
            
            // Gerudo Fortress
            keyrings.GerudoFortress.SmallKeys = keys[0x0C];
            
            // Gerudo Training Grounds
            keyrings.GerudoTrainingGrounds.SmallKeys = keys[0x0B];

            // Forest Temple
            keyrings.ForestTemple.BossKey   = flags[0x03].CheckMask(maskBoss);
            keyrings.ForestTemple.Compass   = flags[0x03].CheckMask(maskCompass);
            keyrings.ForestTemple.Map       = flags[0x03].CheckMask(maskMap);
            keyrings.ForestTemple.SmallKeys =  keys[0x03];
            
            // Fire Temple
            keyrings.FireTemple.BossKey   = flags[0x04].CheckMask(maskBoss);
            keyrings.FireTemple.Compass   = flags[0x04].CheckMask(maskCompass);
            keyrings.FireTemple.Map       = flags[0x04].CheckMask(maskMap);
            keyrings.FireTemple.SmallKeys =  keys[0x04];

            // Water Temple
            keyrings.WaterTemple.BossKey   = flags[0x05].CheckMask(maskBoss);
            keyrings.WaterTemple.Compass   = flags[0x05].CheckMask(maskCompass);
            keyrings.WaterTemple.Map       = flags[0x05].CheckMask(maskMap);
            keyrings.WaterTemple.SmallKeys =  keys[0x05];

            // Spirit Temple
            keyrings.SpiritTemple.BossKey   = flags[0x06].CheckMask(maskBoss);
            keyrings.SpiritTemple.Compass   = flags[0x06].CheckMask(maskCompass);
            keyrings.SpiritTemple.Map       = flags[0x06].CheckMask(maskMap);
            keyrings.SpiritTemple.SmallKeys =  keys[0x06];

            // Shadow Temple
            keyrings.ShadowTemple.BossKey   = flags[0x07].CheckMask(maskBoss);
            keyrings.ShadowTemple.Compass   = flags[0x07].CheckMask(maskCompass);
            keyrings.ShadowTemple.Map       = flags[0x07].CheckMask(maskMap);
            keyrings.ShadowTemple.SmallKeys =  keys[0x07];

            // Ganon's Castle
            keyrings.GanonsCastle.BossKey   = flags[0x0D].CheckMask(maskBoss);
            keyrings.GanonsCastle.SmallKeys =  keys[0x0D];

            return updated;
        }

        private static void CheckLocations(ref Player player, ListenServer server)
        {
            var checks = player.Locations;
            var sram = server.ReadFromMemory(0x11A5D0 + 0xD4, 101 * 0x1C);
            var scenes = new List<byte[]>();

            for (var i = 0; i < 101; i++)
            {
                var offset = i * 0x1C;
                scenes.Add(new []
                {
                    sram[offset],
                    sram[offset + 0x01],
                    sram[offset + 0x02],
                    sram[offset + 0x03],
                    sram[offset + 0x04],
                    sram[offset + 0x05],
                    sram[offset + 0x06],
                    sram[offset + 0x07],
                    sram[offset + 0x08],
                    sram[offset + 0x09],
                    sram[offset + 0x0A],
                    sram[offset + 0x0B],
                    sram[offset + 0x0C],
                    sram[offset + 0x0D],
                    sram[offset + 0x0E],
                    sram[offset + 0x0F],
                    sram[offset + 0x10],
                    sram[offset + 0x11],
                    sram[offset + 0x12],
                    sram[offset + 0x13],
                    sram[offset + 0x14],
                    sram[offset + 0x15],
                    sram[offset + 0x16],
                    sram[offset + 0x17],
                    sram[offset + 0x18],
                    sram[offset + 0x19],
                    sram[offset + 0x1A],
                    sram[offset + 0x1B],
                });
            }

            foreach (var check in checks)
            {
                // Console.WriteLine($"Checking {check.Location.Name}");
                
                switch (check.Location.Type)
                {
                    case LocationType.Chest:
                        if (check.Location.Scene == null || check.Location.Flag == null) continue;
                        
                        var scene = scenes[(int) check.Location.Scene].GetInt();
                        if ((scene & (1 << check.Location.Flag)) != 0)
                        {
                            check.CheckLocation(-2, checks.Count);
                        }

                        break;
                }
            }
        }
        
        public static bool IsStateSafeToUpdate(ListenServer server)
        {
            return GetGamemode(server) switch
            {
                Gamemode.Unknown        => false,
                Gamemode.N64Logo        => false,
                Gamemode.TitleScreen    => false,
                Gamemode.FileSelect     => false,
                Gamemode.NormalGameplay => true,
                Gamemode.Cutscene       => true,
                Gamemode.Paused         => true,
                Gamemode.Dying          => false,
                Gamemode.DyingMenuStart => false,
                Gamemode.Dead           => false,
                _                       => false,
            };
        }

        private static Gamemode GetGamemode(ListenServer server)
        {
            Gamemode gamemode;

            // I pretty much just stole what was in the original bizhawk file because heck if I'm calculating all this manually.
            // Mad props to TestRunnerSRL. <3
            
            var main = server.ReadFromMemory(0x11B92F)[0];
            var sub = server.ReadFromMemory(0x11B933)[0];
            var menu = server.ReadFromMemory(0x1D8DD5)[0];
            var logo = server.ReadFromMemory(0x11F200, 4).GetInt();
            var status = server.ReadFromMemory(0x1DB09C)[0];
            var health= server.ReadFromMemory(0x11A600, 2).GetShort();
            var save = server.ReadFromMemory(0x11B927)[0];
            
            // N64 Logo
            if (logo == 0x802C5880 || logo == 0x00000000)
                gamemode = Gamemode.N64Logo;
            
            // Main State Check
            else if (main == 1)
                gamemode = Gamemode.TitleScreen;
            else if (main == 2)
                gamemode = Gamemode.FileSelect;
            
            // Main Menu State Check
            else if (menu == 0)
            {
                // Make sure we're loaded in our save and not, say... the TITLE SCREEN.
                if (save == 0xFF)
                    gamemode = Gamemode.Unknown;
                
                else if ((status & 0x27) == 0x27 || health <= 0)
                    gamemode = Gamemode.Dying;
                else if (sub == 4)
                    gamemode = Gamemode.Cutscene;
                else
                    gamemode = Gamemode.NormalGameplay;
            }

            // Alternative Menu States
            else if (0 < menu && menu < 9 || menu == 13)
                gamemode = Gamemode.Paused;
            else if (menu == 9 || menu == 11)
                gamemode = Gamemode.DyingMenuStart;
            else
                gamemode = Gamemode.Dead;

            return gamemode;
        }
        
        private static bool CheckMask(this byte b, byte mask) => (b & mask) != 0;
        
        private static ushort GetShort(this byte[] sram, int index = 0) => (ushort) (sram[index] << 8 | sram[index + 1]);

        private static uint GetInt(this byte[] sram, int index = 0) => 
            (uint) (GetShort(new[] { sram[index], sram[index + 1] }) << 16 | GetShort(new[] { sram[index + 2], sram[index + 3] }));
    }
}
