using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.DataAccess.Migrations
{
    public partial class DeleteWidgets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Widgets");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2020, 1, 19, 15, 55, 39, 674, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2020, 1, 19, 15, 55, 39, 676, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2020, 1, 19, 15, 55, 39, 676, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Widgets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BorderColor = table.Column<string>(maxLength: 30, nullable: false),
                    ChartType = table.Column<int>(nullable: false),
                    ColorScheme = table.Column<int>(nullable: false),
                    Priorities = table.Column<string>(nullable: false),
                    States = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widgets", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2019, 11, 12, 21, 32, 58, 165, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2019, 11, 12, 21, 32, 58, 166, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2019, 11, 12, 21, 32, 58, 166, DateTimeKind.Local));
        }
    }
}
