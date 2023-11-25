using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Infrastructure.Config
{
    public class UbicacionConfig : IEntityTypeConfiguration<Ubicacion>
    {
        public void Configure(EntityTypeBuilder<Ubicacion> builder)
        {
            builder.ToTable("Ubicacion");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                   .IsRequired()
                   .UseIdentityColumn();

            builder.Property(t => t.Nombre)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(t => t.Direccion)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(t => t.FechaCreacion)
                   .IsRequired();

            builder.Property(e => e.Estado);

            builder.Property(t => t.UsuarioAgregaId)
                   .IsRequired();

            builder.Property(t => t.FechaModificacion);
            builder.Property(t => t.UsuarioModificaId);
        }
    }
}
