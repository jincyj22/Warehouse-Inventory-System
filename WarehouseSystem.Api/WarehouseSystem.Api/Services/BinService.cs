using Microsoft.EntityFrameworkCore;
using WarehouseSystem.Api.Data;
using WarehouseSystem.Api.DTOs;
using WarehouseSystem.Api.Models;

namespace WarehouseSystem.Api.Services;

public class BinService : IBinService
{
    private readonly WarehouseDbContext _context;

    public BinService(WarehouseDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BinDto>> GetAllAsync()
    {
        return await _context.Bins
            .Select(b => new BinDto { Id = b.Id, Code = b.Code, Capacity = b.Capacity, WarehouseId = b.WarehouseId })
            .ToListAsync();
    }

    public async Task<BinDto?> GetByIdAsync(int id)
    {
        var bin = await _context.Bins.FindAsync(id);
        if (bin == null) return null;

        return new BinDto { Id = bin.Id, Code = bin.Code, Capacity = bin.Capacity, WarehouseId = bin.WarehouseId };
    }

    public async Task<BinDto?> CreateAsync(CreateBinDto dto)
    {
        // Validate the warehouse actually exists before creating the bin
        var warehouseExists = await _context.Warehouses.AnyAsync(w => w.Id == dto.WarehouseId);
        if (!warehouseExists) return null;

        var bin = new Bin { Code = dto.Code, Capacity = dto.Capacity, WarehouseId = dto.WarehouseId };

        _context.Bins.Add(bin);
        await _context.SaveChangesAsync();

        return new BinDto { Id = bin.Id, Code = bin.Code, Capacity = bin.Capacity, WarehouseId = bin.WarehouseId };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var bin = await _context.Bins.FindAsync(id);
        if (bin == null) return false;

        _context.Bins.Remove(bin);
        await _context.SaveChangesAsync();
        return true;
    }
}
