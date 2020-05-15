using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_PositionsTasks_Description_KPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DoesKPI",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates");

            migrationBuilder.DropColumn(
                name: "DoesKPI",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates");
        }
    }
}
