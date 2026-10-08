namespace WarehouseSystem.Api.DTOs;

public class InventoryRecordDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int BinId { get; set; }
    public int Quantity { get; set; }
}

public class RestockDto
{
    public int ProductId { get; set; }
    public int BinId { get; set; }
    public int Quantity { get; set; }
}
