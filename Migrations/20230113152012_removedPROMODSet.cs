using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adi
{
    /// <inheritdoc />
    public partial class removedPROMODSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Products_billedproductsupplierId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Retailers_retailerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_supplierId1",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ProductModel");

            migrationBuilder.RenameIndex(
                name: "IX_Products_supplierId1",
                table: "ProductModel",
                newName: "IX_ProductModel_supplierId1");

            migrationBuilder.RenameIndex(
                name: "IX_Products_retailerId",
                table: "ProductModel",
                newName: "IX_ProductModel_retailerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel",
                column: "supplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_ProductModel_billedproductsupplierId",
                table: "Bills",
                column: "billedproductsupplierId",
                principalTable: "ProductModel",
                principalColumn: "supplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_Retailers_retailerId",
                table: "ProductModel",
                column: "retailerId",
                principalTable: "Retailers",
                principalColumn: "retailerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_Suppliers_supplierId1",
                table: "ProductModel",
                column: "supplierId1",
                principalTable: "Suppliers",
                principalColumn: "supplierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_ProductModel_billedproductsupplierId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_Retailers_retailerId",
                table: "ProductModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_Suppliers_supplierId1",
                table: "ProductModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel");

            migrationBuilder.RenameTable(
                name: "ProductModel",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_ProductModel_supplierId1",
                table: "Products",
                newName: "IX_Products_supplierId1");

            migrationBuilder.RenameIndex(
                name: "IX_ProductModel_retailerId",
                table: "Products",
                newName: "IX_Products_retailerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "supplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Products_billedproductsupplierId",
                table: "Bills",
                column: "billedproductsupplierId",
                principalTable: "Products",
                principalColumn: "supplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Retailers_retailerId",
                table: "Products",
                column: "retailerId",
                principalTable: "Retailers",
                principalColumn: "retailerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_supplierId1",
                table: "Products",
                column: "supplierId1",
                principalTable: "Suppliers",
                principalColumn: "supplierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
