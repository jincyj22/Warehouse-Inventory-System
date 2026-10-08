namespace WarehouseSystem.Api.Models
{
    public enum MovementReason { OrderFulfillment, Restock, Adjustment }
    public class StockMovement
    {
        public int Id { get; set; }
        public int QuantityChange { get; set; }
        public MovementReason Reason { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }

        public Bin Bin { get; set; } = null!;
        public int BinId { get; set; }
    }
}
