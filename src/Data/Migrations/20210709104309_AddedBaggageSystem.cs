using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaneTicketReservationSystem.Data.Migrations
{
    public partial class AddedBaggageSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TicketPrice",
                table: "Prices",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,4)");

            migrationBuilder.AddColumn<double>(
                name: "FreeBaggageLimitInKilograms",
                table: "Flights",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "OverweightPrice",
                table: "Flights",
                type: "decimal(18,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "BaggageCapacityInKilograms",
                table: "Airplanes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreeBaggageLimitInKilograms",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "OverweightPrice",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "BaggageCapacityInKilograms",
                table: "Airplanes");

            migrationBuilder.AlterColumn<decimal>(
                name: "TicketPrice",
                table: "Prices",
                type: "decimal(10,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");
        }
    }
}
