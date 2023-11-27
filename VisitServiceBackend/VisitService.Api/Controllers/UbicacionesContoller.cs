using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VisitService.Api.Featues.Ubicaciones;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesController : ControllerBase
    {
        private readonly UbicacionService _ubicacionService;

        public UbicacionesController(UbicacionService ubicacionService)
        {
            _ubicacionService = ubicacionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Ubicacion>> GetAllUbicaciones()
        {
            return await _ubicacionService.GetAllUbicacionesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicacion>> GetUbicacion(int id)
        {
            try
            {
                return await _ubicacionService.GetUbicacionByIdAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"No se encontró la ubicación con ID {id}.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUbicacion([FromBody] Ubicacion ubicacion)
        {
            await _ubicacionService.AddUbicacionAsync(ubicacion);
            return CreatedAtAction(nameof(GetUbicacion), new { id = ubicacion.Id }, ubicacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUbicacion(int id, [FromBody] Ubicacion ubicacion)
        {
            if (id != ubicacion.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el ID de la ubicación.");
            }

            try
            {
                await _ubicacionService.UpdateUbicacionAsync(ubicacion);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"No se encontró la ubicación con ID {id}.");
            }
        }

        [HttpPatch("{id}/change-status/{estado}")]
        public async Task<ActionResult> ChangeStatus(int id, bool estado)
        {
            try
            {
                await _ubicacionService.ChangeStatusAsync(id, estado);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"No se encontró la ubicación con ID {id} para cambiar estado.");
            }
        }
    }
}
