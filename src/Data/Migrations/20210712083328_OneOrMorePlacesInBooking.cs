using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaneTicketReservationSystem.Data.Migrations
{
    public partial class OneOrMorePlacesInBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Places_PlaceId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PlaceId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Bookings");

            migrationBuilder.AddColumn<Guid>(
                name: "BookingId",
                table: "Places",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BaggageWeight",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Places_BookingId",
                table: "Places",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Bookings_BookingId",
                table: "Places",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Bookings_BookingId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_BookingId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "BaggageWeight",
                table: "Bookings");

            migrationBuilder.AddColumn<Guid>(
                name: "PlaceId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PlaceId",
                table: "Bookings",
                column: "PlaceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Places_PlaceId",
                table: "Bookings",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
