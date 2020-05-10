using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class CompanyLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyLogo",
                schema: "SETUP",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyLogo",
                schema: "SETUP",
                table: "Companies");
        }
    }
}
