using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementSystem.Migrations
{
    public partial class CreateKassaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kassas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false,defaultValue:DateTime.UtcNow.AddHours(4)),
                    LastModifiedCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastAmount = table.Column<double>(type: "float", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kassas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Kassas",
                columns: new[] { "Id", "Balance", "LastAmount", "LastModifiedCause", "LastModifiedTime", "RecordPerson" },
                values: new object[] { 1, 0.0, 0.0, "Buna gore", new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kassas");
        }
    }
}
