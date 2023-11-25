namespace VisitService.Api.Infrastructure.Entities
{
    public class Ubicacion // Oficinas, almacenes, puntos de ventas
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioAgregaId { get; set; } = null!;
        public string UsuarioModificaId { get; set; } = null!;
    }

}
