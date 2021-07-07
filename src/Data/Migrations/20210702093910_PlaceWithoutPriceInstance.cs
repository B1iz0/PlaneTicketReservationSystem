using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaneTicketReservationSystem.Data.Migrations
{
    public partial class PlaceWithoutPriceInstance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Prices_PriceId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_PriceId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Places");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PriceId",
                table: "Places",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Places_PriceId",
                table: "Places",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Prices_PriceId",
                table: "Places",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
