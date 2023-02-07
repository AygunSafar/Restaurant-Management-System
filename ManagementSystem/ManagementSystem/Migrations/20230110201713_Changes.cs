using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementSystem.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tables",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Kassas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastModifiedCause", "LastModifiedPerson", "LastModifiedTime" },
                values: new object[] { "-", "-", new DateTime(2023, 1, 11, 0, 17, 13, 104, DateTimeKind.Utc).AddTicks(9528) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Kassas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastModifiedCause", "LastModifiedPerson", "LastModifiedTime" },
                values: new object[] { null, "", new DateTime(2023, 1, 6, 0, 30, 48, 812, DateTimeKind.Utc).AddTicks(3261) });
        }
    }
}
