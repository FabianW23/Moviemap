using Microsoft.EntityFrameworkCore.Migrations;

namespace Moviemap.Web.Migrations
{
    public partial class ChangeDataTypeCinemaLocationProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Longitude",
                table: "Cinemas",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<float>(
                name: "Latitude",
                table: "Cinemas",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Cinemas",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Cinemas",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
