using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Heyday_Website.Migrations.AppDb
{
    public partial class addwarps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("561ed884-8a7f-4066-a37d-8528530310e5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ab79a777-6937-42f0-a7d6-ee6ae71ae07a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fa7c278d-0aa1-4304-9076-92d5d796cfac"));

            migrationBuilder.CreateTable(
                name: "Warps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    Z = table.Column<double>(nullable: false),
                    Submitter = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    Reviewer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warps", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { new Guid("987af32e-30a9-4949-b7ab-7644e064d306"), "intro" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { new Guid("9e7cb570-ddfa-4a54-a5a0-3b446667931c"), "activity" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { new Guid("6a78f148-06c5-41c1-a841-73840ec990e8"), "others" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Warps");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6a78f148-06c5-41c1-a841-73840ec990e8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("987af32e-30a9-4949-b7ab-7644e064d306"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9e7cb570-ddfa-4a54-a5a0-3b446667931c"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { new Guid("561ed884-8a7f-4066-a37d-8528530310e5"), "intro" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { new Guid("fa7c278d-0aa1-4304-9076-92d5d796cfac"), "activity" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { new Guid("ab79a777-6937-42f0-a7d6-ee6ae71ae07a"), "others" });
        }
    }
}
