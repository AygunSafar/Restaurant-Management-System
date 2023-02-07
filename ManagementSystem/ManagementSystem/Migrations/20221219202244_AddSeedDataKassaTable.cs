using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementSystem.Migrations
{
    public partial class AddSeedDataKassaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kassas",
                columns: new[] { "Id", "AppUserId", "Balance", "LastAmount", "LastModifiedCause", "LastModifiedPerson", "LastModifiedTime" },
                values: new object[] { 1, null, 0.0, 0.0, null, "", new DateTime(2022, 12, 20, 0, 22, 43, 861, DateTimeKind.Utc).AddTicks(7790) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kassas",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
