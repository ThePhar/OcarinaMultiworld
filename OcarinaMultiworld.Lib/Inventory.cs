using System.Linq;
using System.Text;

namespace OcarinaMultiworld.Lib
{
    public class Inventory
    {
        public Item[] Slots { get; set; } = new Item[24]
        {
            ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty,
            ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty,
            ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty,
            ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty, ItemList.Empty,
        };

        public uint Rupees   { get; set; } = 0;
        public byte Arrows   { get; set; } = 0;
        public byte Beans    { get; set; } = 0;
        public byte Bombs    { get; set; } = 0;
        public byte Bombchus { get; set; } = 0;
        public byte Nuts     { get; set; } = 0;
        public byte Seeds    { get; set; } = 0;
        public byte Sticks   { get; set; } = 0;

        public bool HasItem(Item item) => Slots.Any(slot => slot.InventoryId == item.InventoryId);

        public string SlotsValues
        {
            get
            {
                var items = new StringBuilder();
                items.Append('\n');

                var index = 0;
                foreach (var item in Slots)
                {
                    items.AppendLine($"\t\t{index++}: {item.Name}");
                }

                return items.ToString();
            }
        }

        public override string ToString() => this.PropertyList(1);
    }
}
