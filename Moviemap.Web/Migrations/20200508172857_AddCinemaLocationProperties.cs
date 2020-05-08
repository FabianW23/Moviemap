using Microsoft.EntityFrameworkCore.Migrations;

namespace Moviemap.Web.Migrations
{
    public partial class AddCinemaLocationProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_BrandEntity_BrandId",
                table: "Cinemas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrandEntity",
                table: "BrandEntity");

            migrationBuilder.RenameTable(
                name: "BrandEntity",
                newName: "Brands");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Cinemas",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Cinemas",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Brands_BrandId",
                table: "Cinemas",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Brands_BrandId",
                table: "Cinemas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Cinemas");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "BrandEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrandEntity",
                table: "BrandEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_BrandEntity_BrandId",
                table: "Cinemas",
                column: "BrandId",
                principalTable: "BrandEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
