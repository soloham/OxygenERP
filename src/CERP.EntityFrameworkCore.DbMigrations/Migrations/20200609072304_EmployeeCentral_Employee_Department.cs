using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_Department : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_OrganizationStructureTemplateDepartments_DepartmentOrganizationStructureTemplateId_DepartmentOrganizationStructure~",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentOrganizationStructureTemplateId_DepartmentOrganizationStructureTemplateBusinessUnitId_DepartmentOrganiza~",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentOrganizationStructureTemplateDivisionId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentOrganizationStructureTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "HeadDepartmentTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateDivisionId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OrganizationStructureTemplateDepartmentOrga~",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                columns: new[] { "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateDivisionId", "OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_Or~",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                columns: new[] { "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateDivisionId", "OrganizationStructureTemplateDepartmentDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "DepartmentTemplateId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_Or~",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OrganizationStructureTemplateDepartmentOrga~",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "HeadDepartmentTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateDivisionId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentOrganizationStructureTemplateDivisionId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentOrganizationStructureTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentOrganizationStructureTemplateId_DepartmentOrganizationStructureTemplateBusinessUnitId_DepartmentOrganiza~",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                columns: new[] { "DepartmentOrganizationStructureTemplateId", "DepartmentOrganizationStructureTemplateBusinessUnitId", "DepartmentOrganizationStructureTemplateDivisionId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_OrganizationStructureTemplateDepartments_DepartmentOrganizationStructureTemplateId_DepartmentOrganizationStructure~",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                columns: new[] { "DepartmentOrganizationStructureTemplateId", "DepartmentOrganizationStructureTemplateBusinessUnitId", "DepartmentOrganizationStructureTemplateDivisionId", "DepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "DepartmentTemplateId" });
        }
    }
}
