using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class OrganizationStructure_TREE_OS_OM_DIV_BU_CompositeKeyComplex_BU_DIV_DEP_POS_Recursion_HeadRequirementFix4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentCostCenters_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentPositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_Bu~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUni~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUnit~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUnitTe~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUnitTemplateId_DivisionTemplateId_HeadDepartm~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositionJobs",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUnitTemplateId_DivisionTemplateId_Departmen~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartmentPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartmentCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "HeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositionJobs",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId", "JobTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartmentPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "PositionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartmentCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "CostCenterId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUnitTemplateId_DivisionTemplateId_DepartmentT~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "PositionTemplateId", "HeadPositionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OS_Organi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentCostCenters_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentPositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_Bu~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartment~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUni~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplatePositions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUnit~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUnitTe~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "PositionTemplateId", "HeadPositionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplatePositions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentCostCenters_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentPositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_Bu~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartment~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUni~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUnit~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUnitTe~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUnitTemplateId_DivisionTemplateId_DepartmentT~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositionJobs",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OS_Organi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartmentPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartmentCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

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
                name: "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.AddColumn<int>(
                name: "HeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositionJobs",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId", "JobTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartmentPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "PositionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartmentCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "CostCenterId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUnitTemplateId_DivisionTemplateId_HeadDepartm~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "PositionTemplateId", "HeadPositionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUnitTemplateId_DivisionTemplateId_Departmen~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "HeadDepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentCostCenters_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentPositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_Bu~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "HeadDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUni~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplatePositions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUnit~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUnitTe~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "PositionTemplateId", "HeadPositionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplatePositions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
