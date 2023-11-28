using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Infrastructure.Config
{
    public class AsignacionTransporte : IEntityTypeConfiguration<Entities.AsignacionTransporte>
    {
        public void Configure(EntityTypeBuilder<Entities.AsignacionTransporte> builder)
        {
            builder.ToTable("AsignacionTransporte");

            builder.HasKey(av => av.Id);
            builder.Property(av => av.Id)
                   .IsRequired()
                   .UseIdentityColumn();

            builder.Property(av => av.FechaAsignacion)
                   .IsRequired();

            builder.Property(e => e.Estado);

            // Configurar relaciones
            builder.HasOne(av => av.Visita)
                   .WithMany(v => v.AsignacionesTransporte)
                   .HasForeignKey(av => av.VisitaId);

            builder.HasOne(av => av.TipoTransporte)
                   .WithMany()
                   .HasForeignKey(av => av.TipoTransporteId);
        }
    }
}
