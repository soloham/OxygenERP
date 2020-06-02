using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class OrganizationStructure_TREE_OS_OM_DIV_BU_CompositeKeyComplex_BU_DIV_DEP_POS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplatePositionOrgani~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnits_ParentBUOrganizationStructureTemplateId_Pa~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisions_ParentDIVOrganizationStructureTemplateId_Paren~",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentBUOrganizationStructureTemplateId_ParentBUBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentDIVOrganizationStructureTemplateId_ParentDIVBusinessUnitTemplateId_ParentDIVDiv~",
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
                name: "PK_OrganizationStructureTemplatePositionJobs",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositionOrganizationStructureTemplateId_OrganizationS~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "ParentBUBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentBUId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentBUOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentDEPBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentDEPDepartmentTemplateId",
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
                name: "ParentDEPId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentDEPOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentDIVBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentDIVDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentDIVId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentDIVOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentPositionBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentPositionDepartmentTemplateId",
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
                name: "ParentPositionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "ParentPositionOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplatePositionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplatePositionOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplatePositionPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
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

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                column: "OS_OrganizationStructureTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUnitTemplateId_DivisionTemplateId_HeadDepartm~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "PositionTemplateId", "HeadPositionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUni~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplatePositions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId", "HeadPositionTemplateId", "PositionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplates_OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                column: "OS_OrganizationStructureTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId", "HeadDepartmentTemplateId", "DepartmentTemplateId" });

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
                name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplateId_BusinessUni~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplates_OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

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
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateId",
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

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "HeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "HeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.DropColumn(
                name: "PositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs");

            migrationBuilder.AddColumn<int>(
                name: "ParentBUBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentBUId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentBUOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPHeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDIVBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDIVDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDIVId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDIVOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentPositionBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentPositionDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentPositionDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentPositionHeadDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentPositionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentPositionOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplatePositionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplatePositionOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplatePositionPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OrganizationStructureTemplateId", "PositionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplatePositionJobs",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplatePositionId", "JobTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentBUOrganizationStructureTemplateId_ParentBUBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentBUOrganizationStructureTemplateId", "ParentBUBusinessUnitTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentDIVOrganizationStructureTemplateId_ParentDIVBusinessUnitTemplateId_ParentDIVDiv~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentDIVOrganizationStructureTemplateId", "ParentDIVBusinessUnitTemplateId", "ParentDIVDivisionTemplateId" });

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
                name: "IX_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositionOrganizationStructureTemplateId_OrganizationS~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplatePositionOrganizationStructureTemplateId", "OrganizationStructureTemplatePositionPositionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplatePositionOrgani~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplatePositionOrganizationStructureTemplateId", "OrganizationStructureTemplatePositionPositionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplatePositions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "PositionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                column: "OrganizationStructureTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnits_ParentBUOrganizationStructureTemplateId_Pa~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentBUOrganizationStructureTemplateId", "ParentBUBusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisions_ParentDIVOrganizationStructureTemplateId_Paren~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentDIVOrganizationStructureTemplateId", "ParentDIVBusinessUnitTemplateId", "ParentDIVDivisionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "DivisionTemplateId" });

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
    }
}
