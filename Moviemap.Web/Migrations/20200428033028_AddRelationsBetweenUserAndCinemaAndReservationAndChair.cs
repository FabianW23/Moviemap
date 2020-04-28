using Microsoft.EntityFrameworkCore.Migrations;

namespace Moviemap.Web.Migrations
{
    public partial class AddRelationsBetweenUserAndCinemaAndReservationAndChair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cinemas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Chairs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_UserId",
                table: "Cinemas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chairs_ReservationId",
                table: "Chairs",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chairs_Reservations_ReservationId",
                table: "Chairs",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_AspNetUsers_UserId",
                table: "Cinemas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chairs_Reservations_ReservationId",
                table: "Chairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_AspNetUsers_UserId",
                table: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_UserId",
                table: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Chairs_ReservationId",
                table: "Chairs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Chairs");
        }
    }
}
