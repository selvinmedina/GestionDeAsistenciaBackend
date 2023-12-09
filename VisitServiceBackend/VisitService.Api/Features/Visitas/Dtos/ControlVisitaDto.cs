namespace VisitService.Api.Features.Visitas.Dtos
{
    public class ControlVisitaDto
    {
        public int Id { get; set; }
        public string? Comentarios { get; set; }
        public string? ComentarioPersonaQueRecibe { get; set; }

        public bool EsVisitaAprobada { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public TimeSpan? HoraEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public bool Estado { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public string UsuarioAgregaId { get; set; } = null!;
        public string? UsuarioApruebaId { get; set; }
        public string? UsuarioModificaId { get; set; }
        public DateTime FechaModificacion { get; set; }

        public List<AsignacionTransporteDto> AsignacionesTransporte { get; set; } = new List<AsignacionTransporteDto>();
        public List<DetalleVisitaDto> DetalleVisita { get; set; } = new List<DetalleVisitaDto>();
    }
}
