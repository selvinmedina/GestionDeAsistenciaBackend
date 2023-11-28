namespace VisitService.Api.Features.Ubicaciones.Dtos
{
    public class UbicacionDto
    {
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
