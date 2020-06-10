using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_DepartmentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeparmentId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentOrganizationStructureTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentOrganizationStructureTemplateDivisionId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentOrganizationStructureTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentOrganizationStructureTemplateDivisionId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "DeparmentId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
