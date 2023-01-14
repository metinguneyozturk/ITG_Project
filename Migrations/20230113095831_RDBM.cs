using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace adi
{
    /// <inheritdoc />
    public partial class RDBM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Products_billedProductproductId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_supplierId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_supplierId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Bills_billedProductproductId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "billedProductproductId",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Bills",
                newName: "billedproductsupplierId");

            migrationBuilder.AlterColumn<int>(
                name: "supplierId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "Products",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "supplierId1",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_supplierId1",
                table: "Products",
                column: "supplierId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_billedproductsupplierId",
                table: "Bills",
                column: "billedproductsupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Products_billedproductsupplierId",
                table: "Bills",
                column: "billedproductsupplierId",
                principalTable: "Products",
                principalColumn: "supplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_supplierId1",
                table: "Products",
                column: "supplierId1",
                principalTable: "Suppliers",
                principalColumn: "supplierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Products_billedproductsupplierId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_supplierId1",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_supplierId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Bills_billedproductsupplierId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "supplierId1",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "billedproductsupplierId",
                table: "Bills",
                newName: "productId");

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "Products",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "supplierId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "billedProductproductId",
                table: "Bills",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_supplierId",
                table: "Products",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_billedProductproductId",
                table: "Bills",
                column: "billedProductproductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Products_billedProductproductId",
                table: "Bills",
                column: "billedProductproductId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_supplierId",
                table: "Products",
                column: "supplierId",
                principalTable: "Suppliers",
                principalColumn: "supplierId");
        }
    }
}
