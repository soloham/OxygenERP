using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class ApprovalRouteTemplateActiveProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");
        }
    }
}
