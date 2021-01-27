namespace OcarinaMultiworld.Lib.Items
{
    public record Item
    {
        public string Name        { get; }
        public uint?  SendId      { get; }
        public uint?  InventoryId { get; }

        internal Item(string name, uint? sendId, uint? inventoryId)
        {
            Name = name;
            SendId = sendId;
            InventoryId = inventoryId;
        }
    }
}
