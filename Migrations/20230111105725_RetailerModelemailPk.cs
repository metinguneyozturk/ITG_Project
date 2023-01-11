using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adi
{
    /// <inheritdoc />
    public partial class RetailerModelemailPk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Retailers",
                table: "Retailers");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Retailers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "phoneNumber",
                table: "Retailers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Retailers",
                table: "Retailers",
                column: "email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Retailers",
                table: "Retailers");

            migrationBuilder.AlterColumn<string>(
                name: "phoneNumber",
                table: "Retailers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Retailers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Retailers",
                table: "Retailers",
                column: "phoneNumber");
        }
    }
}
