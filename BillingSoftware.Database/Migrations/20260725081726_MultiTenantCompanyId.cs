using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingSoftware.Database.Migrations
{
    /// <inheritdoc />
    public partial class MultiTenantCompanyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Units",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Suppliers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Stocks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "DefaultPrinterName",
                table: "Settings",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "BackupFolderPath",
                table: "Settings",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Settings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);


            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Purchases",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "PurchaseItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Invoices",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "InvoiceItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "FinancialYears",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Customers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Categories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Settings");


            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "FinancialYears");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "DefaultPrinterName",
                table: "Settings",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BackupFolderPath",
                table: "Settings",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
