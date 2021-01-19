using System.Linq;

namespace OcarinaMultiworld.Lib
{
    public class Inventory
    {
        public Item[] Slots = new Item[24]
        {
            ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty,
            ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty,
            ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty,
            ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty,
        };

        public uint Rupees   { get; init; } = 0;
        public byte Arrows   { get; init; } = 0;
        public byte Beans    { get; init; } = 0;
        public byte Bombs    { get; init; } = 0;
        public byte Bombchus { get; init; } = 0;
        public byte Nuts     { get; init; } = 0;
        public byte Sticks   { get; init; } = 0;

        public bool HasItem(Item item) => Slots.Any(slot => slot.InventoryId == item.InventoryId);
    }
}
