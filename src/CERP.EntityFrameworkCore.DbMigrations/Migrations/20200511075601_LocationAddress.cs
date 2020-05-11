using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LocationAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationEmail",
                schema: "SETUP",
                table: "LocationTemplates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationFax",
                schema: "SETUP",
                table: "LocationTemplates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationMobile",
                schema: "SETUP",
                table: "LocationTemplates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationPhone",
                schema: "SETUP",
                table: "LocationTemplates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationEmail",
                schema: "SETUP",
                table: "LocationTemplates");

            migrationBuilder.DropColumn(
                name: "LocationFax",
                schema: "SETUP",
                table: "LocationTemplates");

            migrationBuilder.DropColumn(
                name: "LocationMobile",
                schema: "SETUP",
                table: "LocationTemplates");

            migrationBuilder.DropColumn(
                name: "LocationPhone",
                schema: "SETUP",
                table: "LocationTemplates");
        }
    }
}
