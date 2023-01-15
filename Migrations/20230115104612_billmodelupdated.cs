using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adi
{
    /// <inheritdoc />
    public partial class billmodelupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "retailerId",
                table: "Bills",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "supplierId",
                table: "Bills",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "retailerId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "supplierId",
                table: "Bills");
        }
    }
}
