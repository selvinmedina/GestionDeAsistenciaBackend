using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitService.Api.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoCampoEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                schema: "public",
                table: "Visita",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Ubicacion",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                schema: "public",
                table: "TipoTransporte",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                schema: "public",
                table: "DetalleVisita",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "AsignacionVehiculo",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                schema: "public",
                table: "Visita");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Ubicacion");

            migrationBuilder.DropColumn(
                name: "Estado",
                schema: "public",
                table: "TipoTransporte");

            migrationBuilder.DropColumn(
                name: "Estado",
                schema: "public",
                table: "DetalleVisita");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "AsignacionVehiculo");
        }
    }
}
