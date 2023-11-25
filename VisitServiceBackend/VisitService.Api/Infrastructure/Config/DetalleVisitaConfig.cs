using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Infrastructure.Config
{
    public class DetalleVisitaConfig : IEntityTypeConfiguration<DetalleVisita>
    {
        public void Configure(EntityTypeBuilder<DetalleVisita> builder)
        {
            builder.ToTable("DetalleVisita", "public");

            builder.HasKey(dv => dv.Id);
            builder.Property(dv => dv.Id)
                   .IsRequired()
                   .UseIdentityColumn();

            builder.Property(dv => dv.Nombre)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(dv => dv.Apellido)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(dv => dv.Identidad)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(dv => dv.FechaCreacion)
                   .IsRequired();
            builder.Property(dv => dv.UsuarioAgregaId)
                   .IsRequired();

            // Propiedades opcionales
            builder.Property(dv => dv.FechaModificacion);
            builder.Property(dv => dv.UsuarioModificaId);

            // Relación con Visita
            builder.HasOne(dv => dv.Visita)
                   .WithMany()
                   .HasForeignKey(dv => dv.VisitaId)
                   .IsRequired();
        }
    }
}
