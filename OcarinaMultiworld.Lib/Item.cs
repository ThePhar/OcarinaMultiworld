namespace OcarinaMultiworld.Lib
{
    public record Item
    {
        public string Name        { get; }
        public uint?  GiveId      { get; }
        public uint?  InventoryId { get; }

        public Item(string name, uint? giveId, uint? inventoryId)
        {
            Name = name;
            GiveId = giveId;
            InventoryId = inventoryId;
        }
    }
}
