using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_Department_Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateDivisionId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateDivisionId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
