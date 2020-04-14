using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class SchemaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "OxygenERP");

            migrationBuilder.RenameTable(
                name: "DictionaryValueTypes",
                schema: "AvalonERP",
                newName: "DictionaryValueTypes",
                newSchema: "OxygenERP");

            migrationBuilder.RenameTable(
                name: "DictionaryValues",
                schema: "AvalonERP",
                newName: "DictionaryValues",
                newSchema: "OxygenERP");

            migrationBuilder.RenameTable(
                name: "CustomEntityPropertyChanges",
                schema: "AvalonERP",
                newName: "CustomEntityPropertyChanges",
                newSchema: "OxygenERP");

            migrationBuilder.RenameTable(
                name: "CustomEntityChanges",
                schema: "AvalonERP",
                newName: "CustomEntityChanges",
                newSchema: "OxygenERP");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "AvalonERP",
                newName: "Companies",
                newSchema: "OxygenERP");

            migrationBuilder.RenameTable(
                name: "Branches",
                schema: "AvalonERP",
                newName: "Branches",
                newSchema: "OxygenERP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AvalonERP");

            migrationBuilder.RenameTable(
                name: "DictionaryValueTypes",
                schema: "OxygenERP",
                newName: "DictionaryValueTypes",
                newSchema: "AvalonERP");

            migrationBuilder.RenameTable(
                name: "DictionaryValues",
                schema: "OxygenERP",
                newName: "DictionaryValues",
                newSchema: "AvalonERP");

            migrationBuilder.RenameTable(
                name: "CustomEntityPropertyChanges",
                schema: "OxygenERP",
                newName: "CustomEntityPropertyChanges",
                newSchema: "AvalonERP");

            migrationBuilder.RenameTable(
                name: "CustomEntityChanges",
                schema: "OxygenERP",
                newName: "CustomEntityChanges",
                newSchema: "AvalonERP");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "OxygenERP",
                newName: "Companies",
                newSchema: "AvalonERP");

            migrationBuilder.RenameTable(
                name: "Branches",
                schema: "OxygenERP",
                newName: "Branches",
                newSchema: "AvalonERP");
        }
    }
}
