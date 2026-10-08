namespace WarehouseSystem.Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ReorderThreshold { get; set; }

        public ICollection<InventoryRecord> InventoryRecords { get; set; } = new List<InventoryRecord>();
    }
}
