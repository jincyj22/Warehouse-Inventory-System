namespace WarehouseSystem.Api.Models
{
    public class InventoryRecord
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int BinId { get; set; }
        public Bin Bin { get; set; } = null!;

    }
}
