namespace VisitService.Api.Infrastructure.Entities
{
    public class Visita
    {
        public int Id { get; set; }
        public string? Comentarios { get; set; }
        public string? ComentarioPersonaQueRecibe { get; set; }

        public bool EsVisitaAprobada { get; set; }
        public DateTime FechaEntrada { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public bool Estado { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public string UsuarioAgregaId { get; set; } = null!;
        public string? UsuarioApruebaId { get; set; }

        public ICollection<AsignacionTransporte> AsignacionesTransporte { get; set; } = null!;
        public ICollection<DetalleVisita> DetalleVisita { get; set; } = null!;
    }
}
