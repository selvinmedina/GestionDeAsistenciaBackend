namespace VisitService.Api.Features.Visitas.Dtos
{
    public class VisitaDto
    {
        public string? Comentarios { get; set; }
        public string? ComentarioPersonaQueRecibe { get; set; }
        public DateTime FechaEntrada { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public List<AsignacionTransporteDto> AsignacionesTransporte { get; set; } = new List<AsignacionTransporteDto>();
        public List<DetalleVisitaDto> DetallesVisita { get; set; } = new List<DetalleVisitaDto>();
    }
}
