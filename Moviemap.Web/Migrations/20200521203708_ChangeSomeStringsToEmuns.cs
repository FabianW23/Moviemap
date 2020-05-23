using Microsoft.EntityFrameworkCore.Migrations;

namespace Moviemap.Web.Migrations
{
    public partial class ChangeSomeStringsToEmuns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ChairType",
                table: "Chairs",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ChairType",
                table: "Chairs",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
