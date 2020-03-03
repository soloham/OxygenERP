using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class DictionaryValueEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ValueTypeCode",
                schema: "CERP",
                table: "DictionaryValueTypes",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueTypeCode",
                schema: "CERP",
                table: "DictionaryValueTypes");
        }
    }
}
