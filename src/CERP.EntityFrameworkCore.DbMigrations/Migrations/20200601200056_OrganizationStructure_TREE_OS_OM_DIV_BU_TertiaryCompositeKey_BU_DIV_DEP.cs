using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class OrganizationStructure_TREE_OS_OM_DIV_BU_TertiaryCompositeKey_BU_DIV_DEP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentCostCenters_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDep~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentPositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepar~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateBusinessUnits_ParentBUOrganizationStructureTemplateId_~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_ParentDEPOrganizationStructureTemplateId_P~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDivisions_ParentDIVOrganizationStructureTemplateId_Par~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartmentOr~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_ParentDEPOrganizationStructureTemplateId_Par~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_ParentPositionOrganizationStructureTemplateI~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OS_Organiza~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentDEPOrganizationStructureTemplateId_ParentDEPBusinessUnitTemplateId_ParentDEPDep~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentPositionOrganizationStructureTemplateId_ParentPositionBusinessUnitTemplateId_Pa~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartments_ParentBUOrganizationStructureTemplateId_ParentBUBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartments_ParentDEPOrganizationStructureTemplateId_ParentDEPBusinessUnitTemplateId_ParentDEPD~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartments_ParentDIVOrganizationStructureTemplateId_ParentDIVBusinessUnitTemplateId_ParentDIVD~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartmentPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartmentPositions_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_Orga~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartmentCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartmentCostCenters_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_Or~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "ParentBUBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "ParentBUId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "ParentBUOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "ParentDEPBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "ParentDEPDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "ParentDEPId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "ParentDEPOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "ParentDIVBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "ParentDIVDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "ParentDIVId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "ParentDIVOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentHeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPHeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentPositionDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentPositionHeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

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
                name: "OS_OrganizationStructureTemplateDepartmentHeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDivisionBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDivisionDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OS_Organiza~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId", "OS_OrganizationStructureTemplateDepartmentHeadDepartmentTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentDEPOrganizationStructureTemplateId_ParentDEPBusinessUnitTemplateId_ParentDEPDiv~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentDEPOrganizationStructureTemplateId", "ParentDEPBusinessUnitTemplateId", "ParentDEPDivisionTemplateId", "ParentDEPHeadDepartmentTemplateId", "ParentDEPDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentPositionOrganizationStructureTemplateId_ParentPositionBusinessUnitTemplateId_Pa~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentPositionOrganizationStructureTemplateId", "ParentPositionBusinessUnitTemplateId", "ParentPositionDivisionTemplateId", "ParentPositionHeadDepartmentTemplateId", "ParentPositionDepartmentTemplateId" });

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
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId", "OS_OrganizationStructureTemplateDepartmentHeadDepartmentTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

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
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateBusinessUnits_OS_OrganizationStructureTemplateBusiness~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartmentOr~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId", "OS_OrganizationStructureTemplateDepartmentHeadDepartmentTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_ParentDEPOrganizationStructureTemplateId_Par~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentDEPOrganizationStructureTemplateId", "ParentDEPBusinessUnitTemplateId", "ParentDEPDivisionTemplateId", "ParentDEPHeadDepartmentTemplateId", "ParentDEPDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_ParentPositionOrganizationStructureTemplateI~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentPositionOrganizationStructureTemplateId", "ParentPositionBusinessUnitTemplateId", "ParentPositionDivisionTemplateId", "ParentPositionHeadDepartmentTemplateId", "ParentPositionDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" });
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
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateBusinessUnits_OS_OrganizationStructureTemplateBusiness~",
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
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_BusinessUn~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartmentOr~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_ParentDEPOrganizationStructureTemplateId_Par~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_ParentPositionOrganizationStructureTemplateI~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OS_Organiza~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentDEPOrganizationStructureTemplateId_ParentDEPBusinessUnitTemplateId_ParentDEPDiv~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentPositionOrganizationStructureTemplateId_ParentPositionBusinessUnitTemplateId_Pa~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

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
                name: "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDepartmentHeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentDEPDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentDEPHeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentPositionDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentPositionHeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "HeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

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
                name: "OS_OrganizationStructureTemplateDepartmentHeadDepartmentTemplateId",
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

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "HeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "HeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.AddColumn<int>(
                name: "ParentBUBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentBUId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentBUOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDIVBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDIVDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDIVId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDIVOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartmentPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                columns: new[] { "OrganizationStructureTemplateDepartmentId", "PositionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartmentCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                columns: new[] { "OrganizationStructureTemplateDepartmentId", "CostCenterId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OS_Organiza~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentDEPOrganizationStructureTemplateId_ParentDEPBusinessUnitTemplateId_ParentDEPDep~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentDEPOrganizationStructureTemplateId", "ParentDEPBusinessUnitTemplateId", "ParentDEPDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentPositionOrganizationStructureTemplateId_ParentPositionBusinessUnitTemplateId_Pa~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentPositionOrganizationStructureTemplateId", "ParentPositionBusinessUnitTemplateId", "ParentPositionDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_ParentBUOrganizationStructureTemplateId_ParentBUBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "ParentBUOrganizationStructureTemplateId", "ParentBUBusinessUnitTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_ParentDEPOrganizationStructureTemplateId_ParentDEPBusinessUnitTemplateId_ParentDEPD~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "ParentDEPOrganizationStructureTemplateId", "ParentDEPBusinessUnitTemplateId", "ParentDEPDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_ParentDIVOrganizationStructureTemplateId_ParentDIVBusinessUnitTemplateId_ParentDIVD~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "ParentDIVOrganizationStructureTemplateId", "ParentDIVBusinessUnitTemplateId", "ParentDIVDivisionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartmentPositions_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_Orga~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                columns: new[] { "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartmentCostCenters_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_Or~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                columns: new[] { "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentCostCenters_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDep~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                columns: new[] { "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OrganizationStructureTemplateDepartmentDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentPositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepar~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                columns: new[] { "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OrganizationStructureTemplateDepartmentDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateBusinessUnits_ParentBUOrganizationStructureTemplateId_~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "ParentBUOrganizationStructureTemplateId", "ParentBUBusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_ParentDEPOrganizationStructureTemplateId_P~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "ParentDEPOrganizationStructureTemplateId", "ParentDEPBusinessUnitTemplateId", "ParentDEPDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDivisions_ParentDIVOrganizationStructureTemplateId_Par~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "ParentDIVOrganizationStructureTemplateId", "ParentDIVBusinessUnitTemplateId", "ParentDIVDivisionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartmentOr~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DepartmentTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_ParentDEPOrganizationStructureTemplateId_Par~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentDEPOrganizationStructureTemplateId", "ParentDEPBusinessUnitTemplateId", "ParentDEPDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_ParentPositionOrganizationStructureTemplateI~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentPositionOrganizationStructureTemplateId", "ParentPositionBusinessUnitTemplateId", "ParentPositionDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DepartmentTemplateId" });
        }
    }
}
