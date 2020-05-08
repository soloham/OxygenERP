using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LocationsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationAbbreviation",
                schema: "SETUP",
                table: "LocationTemplates");

            migrationBuilder.AddColumn<string>(
                name: "LocationCode",
                schema: "SETUP",
                table: "LocationTemplates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationCode",
                schema: "SETUP",
                table: "LocationTemplates");

            migrationBuilder.AddColumn<string>(
                name: "LocationAbbreviation",
                schema: "SETUP",
                table: "LocationTemplates",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
