using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Infrastructure.Config
{
    public class AsignacionVehiculoConfig : IEntityTypeConfiguration<AsignacionVehiculo>
    {
        public void Configure(EntityTypeBuilder<AsignacionVehiculo> builder)
        {
            builder.ToTable("AsignacionVehiculo");

            builder.HasKey(av => av.Id);
            builder.Property(av => av.Id)
                   .IsRequired()
                   .UseIdentityColumn();

            builder.Property(av => av.FechaAsignacion)
                   .IsRequired();

            builder.Property(e => e.Estado);

            // Configurar relaciones
            builder.HasOne(av => av.Visita)
                   .WithMany(v => v.AsignacionesVehiculo)
                   .HasForeignKey(av => av.VisitaId);

            builder.HasOne(av => av.TipoTransporte)
                   .WithMany()
                   .HasForeignKey(av => av.TipoTransporteId);
        }
    }
}
