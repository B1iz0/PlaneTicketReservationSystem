using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyEntityId",
                table: "Airports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyEntityId",
                table: "Airplanes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_CompanyEntityId",
                table: "Airports",
                column: "CompanyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Airplanes_CompanyEntityId",
                table: "Airplanes",
                column: "CompanyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryId",
                table: "Companies",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Airplanes_Companies_CompanyEntityId",
                table: "Airplanes",
                column: "CompanyEntityId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Airports_Companies_CompanyEntityId",
                table: "Airports",
                column: "CompanyEntityId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airplanes_Companies_CompanyEntityId",
                table: "Airplanes");

            migrationBuilder.DropForeignKey(
                name: "FK_Airports_Companies_CompanyEntityId",
                table: "Airports");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Airports_CompanyEntityId",
                table: "Airports");

            migrationBuilder.DropIndex(
                name: "IX_Airplanes_CompanyEntityId",
                table: "Airplanes");

            migrationBuilder.DropColumn(
                name: "CompanyEntityId",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "CompanyEntityId",
                table: "Airplanes");
        }
    }
}
