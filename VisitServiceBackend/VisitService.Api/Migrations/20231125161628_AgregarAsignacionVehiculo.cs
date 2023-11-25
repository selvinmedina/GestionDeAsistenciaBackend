using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VisitService.Api.Migrations
{
    /// <inheritdoc />
    public partial class AgregarAsignacionVehiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsignacionVehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VisitaId = table.Column<int>(type: "integer", nullable: false),
                    TipoTransporteId = table.Column<int>(type: "integer", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionVehiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AsignacionVehiculo_TipoTransporte_TipoTransporteId",
                        column: x => x.TipoTransporteId,
                        principalSchema: "public",
                        principalTable: "TipoTransporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignacionVehiculo_Visita_VisitaId",
                        column: x => x.VisitaId,
                        principalSchema: "public",
                        principalTable: "Visita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionVehiculo_TipoTransporteId",
                table: "AsignacionVehiculo",
                column: "TipoTransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionVehiculo_VisitaId",
                table: "AsignacionVehiculo",
                column: "VisitaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignacionVehiculo");
        }
    }
}
