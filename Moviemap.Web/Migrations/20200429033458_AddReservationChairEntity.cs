using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moviemap.Web.Migrations
{
    public partial class AddReservationChairEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chairs_Reservations_ReservationId",
                table: "Chairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Movies_MovieId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Chairs_ReservationId",
                table: "Chairs");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Chairs");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Reservations",
                newName: "HourId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_MovieId",
                table: "Reservations",
                newName: "IX_Reservations_HourId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.CreateTable(
                name: "ReservationChairsEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReservationId = table.Column<int>(nullable: true),
                    ChairId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationChairsEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationChairsEntity_Chairs_ChairId",
                        column: x => x.ChairId,
                        principalTable: "Chairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationChairsEntity_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationChairsEntity_ChairId",
                table: "ReservationChairsEntity",
                column: "ChairId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationChairsEntity_ReservationId",
                table: "ReservationChairsEntity",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Hours_HourId",
                table: "Reservations",
                column: "HourId",
                principalTable: "Hours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Hours_HourId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "ReservationChairsEntity");

            migrationBuilder.RenameColumn(
                name: "HourId",
                table: "Reservations",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_HourId",
                table: "Reservations",
                newName: "IX_Reservations_MovieId");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Chairs",
                nullable: true);

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
                name: "FK_Reservations_Movies_MovieId",
                table: "Reservations",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
