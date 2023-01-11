using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace adi
{
    /// <inheritdoc />
    public partial class BillModelTabelgetirme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_billedProductproductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Products_productId",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_billedProductproductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "billId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "billedProductproductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "totalAmount",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "Products",
                newName: "productId");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Retailers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "productId");

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    billId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productId = table.Column<int>(type: "integer", nullable: false),
                    totalAmount = table.Column<int>(type: "integer", nullable: false),
                    billedProductproductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.billId);
                    table.ForeignKey(
                        name: "FK_Bills_Products_billedProductproductId",
                        column: x => x.billedProductproductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_billedProductproductId",
                table: "Bills",
                column: "billedProductproductId");

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
                name: "FK_Suppliers_Products_productId",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Retailers");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Products",
                newName: "productID");

            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "productID",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "billId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "billedProductproductId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "totalAmount",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_billedProductproductId",
                table: "Products",
                column: "billedProductproductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_billedProductproductId",
                table: "Products",
                column: "billedProductproductId",
                principalTable: "Products",
                principalColumn: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Products_productId",
                table: "Suppliers",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId");
        }
    }
}
