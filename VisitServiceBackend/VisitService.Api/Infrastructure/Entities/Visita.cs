namespace VisitService.Api.Infrastructure.Entities
{
    public class Visita
    {
        public int Id { get; set; }
        public string Placa { get; set; } = null!;
        public string Comentarios { get; set; } = null!;
        public string ComentarioPersonaQueRecibe { get; set; } = null!;

        public bool EsVisitaAprobada { get; set; }
        public DateTime FechaEntrada { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public bool Estado { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public string UsuarioAgregaId { get; set; } = null!;
        public string UsuarioApruebaId { get; set; } = null!;

        public ICollection<AsignacionVehiculo> AsignacionesVehiculo { get; set; } = null!;
    }
}
