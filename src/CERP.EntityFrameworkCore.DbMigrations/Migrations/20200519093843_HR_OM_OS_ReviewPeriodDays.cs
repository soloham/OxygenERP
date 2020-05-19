using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_ReviewPeriodDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "FunctionTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "CompensationMatrixTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates");

            migrationBuilder.DropColumn(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates");

            migrationBuilder.DropColumn(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropColumn(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates");

            migrationBuilder.DropColumn(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "FunctionTemplates");

            migrationBuilder.DropColumn(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropColumn(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "CompensationMatrixTemplates");

            migrationBuilder.DropColumn(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates");
        }
    }
}
