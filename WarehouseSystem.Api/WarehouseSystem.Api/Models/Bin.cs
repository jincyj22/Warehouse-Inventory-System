namespace WarehouseSystem.Api.Models
{
    public class Bin
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public Warehouse Warehouse { get; set; } = null!;
        public int WarehouseId { get; set; }
        public ICollection<InventoryRecord> InventoryRecords { get; set; } = new List<InventoryRecord>();
    }
}
