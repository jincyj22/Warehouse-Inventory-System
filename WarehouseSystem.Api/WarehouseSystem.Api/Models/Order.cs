namespace WarehouseSystem.Api.Models
{
    public enum OrderStatus { Placed, Picking, Packed, Shipped }
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public OrderStatus Status { get; set; } = OrderStatus.Placed;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
