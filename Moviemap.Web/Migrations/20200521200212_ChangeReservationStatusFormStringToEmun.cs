using Microsoft.EntityFrameworkCore.Migrations;

namespace Moviemap.Web.Migrations
{
    public partial class ChangeReservationStatusFormStringToEmun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
