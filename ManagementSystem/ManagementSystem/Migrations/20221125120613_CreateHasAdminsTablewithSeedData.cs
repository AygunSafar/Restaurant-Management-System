using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementSystem.Migrations
{
    public partial class CreateHasAdminsTablewithSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HasAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasAdmins = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HasAdmins", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "HasAdmins",
                columns: new[] { "Id", "HasAdmins" },
                values: new object[] { 1, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HasAdmins");
        }
    }
}
