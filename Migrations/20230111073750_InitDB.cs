using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace add
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productName = table.Column<string>(type: "text", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    billId = table.Column<int>(type: "integer", nullable: true),
                    productID = table.Column<int>(type: "integer", nullable: true),
                    totalAmount = table.Column<int>(type: "integer", nullable: true),
                    billedProductproductId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Products_Products_billedProductproductId",
                        column: x => x.billedProductproductId,
                        principalTable: "Products",
                        principalColumn: "productId");
                });

            migrationBuilder.CreateTable(
                name: "Retailers",
                columns: table => new
                {
                    phoneNumber = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retailers", x => x.phoneNumber);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    supplierId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    emailAddress = table.Column<string>(type: "text", nullable: false),
                    phoneNumber = table.Column<string>(type: "text", nullable: true),
                    productId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.supplierId);
                    table.ForeignKey(
                        name: "FK_Suppliers_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_billedProductproductId",
                table: "Products",
                column: "billedProductproductId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_productId",
                table: "Suppliers",
                column: "productId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Retailers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
