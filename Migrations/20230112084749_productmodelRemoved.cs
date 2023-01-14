using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adi
{
    /// <inheritdoc />
    public partial class productmodelRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Products_productId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_productId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Suppliers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Suppliers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_productId",
                table: "Suppliers",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Products_productId",
                table: "Suppliers",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId");
        }
    }
}
