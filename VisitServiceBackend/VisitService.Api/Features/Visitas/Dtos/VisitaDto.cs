namespace VisitService.Api.Features.Visitas.Dtos
{
    public class VisitaDto
    {
        public string? Comentarios { get; set; }
        public List<AsignacionTransporteDto> AsignacionesTransporte { get; set; } = new List<AsignacionTransporteDto>();
        public List<DetalleVisitaDto> DetallesVisita { get; set; } = new List<DetalleVisitaDto>();
    }
}
