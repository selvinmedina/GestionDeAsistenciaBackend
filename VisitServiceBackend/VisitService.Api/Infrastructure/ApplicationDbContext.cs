using EntityFramework.Infrastructure.Core.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VisitService.Api.Infrastructure.Config;

namespace VisitService.Api.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.AddConfiguration<VisitaConfig>();
            builder.AddConfiguration<DetalleVisitaConfig>();
            builder.AddConfiguration<TipoTransporteConfig>();
            builder.AddConfiguration<UbicacionConfig>();
            builder.AddConfiguration<AsignacionTransporte>();
        }
    }
}
