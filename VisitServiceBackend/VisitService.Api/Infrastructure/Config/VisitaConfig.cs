using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Infrastructure.Config
{
    public class VisitaConfig : IEntityTypeConfiguration<Visita>
    {
        public void Configure(EntityTypeBuilder<Visita> builder)
        {

            // Configuración de la tabla
            builder.ToTable("Visita", "public");

            // Configuración de la clave primaria
            builder.HasKey(e => e.Id);

            // Configuración del campo Id para utilizar la secuencia
            builder.Property(e => e.Id)
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(e => e.Comentarios)
                .HasMaxLength(200);

            builder.Property(e => e.ComentarioPersonaQueRecibe)
                .HasMaxLength(200);

            builder.Property(e => e.EsVisitaAprobada)
                .IsRequired();

            builder.Property(e => e.FechaEntrada)
                .IsRequired();

            builder.Property(e => e.HoraEntrada)
                .IsRequired();

            builder.Property(e => e.FechaSalida);

            builder.Property(e => e.Estado);

            builder.Property(e => e.HoraSalida);

            builder.Property(e => e.UsuarioAgregaId)
                .IsRequired();

            builder.Property(e => e.UsuarioApruebaId);

            builder.HasMany(x => x.DetalleVisita)
                .WithOne(x => x.Visita)
                .HasForeignKey(x => x.VisitaId);
        }
    }
}
