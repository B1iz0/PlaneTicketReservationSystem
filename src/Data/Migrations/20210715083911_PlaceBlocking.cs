using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaneTicketReservationSystem.Data.Migrations
{
    public partial class PlaceBlocking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LastBlockedByUserId",
                table: "Places",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastBlockingExpires",
                table: "Places",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhone",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastBlockedByUserId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "LastBlockingExpires",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "CustomerPhone",
                table: "Bookings");
        }
    }
}
