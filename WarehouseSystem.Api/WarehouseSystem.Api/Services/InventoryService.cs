using Microsoft.EntityFrameworkCore;
using WarehouseSystem.Api.Data;
using WarehouseSystem.Api.DTOs;
using WarehouseSystem.Api.Models;

namespace WarehouseSystem.Api.Services;

public class InventoryService : IInventoryService
{
    private readonly WarehouseDbContext _context;

    public InventoryService(WarehouseDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InventoryRecordDto>> GetAllAsync()
    {
        return await _context.InventoryRecords
            .Select(r => new InventoryRecordDto
            {
                Id = r.Id,
                ProductId = r.ProductId,
                BinId = r.BinId,
                Quantity = r.Quantity
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<InventoryRecordDto>> GetByProductAsync(int productId)
    {
        return await _context.InventoryRecords
            .Where(r => r.ProductId == productId)
            .Select(r => new InventoryRecordDto
            {
                Id = r.Id,
                ProductId = r.ProductId,
                BinId = r.BinId,
                Quantity = r.Quantity
            })
            .ToListAsync();
    }

    public async Task<InventoryRecordDto?> RestockAsync(RestockDto dto)
    {
        if (dto.Quantity <= 0) return null;

        var productExists = await _context.Products.AnyAsync(p => p.Id == dto.ProductId);
        var binExists = await _context.Bins.AnyAsync(b => b.Id == dto.BinId);
        if (!productExists || !binExists) return null;

        // Find the existing record for this product in this bin, or create one
        var record = await _context.InventoryRecords
            .FirstOrDefaultAsync(r => r.ProductId == dto.ProductId && r.BinId == dto.BinId);

        if (record == null)
        {
            record = new InventoryRecord
            {
                ProductId = dto.ProductId,
                BinId = dto.BinId,
                Quantity = 0
            };
            _context.InventoryRecords.Add(record);
        }

        record.Quantity += dto.Quantity;

        // Audit trail: every stock change gets a movement row
        _context.StockMovements.Add(new StockMovement
        {
            ProductId = dto.ProductId,
            BinId = dto.BinId,
            QuantityChange = dto.Quantity,
            Reason = MovementReason.Restock
        });

        // One SaveChanges = one database transaction, so the quantity update
        // and the movement log either both succeed or both fail
        await _context.SaveChangesAsync();

        return new InventoryRecordDto
        {
            Id = record.Id,
            ProductId = record.ProductId,
            BinId = record.BinId,
            Quantity = record.Quantity
        };
    }
}
