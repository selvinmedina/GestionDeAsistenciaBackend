using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitService.Api.Migrations
{
    /// <inheritdoc />
    public partial class FechaEntradaYFechaSaldaEnDetalleDeVisita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEntrada",
                schema: "public",
                table: "DetalleVisita",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSalida",
                schema: "public",
                table: "DetalleVisita",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaEntrada",
                schema: "public",
                table: "DetalleVisita");

            migrationBuilder.DropColumn(
                name: "FechaSalida",
                schema: "public",
                table: "DetalleVisita");
        }
    }
}
