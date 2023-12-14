namespace VisitService.Api.Infrastructure.Entities
{
    public class DetalleVisita
    {
        public int Id { get; set; }
        public int VisitaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Identidad { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioAgregaId { get; set; } = null!;
        public string? UsuarioModificaId { get; set; }
        public bool Estado { get; set; }

        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }

        public Visita Visita { get; set; } = null!;
    }

}
