using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitService.Api.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoDatosAuditoriaVisitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                schema: "public",
                table: "Visita",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioModificaId",
                schema: "public",
                table: "Visita",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                schema: "public",
                table: "Visita");

            migrationBuilder.DropColumn(
                name: "UsuarioModificaId",
                schema: "public",
                table: "Visita");
        }
    }
}
