using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.TemplatePatern.Migrations
{
    public partial class AppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desctiption",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desctiption",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "AspNetUsers");
        }
    }
}
