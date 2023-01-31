using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adi
{
    /// <inheritdoc />
    public partial class removedRetailerIDfromProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Retailers_RetailerModelretailerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_RetailerModelretailerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RetailerModelretailerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "retailerId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RetailerModelretailerId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "retailerId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_RetailerModelretailerId",
                table: "Products",
                column: "RetailerModelretailerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Retailers_RetailerModelretailerId",
                table: "Products",
                column: "RetailerModelretailerId",
                principalTable: "Retailers",
                principalColumn: "retailerId");
        }
    }
}
