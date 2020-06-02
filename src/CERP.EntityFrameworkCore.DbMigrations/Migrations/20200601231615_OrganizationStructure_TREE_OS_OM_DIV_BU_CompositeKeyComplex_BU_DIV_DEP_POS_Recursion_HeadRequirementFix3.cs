using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class OrganizationStructure_TREE_OS_OM_DIV_BU_CompositeKeyComplex_BU_DIV_DEP_POS_Recursion_HeadRequirementFix3 : Migration
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
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateBusinessUnits_OS_OrganizationStructureTemplateBusiness~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_Business~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDivisions_OS_OrganizationStructureTemplateDivisionOrga~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_BusinessUnit~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartment~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUni~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnits_OS_OrganizationStructureTemplateBusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateBusinessUnitO~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisions_OS_OrganizationStructureTemplateDivisionOrgani~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateDivisionOrganizat~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_BusinessUnitTe~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartmentOr~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartmentOrgan~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

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
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId_OS_Organi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId_Organization~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId_OS_Organizati~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId_OrganizationStru~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OS_Organiza~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OrganizationSt~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUnitTemplateId_DivisionTemplateId_DepartmentT~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplateId_BusinessUnitTemplateId_DivisionTemplateId_Departme~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId_OS_Orga~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId_OS_Organiza~",
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

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartmentCostCenters_OrganizationStructureTemplateId_BusinessUnitTemplateId_DivisionTemplateId~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDivisionBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDivisionDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDivisionBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDivisionDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDivisionOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId",
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
                name: "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDivisionBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDivisionDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.AddColumn<int>(
                name: "HeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" });

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
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_Business~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_BusinessUnit~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" },
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUni~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplatePositions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_BusinessUnitTe~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" });

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
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_Business~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_BusinessUnit~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUni~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_BusinessUnitTe~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

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

            migrationBuilder.DropColumn(
                name: "HeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDivisionBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDivisionDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDivisionBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDivisionDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDivisionOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

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
                name: "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDivisionBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDivisionDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId_OS_Organi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId_Organization~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId_OS_Organizati~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDivisionBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDivisionDivisionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId_OrganizationStru~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateDivisionOrganizationStructureTemplateId", "OrganizationStructureTemplateDivisionBusinessUnitTemplateId", "OrganizationStructureTemplateDivisionDivisionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OS_Organiza~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OrganizationSt~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OrganizationStructureTemplateDepartmentDivisionTemplateId", "OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUnitTemplateId_DivisionTemplateId_DepartmentT~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "PositionTemplateId", "HeadPositionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplateId_BusinessUnitTemplateId_DivisionTemplateId_Departme~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId_OS_Orga~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId_OS_Organiza~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDivisionBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDivisionDivisionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OS_Organi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartmentCostCenters_OrganizationStructureTemplateId_BusinessUnitTemplateId_DivisionTemplateId~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" });

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
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateBusinessUnits_OS_OrganizationStructureTemplateBusiness~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_Business~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDivisions_OS_OrganizationStructureTemplateDivisionOrga~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDivisionBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDivisionDivisionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_BusinessUnit~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" });

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
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUni~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplatePositions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnits_OS_OrganizationStructureTemplateBusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateBusinessUnitO~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisions_OS_OrganizationStructureTemplateDivisionOrgani~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDivisionBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDivisionDivisionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateDivisionOrganizat~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateDivisionOrganizationStructureTemplateId", "OrganizationStructureTemplateDivisionBusinessUnitTemplateId", "OrganizationStructureTemplateDivisionDivisionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_BusinessUnitTe~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartmentOr~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartmentOrgan~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OrganizationStructureTemplateDepartmentDivisionTemplateId", "OrganizationStructureTemplateDepartmentDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUnit~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" },
                onDelete: ReferentialAction.Cascade);

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
    }
}
