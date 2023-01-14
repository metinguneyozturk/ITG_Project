using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adi
{
    /// <inheritdoc />
    public partial class relationaldb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "retailerId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "supplierId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_retailerId",
                table: "Products",
                column: "retailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_supplierId",
                table: "Products",
                column: "supplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Retailers_retailerId",
                table: "Products",
                column: "retailerId",
                principalTable: "Retailers",
                principalColumn: "retailerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_supplierId",
                table: "Products",
                column: "supplierId",
                principalTable: "Suppliers",
                principalColumn: "supplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Retailers_retailerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_supplierId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_retailerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_supplierId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "retailerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "supplierId",
                table: "Products");
        }
    }
}
