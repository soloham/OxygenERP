using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class SoftCopyCompanyDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoftCopy",
                schema: "SETUP",
                table: "CompanyDocuments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoftCopy",
                schema: "SETUP",
                table: "CompanyDocuments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
