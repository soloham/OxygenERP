using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class AddedIdentityCodeinCompanyEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyCode",
                schema: "CERP",
                table: "Companies",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyCode",
                schema: "CERP",
                table: "Companies");
        }
    }
}
