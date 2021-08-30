using Microsoft.EntityFrameworkCore.Migrations;

namespace sale_API.Migrations
{
    public partial class tableschanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "O_Tax",
                table: "Ordders");

            migrationBuilder.AddColumn<int>(
                name: "I_Tax",
                table: "Items",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "I_Tax",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "O_Tax",
                table: "Ordders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
