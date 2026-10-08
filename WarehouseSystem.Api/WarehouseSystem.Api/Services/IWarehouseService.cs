using WarehouseSystem.Api.DTOs;

namespace WarehouseSystem.Api.Services
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseDto>> GetAllAsync();
        Task<WarehouseDto?> GetByIdAsync(int id);
        Task<WarehouseDto> CreateAsync(CreateWarehouseDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
