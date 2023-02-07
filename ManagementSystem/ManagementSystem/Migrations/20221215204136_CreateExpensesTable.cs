using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementSystem.Migrations
{
    public partial class CreateExpensesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money = table.Column<double>(type: "float", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecordPerson = table.Column<string>(type: "nvarchar(max)", nullable: true,defaultValue:DateTime.UtcNow.AddHours(4)),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
