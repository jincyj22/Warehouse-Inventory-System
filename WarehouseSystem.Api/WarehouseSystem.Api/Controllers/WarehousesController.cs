using Microsoft.AspNetCore.Mvc;
using WarehouseSystem.Api.DTOs;
using WarehouseSystem.Api.Services;


namespace WarehouseSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehousesController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetAll()
        {
            return Ok(await _warehouseService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseDto>> GetById(int id)
        {
            var warehouse = await _warehouseService.GetByIdAsync(id);
            if (warehouse == null) return NotFound();
            return Ok(warehouse);
        }

        [HttpPost]
        public async Task<ActionResult<WarehouseDto>> Create(CreateWarehouseDto dto)
        {
            var created = await _warehouseService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _warehouseService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
