namespace OcarinaMultiworld.Lib.Items
{
    public record Item
    {
        public string Name        { get; }
        public byte?  SendId      { get; }
        public byte?  InventoryId { get; }

        internal Item(string name, byte? sendId, byte? inventoryId)
        {
            Name = name;
            SendId = sendId;
            InventoryId = inventoryId;
        }
    }
}
