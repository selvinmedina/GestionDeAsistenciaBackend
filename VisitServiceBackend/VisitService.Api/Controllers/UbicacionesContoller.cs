using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VisitService.Api.Features.Ubicaciones;
using VisitService.Api.Features.Ubicaciones.Dtos;
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
        public async Task<ActionResult> AddUbicacion([FromBody] UbicacionDto ubicacion)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ubicacionNueva = await _ubicacionService.AddUbicacionAsync(ubicacion, userId);
            return CreatedAtAction(nameof(GetUbicacion), new { id = ubicacionNueva.Id }, ubicacionNueva);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUbicacion(int id, [FromBody] UbicacionDto ubicacionDto)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _ubicacionService.UpdateUbicacionAsync(ubicacionDto, id, userId);
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
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _ubicacionService.ChangeStatusAsync(id, estado, userId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"No se encontró la ubicación con ID {id} para cambiar estado.");
            }
        }
    }
}
