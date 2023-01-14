using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace adi
{
    /// <inheritdoc />
    public partial class removedKeyfromSupid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_ProductModel_billedproductsupplierId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_Suppliers_supplierId1",
                table: "ProductModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductModel_supplierId1",
                table: "ProductModel");

            migrationBuilder.DropColumn(
                name: "supplierId1",
                table: "ProductModel");

            migrationBuilder.RenameColumn(
                name: "billedproductsupplierId",
                table: "Bills",
                newName: "billedproductproductId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_billedproductsupplierId",
                table: "Bills",
                newName: "IX_Bills_billedproductproductId");

            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "ProductModel",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "ProductModel",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "supplierId",
                table: "ProductModel",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel",
                column: "productId");

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
                name: "FK_ProductModel_Suppliers_supplierId",
                table: "ProductModel",
                column: "supplierId",
                principalTable: "Suppliers",
                principalColumn: "supplierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_ProductModel_billedproductproductId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_Suppliers_supplierId",
                table: "ProductModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductModel_supplierId",
                table: "ProductModel");

            migrationBuilder.RenameColumn(
                name: "billedproductproductId",
                table: "Bills",
                newName: "billedproductsupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_billedproductproductId",
                table: "Bills",
                newName: "IX_Bills_billedproductsupplierId");

            migrationBuilder.AlterColumn<int>(
                name: "supplierId",
                table: "ProductModel",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "ProductModel",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "ProductModel",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "supplierId1",
                table: "ProductModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_supplierId1",
                table: "ProductModel",
                column: "supplierId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_ProductModel_billedproductsupplierId",
                table: "Bills",
                column: "billedproductsupplierId",
                principalTable: "ProductModel",
                principalColumn: "supplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_Suppliers_supplierId1",
                table: "ProductModel",
                column: "supplierId1",
                principalTable: "Suppliers",
                principalColumn: "supplierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
