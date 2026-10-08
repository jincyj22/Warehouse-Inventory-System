using WarehouseSystem.Api.DTOs;

namespace WarehouseSystem.Api.Services;

public interface IInventoryService
{
    Task<IEnumerable<InventoryRecordDto>> GetAllAsync();
    Task<IEnumerable<InventoryRecordDto>> GetByProductAsync(int productId);
    Task<InventoryRecordDto?> RestockAsync(RestockDto dto);
}
