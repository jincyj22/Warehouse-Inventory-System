using Microsoft.AspNetCore.Mvc;
using WarehouseSystem.Api.DTOs;
using WarehouseSystem.Api.Services;

namespace WarehouseSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InventoryRecordDto>>> GetAll()
    {
        return Ok(await _inventoryService.GetAllAsync());
    }

    [HttpGet("product/{productId}")]
    public async Task<ActionResult<IEnumerable<InventoryRecordDto>>> GetByProduct(int productId)
    {
        return Ok(await _inventoryService.GetByProductAsync(productId));
    }

    [HttpPost("restock")]
    public async Task<ActionResult<InventoryRecordDto>> Restock(RestockDto dto)
    {
        var result = await _inventoryService.RestockAsync(dto);
        if (result == null) return BadRequest("Invalid product, bin, or quantity.");
        return Ok(result);
    }
}
