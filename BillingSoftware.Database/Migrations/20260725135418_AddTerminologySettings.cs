using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingSoftware.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddTerminologySettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerTerm",
                table: "Settings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductTerm",
                table: "Settings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupplierTerm",
                table: "Settings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerTerm",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ProductTerm",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SupplierTerm",
                table: "Settings");
        }
    }
}
