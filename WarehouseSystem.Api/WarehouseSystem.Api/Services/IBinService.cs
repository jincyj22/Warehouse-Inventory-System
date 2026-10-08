using WarehouseSystem.Api.DTOs;

namespace WarehouseSystem.Api.Services;

public interface IBinService
{
    Task<IEnumerable<BinDto>> GetAllAsync();
    Task<BinDto?> GetByIdAsync(int id);
    Task<BinDto?> CreateAsync(CreateBinDto dto);
    Task<bool> DeleteAsync(int id);
}
