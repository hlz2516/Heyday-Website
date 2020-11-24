using Microsoft.EntityFrameworkCore.Migrations;

namespace Heyday_Website.Migrations
{
    public partial class addStar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Star",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Star",
                table: "AspNetUsers");
        }
    }
}
