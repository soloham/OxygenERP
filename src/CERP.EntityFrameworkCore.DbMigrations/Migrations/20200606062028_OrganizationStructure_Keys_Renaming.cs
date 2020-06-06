using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class OrganizationStructure_Keys_Renaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnitCostCenters_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplat~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnitPositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateI~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions");

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
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartment~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionCostCenters_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_Busi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionPositions_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_Busine~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions");

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
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplatePositionOrgani~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateId_OS_Organizati~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositionJobs",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDivisions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDivisionPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDivisionCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateBusinessUnitPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateBusinessUnitCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplatePositionBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplatePositionDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplatePositionDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "PositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions");

            migrationBuilder.DropColumn(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions");

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters");

            migrationBuilder.DropColumn(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters");

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions");

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplatePositionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "OrganizationStructureTemplateDepartmentId", "PositionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositionJobs",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "OrganizationStructureTemplateDepartmentId", "OrganizationStructureTemplatePositionId", "JobTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDivisions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "DivisionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDivisionPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "PositionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDivisionCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "CostCenterId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "DepartmentTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartmentPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "OrganizationStructureTemplateDepartmentId", "PositionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartmentCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "OrganizationStructureTemplateDepartmentId", "CostCenterId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateBusinessUnitPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "PositionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateBusinessUnitCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "CostCenterId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateId_OS_Organizati~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateId", "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateBusinessUnitId", "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateDivisionId", "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateDepartmentId", "OS_OrganizationStructureTemplatePositionPositionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OS_Organi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateBusinessUnitId", "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateDivisionId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnitCostCenters_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplat~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnitPositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateI~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentCostCenters_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "OrganizationStructureTemplateDepartmentId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentPositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_Or~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "OrganizationStructureTemplateDepartmentId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_Organiza~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_Organization~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "DivisionTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartment~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateBusinessUnitId", "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateDivisionId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "DepartmentTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionCostCenters_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_Orga~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "DivisionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionPositions_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_Organi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "DivisionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_Organizati~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_Organizatio~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "OrganizationStructureTemplateDepartmentId", "OrganizationStructureTemplatePositionId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplatePositions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "OrganizationStructureTemplateDepartmentId", "PositionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_Organizati~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_OrganizationSt~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "DivisionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_Organization~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "OrganizationStructureTemplateDepartmentId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "DepartmentTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplatePositionOrgani~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateId", "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateBusinessUnitId", "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateDivisionId", "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateDepartmentId", "OS_OrganizationStructureTemplatePositionPositionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplatePositions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "OrganizationStructureTemplateDepartmentId", "PositionTemplateId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnitCostCenters_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplat~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnitPositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateI~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentCostCenters_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartmentPositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_Or~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_Organiza~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_Organization~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartment~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionCostCenters_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_Orga~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionPositions_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_Organi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_Organizati~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_Organizatio~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_Organizati~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_OrganizationSt~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateId_Organization~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplatePositionOrgani~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateId_OS_Organizati~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositionJobs",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDivisions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDivisionPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDivisionCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateBusinessUnitPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateBusinessUnitCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplatePositionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplatePositionBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplatePositionDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplatePositionDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId",
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
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "PositionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositionJobs",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "PositionTemplateId", "JobTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDivisions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDivisionPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "PositionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDivisionCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "CostCenterId" });

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateBusinessUnitPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "PositionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateBusinessUnitCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "CostCenterId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateId_OS_Organizati~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateId", "OS_OrganizationStructureTemplatePositionBusinessUnitTemplateId", "OS_OrganizationStructureTemplatePositionDivisionTemplateId", "OS_OrganizationStructureTemplatePositionDepartmentTemplateId", "OS_OrganizationStructureTemplatePositionPositionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OS_Organi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnitCostCenters_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplat~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnitPositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateI~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });

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
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartment~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentBusinessUnitTemplateId", "OS_OrganizationStructureTemplateDepartmentDivisionTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionCostCenters_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_Busi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionPositions_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateId_Busine~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" });

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
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "PositionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplatePositions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "PositionTemplateId" });

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
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplatePositionOrgani~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplatePositionOrganizationStructureTemplateId", "OS_OrganizationStructureTemplatePositionBusinessUnitTemplateId", "OS_OrganizationStructureTemplatePositionDivisionTemplateId", "OS_OrganizationStructureTemplatePositionDepartmentTemplateId", "OS_OrganizationStructureTemplatePositionPositionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplatePositions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "DepartmentTemplateId", "PositionTemplateId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
