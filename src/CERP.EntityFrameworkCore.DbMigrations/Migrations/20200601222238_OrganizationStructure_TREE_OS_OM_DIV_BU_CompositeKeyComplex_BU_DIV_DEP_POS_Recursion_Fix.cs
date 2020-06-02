using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class OrganizationStructure_TREE_OS_OM_DIV_BU_CompositeKeyComplex_BU_DIV_DEP_POS_Recursion_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartment~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OS_Organi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDepartmentHeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "HeadDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentHeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OS_Organi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId", "OS_OrganizationStructureTemplateDepartmentHeadDepartmentTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartment~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId", "OS_OrganizationStructureTemplateDepartmentHeadDepartmentTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "HeadDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" });
        }
    }
}
