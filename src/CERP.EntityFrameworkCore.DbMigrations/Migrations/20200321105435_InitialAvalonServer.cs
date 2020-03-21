using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class InitialAvalonServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AvalonERP");

            migrationBuilder.RenameTable(
                name: "DictionaryValueTypes",
                schema: "CERP",
                newName: "DictionaryValueTypes",
                newSchema: "AvalonERP");

            migrationBuilder.RenameTable(
                name: "DictionaryValues",
                schema: "CERP",
                newName: "DictionaryValues",
                newSchema: "AvalonERP");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "CERP",
                newName: "Companies",
                newSchema: "AvalonERP");

            migrationBuilder.RenameTable(
                name: "Branches",
                schema: "CERP",
                newName: "Branches",
                newSchema: "AvalonERP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CERP");

            migrationBuilder.RenameTable(
                name: "DictionaryValueTypes",
                schema: "AvalonERP",
                newName: "DictionaryValueTypes",
                newSchema: "CERP");

            migrationBuilder.RenameTable(
                name: "DictionaryValues",
                schema: "AvalonERP",
                newName: "DictionaryValues",
                newSchema: "CERP");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "AvalonERP",
                newName: "Companies",
                newSchema: "CERP");

            migrationBuilder.RenameTable(
                name: "Branches",
                schema: "AvalonERP",
                newName: "Branches",
                newSchema: "CERP");
        }
    }
}
