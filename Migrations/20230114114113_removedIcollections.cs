using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adi
{
    /// <inheritdoc />
    public partial class removedIcollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductModelProductModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductModelProductModel",
                columns: table => new
                {
                    retailerProductsproductId = table.Column<int>(type: "integer", nullable: false),
                    supplierProductsproductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelProductModel", x => new { x.retailerProductsproductId, x.supplierProductsproductId });
                    table.ForeignKey(
                        name: "FK_ProductModelProductModel_Products_retailerProductsproductId",
                        column: x => x.retailerProductsproductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModelProductModel_Products_supplierProductsproductId",
                        column: x => x.supplierProductsproductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelProductModel_supplierProductsproductId",
                table: "ProductModelProductModel",
                column: "supplierProductsproductId");
        }
    }
}
