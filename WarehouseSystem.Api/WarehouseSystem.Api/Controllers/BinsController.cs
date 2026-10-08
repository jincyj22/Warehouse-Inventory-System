using Microsoft.AspNetCore.Mvc;
using WarehouseSystem.Api.DTOs;
using WarehouseSystem.Api.Services;

namespace WarehouseSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BinsController : ControllerBase
{
    private readonly IBinService _binService;

    public BinsController(IBinService binService)
    {
        _binService = binService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BinDto>>> GetAll()
    {
        return Ok(await _binService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BinDto>> GetById(int id)
    {
        var bin = await _binService.GetByIdAsync(id);
        if (bin == null) return NotFound();
        return Ok(bin);
    }

    [HttpPost]
    public async Task<ActionResult<BinDto>> Create(CreateBinDto dto)
    {
        var created = await _binService.CreateAsync(dto);
        if (created == null) return BadRequest("Invalid WarehouseId.");
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _binService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
