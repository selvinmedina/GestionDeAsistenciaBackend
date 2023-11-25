namespace VisitService.Api.Infrastructure.Entities
{
    public class TipoTransporte
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool Estado { get; set; }
        public string UsuarioAgregaId { get; set; } = null!;
        public string UsuarioModificaId { get; set; } = null!;
    }
}
