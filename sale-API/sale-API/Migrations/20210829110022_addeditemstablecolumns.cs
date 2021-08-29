using Microsoft.EntityFrameworkCore.Migrations;

namespace sale_API.Migrations
{
    public partial class addeditemstablecolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "I_ExclAmount",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "I_InclAmount",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "I_Tax",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "I_TaxAmount",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "I_qty",
                table: "Items",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "I_ExclAmount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "I_InclAmount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "I_Tax",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "I_TaxAmount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "I_qty",
                table: "Items");
        }
    }
}
