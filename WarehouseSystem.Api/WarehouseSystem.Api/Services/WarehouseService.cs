using Microsoft.EntityFrameworkCore;
using WarehouseSystem.Api.Data;
using WarehouseSystem.Api.DTOs;
using WarehouseSystem.Api.Models;

namespace WarehouseSystem.Api.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly WarehouseDbContext _context;

        public WarehouseService(WarehouseDbContext context)
        {
            _context = context;
        }
        public async Task<WarehouseDto> CreateAsync(CreateWarehouseDto dto)
        {
            var warehouse = new Warehouse { Name = dto.Name , Address = dto.Address};

            _context.Warehouses.Add(warehouse);
            await _context.SaveChangesAsync();

            return new WarehouseDto { Id = warehouse.Id, Address = warehouse.Address, Name = warehouse.Name };

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null) return false;

            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllAsync()
        {
            return await _context.Warehouses.Select(x => new WarehouseDto { Id = x.Id, Address = x.Address, Name= x.Name })
                .ToListAsync();
        }

        public async Task<WarehouseDto?> GetByIdAsync(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null) return null;

            return new WarehouseDto { Id = warehouse.Id, Address = warehouse.Address, Name = warehouse.Name };
        }
    }
}
