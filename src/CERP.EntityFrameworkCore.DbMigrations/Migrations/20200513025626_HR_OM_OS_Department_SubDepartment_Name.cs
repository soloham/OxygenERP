using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_Department_SubDepartment_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentSubDepartmentTemplates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentSubDepartmentTemplates");
        }
    }
}
