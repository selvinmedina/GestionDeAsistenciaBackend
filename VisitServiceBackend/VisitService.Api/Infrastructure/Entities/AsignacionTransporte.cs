namespace VisitService.Api.Infrastructure.Entities
{
    public class AsignacionTransporte
    {
        public int Id { get; set; }
        public int VisitaId { get; set; }
        public int TipoTransporteId { get; set; }
        public string? Placa { get; set; }
        public string? Color { get; set; }
        public DateTime FechaAsignacion { get; set; }

        public bool Estado { get; set; }

        public Visita Visita { get; set; } = null!;
        public TipoTransporte TipoTransporte { get; set; } = null!;
    }

}
