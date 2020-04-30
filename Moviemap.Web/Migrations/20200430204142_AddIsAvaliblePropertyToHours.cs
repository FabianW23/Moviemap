using Microsoft.EntityFrameworkCore.Migrations;

namespace Moviemap.Web.Migrations
{
    public partial class AddIsAvaliblePropertyToHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvalible",
                table: "Hours",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvalible",
                table: "Hours");
        }
    }
}
