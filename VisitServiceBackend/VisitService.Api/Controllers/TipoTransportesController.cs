using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VisitService.Api.Features.TiposTransportes.Dtos;
using VisitService.Api.Features.TiposTransportes;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTransportesController : ControllerBase
    {
        private readonly TipoTransporteService _tipoTransporteService;

        public TipoTransportesController(TipoTransporteService tipoTransporteService)
        {
            _tipoTransporteService = tipoTransporteService;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoTransporte>> GetAllTipoTransportes()
        {
            return await _tipoTransporteService.GetAllTipoTransportesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTransporte>> GetTipoTransporte(int id)
        {
            try
            {
                return await _tipoTransporteService.GetTipoTransporteByIdAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"No se encontró el tipo de transporte con ID {id}.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddTipoTransporte([FromBody] TipoTransporteDto tipoTransporteDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tipoTransporteNuevo = await _tipoTransporteService.AddTipoTransporteAsync(tipoTransporteDto, userId!);
            return CreatedAtAction(nameof(GetTipoTransporte), new { id = tipoTransporteNuevo.Id }, tipoTransporteNuevo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTipoTransporte(int id, [FromBody] TipoTransporteDto tipoTransporteDto)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _tipoTransporteService.UpdateTipoTransporteAsync(tipoTransporteDto, id, userId!);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"No se encontró el tipo de transporte con ID {id}.");
            }
        }

        [HttpPatch("{id}/change-status/{estado}")]
        public async Task<ActionResult> ChangeStatus(int id, bool estado)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _tipoTransporteService.ChangeStatusAsync(id, estado, userId!);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"No se encontró el tipo de transporte con ID {id} para cambiar estado.");
            }
        }
    }

}
