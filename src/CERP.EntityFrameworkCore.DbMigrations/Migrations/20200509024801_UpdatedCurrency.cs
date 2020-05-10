using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyNameLong",
                schema: "SETUP",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CurrencyNameLongLocal",
                schema: "SETUP",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CurrencyNameShort",
                schema: "SETUP",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CurrencyNameShortLocal",
                schema: "SETUP",
                table: "Currencies");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyName",
                schema: "SETUP",
                table: "Currencies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyNameLocal",
                schema: "SETUP",
                table: "Currencies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyName",
                schema: "SETUP",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CurrencyNameLocal",
                schema: "SETUP",
                table: "Currencies");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyNameLong",
                schema: "SETUP",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyNameLongLocal",
                schema: "SETUP",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyNameShort",
                schema: "SETUP",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyNameShortLocal",
                schema: "SETUP",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
