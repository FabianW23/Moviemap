using Microsoft.EntityFrameworkCore.Migrations;

namespace Moviemap.Web.Migrations
{
    public partial class AddUserPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "AspNetUsers");
        }
    }
}
