using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Heyday_Website.Migrations.AppDb
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
