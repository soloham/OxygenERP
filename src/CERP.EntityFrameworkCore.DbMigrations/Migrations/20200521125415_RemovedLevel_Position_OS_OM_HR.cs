using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class RemovedLevel_Position_OS_OM_HR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
