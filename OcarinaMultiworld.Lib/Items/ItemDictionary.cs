using System.Collections.Generic;

using static OcarinaMultiworld.Lib.Items.ItemList;

namespace OcarinaMultiworld.Lib.Items
{
    public static class ItemDictionary
    {
        private static readonly Dictionary<byte, Item>   InventoryIdDict = GenerateInventoryIdDictionary();
        private static readonly Dictionary<byte, Item>   SendIdDict      = GenerateSendIdDictionary();
        private static readonly Dictionary<string, Item> NamedDict       = GenerateNamedDictionary();

        public static Item FetchByInventoryId(byte id)
        {
            if (InventoryIdDict.TryGetValue(id, out var item))
                return item;

            return Invalid;
        }
        
        public static Item FetchBySendId(byte id)
        {
            if (SendIdDict.TryGetValue(id, out var item))
                return item;

            return Invalid;
        }

        public static Item FetchByName(string name)
        {
            if (NamedDict.TryGetValue(name, out var item))
                return item;

            return Invalid;
        }

        private static Dictionary<byte, Item> GenerateInventoryIdDictionary()
        {
            var dict = new Dictionary<byte, Item>();
            var fields = typeof(ItemList).GetFields();
            
            foreach (var field in fields)
            {
                // Ignore non-items.
                if (field.FieldType != typeof(Item))
                    continue;

                var item = field.GetValue(null) as Item;
                
                // Ignore items with null inventory ids. (or is just null in general)
                if (item == null || item.InventoryId == null)
                    continue;
                
                dict.Add((byte) item.InventoryId, item);
            }

            return dict;
        }
        
        private static Dictionary<byte, Item> GenerateSendIdDictionary()
        {
            var dict = new Dictionary<byte, Item>();
            var fields = typeof(ItemList).GetFields();
            
            foreach (var field in fields)
            {
                // Ignore non-items.
                if (field.FieldType != typeof(Item))
                    continue;

                var item = field.GetValue(null) as Item;
                
                // Ignore items with null send ids. (or is just null in general)
                if (item == null || item.SendId == null)
                    continue;
                
                dict.Add((byte) item.SendId, item);
            }

            return dict;
        }
        
        private static Dictionary<string, Item> GenerateNamedDictionary()
        {
            var dict = new Dictionary<string, Item>();
            var fields = typeof(ItemList).GetFields();
            
            foreach (var field in fields)
            {
                // Ignore non-items.
                if (field.FieldType != typeof(Item))
                    continue;

                var item = field.GetValue(null) as Item;
                
                // Ignore null items. Unsure how this would happen in practice, but better safe than sorry.
                if (item == null)
                    continue;
                
                dict.Add(item.Name, item);
            }

            return dict;
        }
    }
}
