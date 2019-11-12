using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.DataAccess.Migrations
{
    public partial class taskSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "DateTime", "Description", "Priority", "State", "Title" },
                values: new object[] { 1, new DateTime(2019, 11, 12, 21, 32, 58, 165, DateTimeKind.Local), "Test task description", 0, 0, "Test task" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "DateTime", "Description", "Priority", "State", "Title" },
                values: new object[] { 2, new DateTime(2019, 11, 12, 21, 32, 58, 166, DateTimeKind.Local), "description", 1, 1, "Hello task" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "DateTime", "Description", "Priority", "State", "Title" },
                values: new object[] { 3, new DateTime(2019, 11, 12, 21, 32, 58, 166, DateTimeKind.Local), "task description", 3, 1, "Critical task" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
