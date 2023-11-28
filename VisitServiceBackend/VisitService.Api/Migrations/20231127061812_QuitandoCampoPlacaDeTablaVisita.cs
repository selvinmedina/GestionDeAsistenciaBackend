using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitService.Api.Migrations
{
    /// <inheritdoc />
    public partial class QuitandoCampoPlacaDeTablaVisita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placa",
                schema: "public",
                table: "Visita");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Placa",
                schema: "public",
                table: "Visita",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
