using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_CompensationMatrix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoesKPI",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "CompensationMatrixTemplates");

            migrationBuilder.AddColumn<string>(
                name: "CompensationMatrixData",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "CompensationMatrixTemplates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompensationMatrixData",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "CompensationMatrixTemplates");

            migrationBuilder.AddColumn<bool>(
                name: "DoesKPI",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "CompensationMatrixTemplates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
