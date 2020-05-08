using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moviemap.Web.Migrations
{
    public partial class AddBrandEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoPath",
                table: "Cinemas");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Cinemas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BrandEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    LogoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_BrandId",
                table: "Cinemas",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_BrandEntity_BrandId",
                table: "Cinemas",
                column: "BrandId",
                principalTable: "BrandEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_BrandEntity_BrandId",
                table: "Cinemas");

            migrationBuilder.DropTable(
                name: "BrandEntity");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_BrandId",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Cinemas");

            migrationBuilder.AddColumn<string>(
                name: "LogoPath",
                table: "Cinemas",
                nullable: true);
        }
    }
}
