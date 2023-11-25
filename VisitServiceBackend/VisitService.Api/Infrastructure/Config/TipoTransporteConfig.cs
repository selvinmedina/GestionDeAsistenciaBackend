using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Infrastructure.Config
{
    public class TipoTransporteConfig : IEntityTypeConfiguration<TipoTransporte>
    {
        public void Configure(EntityTypeBuilder<TipoTransporte> builder)
        {
            builder.ToTable("TipoTransporte", "public");

            builder.HasKey(tt => tt.Id);
            builder.Property(tt => tt.Id)
                   .IsRequired()
                   .UseIdentityColumn();

            builder.Property(tt => tt.Nombre)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(tt => tt.FechaCreacion)
                   .IsRequired();

            builder.Property(e => e.Estado);

            // Propiedades opcionales
            builder.Property(tt => tt.FechaModificacion);
            builder.Property(tt => tt.UsuarioAgregaId)
                   .IsRequired();
            builder.Property(tt => tt.UsuarioModificaId);
        }
    }
}
