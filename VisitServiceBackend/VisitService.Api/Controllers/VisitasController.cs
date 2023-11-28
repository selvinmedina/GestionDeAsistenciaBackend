using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VisitService.Api.Features.Visitas.Dtos;
using VisitService.Api.Features.Visitas;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitasController : ControllerBase
    {
        private readonly VisitaService _visitaService;

        public VisitasController(VisitaService visitaService)
        {
            _visitaService = visitaService;
        }

        [HttpPost("agregar-visita")]
        public async Task<ActionResult> AgregarVisita([FromBody] VisitaDto visitaDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var visita = await _visitaService.AgregarVisitaAsync(visitaDto, userId!);
            return CreatedAtAction("VerVisita", new { id = visita.Id }, visita);
        }

        //[HttpGet("ver-visitas")]
        //public async Task<ActionResult<IEnumerable<Visita>>> VerVisitasRegistradas()
        //{
        //    // Implementar lógica para retornar las visitas registradas
        //    // ...
        //}

        //[HttpPost("notificar-entrada/{id}")]
        //public async Task<ActionResult> NotificarEntrada(int id)
        //{
        //    // Implementar lógica para notificar la entrada
        //    // ...
        //}

        //[HttpPost("notificar-salida/{id}")]
        //public async Task<ActionResult> NotificarSalida(int id)
        //{
        //    // Implementar lógica para notificar la salida
        //    // ...
        //}
    }

}
