using Microsoft.EntityFrameworkCore.Migrations;

namespace DataPlus.Bar.Entities.Migrations
{
    public partial class updatedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Accounts",
                newName: "DateCreated");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Accounts",
                newName: "DateOfBirth");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Accounts",
                nullable: true);
        }
    }
}
