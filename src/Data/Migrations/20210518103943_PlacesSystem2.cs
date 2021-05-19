using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaneTicketReservationSystem.Data.Migrations
{
    public partial class PlacesSystem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Prices");

            migrationBuilder.AddColumn<decimal>(
                name: "TicketPrice",
                table: "Prices",
                type: "decimal(10,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Prices");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Prices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
