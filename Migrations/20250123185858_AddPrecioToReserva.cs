using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeReservas.Migrations
{
    /// <inheritdoc />
    public partial class AddPrecioToReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Reserva",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Precio", table: "Reserva");
        }
    }
}
