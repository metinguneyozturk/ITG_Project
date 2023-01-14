using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adi
{
    /// <inheritdoc />
    public partial class rearrangeDBset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_ProductModel_billedproductproductId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_Retailers_retailerId",
                table: "ProductModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_Suppliers_supplierId",
                table: "ProductModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductModel_retailerId",
                table: "ProductModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductModel_supplierId",
                table: "ProductModel");

            migrationBuilder.RenameTable(
                name: "ProductModel",
                newName: "Products");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Suppliers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RetailerModelretailerId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_productId",
                table: "Suppliers",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RetailerModelretailerId",
                table: "Products",
                column: "RetailerModelretailerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Products_billedproductproductId",
                table: "Bills",
                column: "billedproductproductId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Retailers_RetailerModelretailerId",
                table: "Products",
                column: "RetailerModelretailerId",
                principalTable: "Retailers",
                principalColumn: "retailerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Products_productId",
                table: "Suppliers",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Products_billedproductproductId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Retailers_RetailerModelretailerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Products_productId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_productId",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_RetailerModelretailerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "RetailerModelretailerId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ProductModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_retailerId",
                table: "ProductModel",
                column: "retailerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_supplierId",
                table: "ProductModel",
                column: "supplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_ProductModel_billedproductproductId",
                table: "Bills",
                column: "billedproductproductId",
                principalTable: "ProductModel",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_Retailers_retailerId",
                table: "ProductModel",
                column: "retailerId",
                principalTable: "Retailers",
                principalColumn: "retailerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_Suppliers_supplierId",
                table: "ProductModel",
                column: "supplierId",
                principalTable: "Suppliers",
                principalColumn: "supplierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
