namespace WarehouseSystem.Api.DTOs;

public class BinDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int WarehouseId { get; set; }
}

public class CreateBinDto
{
    public string Code { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int WarehouseId { get; set; }
}
