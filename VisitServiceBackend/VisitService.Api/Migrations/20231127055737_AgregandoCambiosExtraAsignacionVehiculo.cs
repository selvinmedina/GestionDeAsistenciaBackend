using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitService.Api.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoCambiosExtraAsignacionVehiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "AsignacionVehiculo",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "AsignacionVehiculo",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "AsignacionVehiculo");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "AsignacionVehiculo");
        }
    }
}
