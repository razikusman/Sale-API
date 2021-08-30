using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sale_API.Migrations
{
    public partial class tablescreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Name = table.Column<string>(nullable: true),
                    C_Address1 = table.Column<string>(nullable: true),
                    C_Address2 = table.Column<string>(nullable: true),
                    C_Address3 = table.Column<string>(nullable: true),
                    C_Suburb = table.Column<string>(nullable: true),
                    C_State = table.Column<string>(nullable: true),
                    C_Postcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    I_Code = table.Column<string>(nullable: true),
                    I_Description = table.Column<string>(nullable: true),
                    I_Note = table.Column<string>(nullable: true),
                    I_Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    I_Num = table.Column<int>(nullable: false),
                    I_Date = table.Column<DateTime>(nullable: false),
                    I_RefNum = table.Column<int>(nullable: false),
                    I_Note = table.Column<string>(nullable: true),
                    CustomerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(nullable: false),
                    O_qty = table.Column<int>(nullable: false),
                    O_Tax = table.Column<int>(nullable: false),
                    O_ExclAmount = table.Column<int>(nullable: false),
                    O_TaxAmount = table.Column<int>(nullable: false),
                    O_InclAmount = table.Column<int>(nullable: false),
                    InvoiceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Ordders_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerID",
                table: "Invoices",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordders_InvoiceID",
                table: "Ordders",
                column: "InvoiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Ordders");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
