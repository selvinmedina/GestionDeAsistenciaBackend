using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VisitService.Api.Features.Visitas.Dtos;
using VisitService.Api.Features.Visitas;
using VisitService.Api.Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;

namespace VisitService.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitasController : ControllerBase
    {
        private readonly VisitaService _visitaService;

        public VisitasController(VisitaService visitaService)
        {
            _visitaService = visitaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Visita?>> ObtenerVisita(int id)
        {
            var respuesta = await _visitaService.ObtenerVisita(id);

            return respuesta;
        }


        [HttpPost("agregar-visita")]
        public async Task<ActionResult> AgregarVisita([FromBody] VisitaDto visitaDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var visita = await _visitaService.AgregarVisitaAsync(visitaDto, userId!);
            return CreatedAtAction(nameof(ObtenerVisita), new { id = visita.Id }, visita);
        }

        [HttpPatch("{id}/cambiar-estado/{estado}")]
        public async Task<ActionResult> CambiarEstado(int id, bool estado)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _visitaService.CambiarEstadoVisitaAsync(id, estado, userId!);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"No se encontró la visita con ID {id} para cambiar estado.");
            }
        }

        [HttpGet("ver-visitas-pendientes")]
        public async Task<List<Visita>> VerVisitasRegistradas()
        {
            var respuesta = await _visitaService.ObtenerVisitasPendientes();

            return respuesta;
        }

        [HttpPost("registrar-entrada/{id}")]
        public async Task<ActionResult> RegistrarEntrada(int id, [FromQuery] string? comentarioPersonaQueRecibe = null)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _visitaService.RegistrarEntrada(id, userId!, comentarioPersonaQueRecibe);

            return NoContent();
        }

        [HttpPost("registrar-salida/{id}")]
        public async Task<ActionResult> RegistrarSalida(int id)
        {
            await _visitaService.RegistrarSalida(id);
            return NoContent();
        }
    }

}
