using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementSystem.Migrations
{
    public partial class CreateSalaryandEmployeeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kassas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "RecordPerson",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "RecordPerson",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "RecordPerson",
                table: "Kassas",
                newName: "LastModifiedPerson");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Salaries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Salaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Kassas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Incomes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Expenses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_AppUserId",
                table: "Salaries",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeId",
                table: "Salaries",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Kassas_AppUserId",
                table: "Kassas",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_AppUserId",
                table: "Incomes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_AppUserId",
                table: "Expenses",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_AppUserId",
                table: "Expenses",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_AspNetUsers_AppUserId",
                table: "Incomes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kassas_AspNetUsers_AppUserId",
                table: "Kassas",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_AspNetUsers_AppUserId",
                table: "Salaries",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Employees_EmployeeId",
                table: "Salaries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_AppUserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_AspNetUsers_AppUserId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Kassas_AspNetUsers_AppUserId",
                table: "Kassas");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_AspNetUsers_AppUserId",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employees_EmployeeId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_AppUserId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_EmployeeId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Kassas_AppUserId",
                table: "Kassas");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_AppUserId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_AppUserId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Kassas");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "LastModifiedPerson",
                table: "Kassas",
                newName: "RecordPerson");

            migrationBuilder.AddColumn<string>(
                name: "RecordPerson",
                table: "Incomes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordPerson",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Kassas",
                columns: new[] { "Id", "Balance", "LastAmount", "LastModifiedCause", "LastModifiedTime", "RecordPerson" },
                values: new object[] { 1, 0.0, 0.0, "Buna gore", new DateTime(2022, 12, 19, 0, 0, 0, 0, DateTimeKind.Local), "Admin" });
        }
    }
}
