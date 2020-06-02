using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class OrganizationStructure_TREE_OS_OM_HR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_LocationTemplates_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnits_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropColumn(
                name: "LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.AddColumn<int>(
                name: "HeadId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadOrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDivisionOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDivisionDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HeadId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadOrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentBUBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentBUId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentBUOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDEPOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDIVDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDIVId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentDIVOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HeadId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "OrganizationStructureTemplateBusinessUnitCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    CostCenterId = table.Column<Guid>(nullable: false),
                    OrganizationStructureTemplateBusinessUnitId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId = table.Column<int>(nullable: false),
                    OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId = table.Column<int>(nullable: false),
                    Percentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStructureTemplateBusinessUnitCostCenters", x => new { x.OrganizationStructureTemplateBusinessUnitId, x.CostCenterId });
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateBusinessUnitCostCenters_DictionaryValues_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateBusinessUnitCostCenters_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplat~",
                        columns: x => new { x.OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId, x.OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId },
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplateBusinessUnits",
                        principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });
                });

            migrationBuilder.CreateTable(
                name: "OrganizationStructureTemplateDepartmentCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    CostCenterId = table.Column<Guid>(nullable: false),
                    OrganizationStructureTemplateDepartmentId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId = table.Column<int>(nullable: false),
                    OrganizationStructureTemplateDepartmentDepartmentTemplateId = table.Column<int>(nullable: false),
                    Percentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStructureTemplateDepartmentCostCenters", x => new { x.OrganizationStructureTemplateDepartmentId, x.CostCenterId });
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateDepartmentCostCenters_DictionaryValues_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateDepartmentCostCenters_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDep~",
                        columns: x => new { x.OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId, x.OrganizationStructureTemplateDepartmentDepartmentTemplateId },
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplateDepartments",
                        principalColumns: new[] { "OrganizationStructureTemplateId", "DepartmentTemplateId" });
                });

            migrationBuilder.CreateTable(
                name: "OrganizationStructureTemplateDivisionCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    CostCenterId = table.Column<Guid>(nullable: false),
                    OrganizationStructureTemplateDivisionId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    OrganizationStructureTemplateDivisionOrganizationStructureTemplateId = table.Column<int>(nullable: false),
                    OrganizationStructureTemplateDivisionDivisionTemplateId = table.Column<int>(nullable: false),
                    Percentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStructureTemplateDivisionCostCenters", x => new { x.OrganizationStructureTemplateDivisionId, x.CostCenterId });
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateDivisionCostCenters_DictionaryValues_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateDivisionCostCenters_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateDivisio~",
                        columns: x => new { x.OrganizationStructureTemplateDivisionOrganizationStructureTemplateId, x.OrganizationStructureTemplateDivisionDivisionTemplateId },
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplateDivisions",
                        principalColumns: new[] { "OrganizationStructureTemplateId", "DivisionTemplateId" });
                });

            migrationBuilder.CreateTable(
                name: "OrganizationStructureTemplatePositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    PositionTemplateId = table.Column<int>(nullable: false),
                    OrganizationStructureTemplateId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    ValidityFromDate = table.Column<DateTime>(nullable: false),
                    ValidityToDate = table.Column<DateTime>(nullable: false),
                    ParentBUOrganizationStructureTemplateId = table.Column<int>(nullable: false),
                    ParentBUBusinessUnitTemplateId = table.Column<int>(nullable: false),
                    ParentBUId = table.Column<int>(nullable: true),
                    ParentDIVOrganizationStructureTemplateId = table.Column<int>(nullable: true),
                    ParentDIVDivisionTemplateId = table.Column<int>(nullable: true),
                    ParentDIVId = table.Column<int>(nullable: true),
                    ParentDEPOrganizationStructureTemplateId = table.Column<int>(nullable: true),
                    ParentDEPDepartmentTemplateId = table.Column<int>(nullable: true),
                    ParentDEPId = table.Column<int>(nullable: true),
                    ParentPositionOrganizationStructureTemplateId = table.Column<int>(nullable: true),
                    ParentPositionDepartmentTemplateId = table.Column<int>(nullable: true),
                    ParentPositionId = table.Column<int>(nullable: true),
                    OS_OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId = table.Column<int>(nullable: true),
                    OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId = table.Column<int>(nullable: true),
                    OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId = table.Column<int>(nullable: true),
                    OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId = table.Column<int>(nullable: true),
                    OS_OrganizationStructureTemplateDivisionDivisionTemplateId = table.Column<int>(nullable: true),
                    OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStructureTemplatePositions", x => new { x.OrganizationStructureTemplateId, x.PositionTemplateId });
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                        column: x => x.OrganizationStructureTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplatePositions_PositionTemplates_PositionTemplateId",
                        column: x => x.PositionTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "PositionTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnits_OS_OrganizationStructureTemplateBusinessUn~",
                        columns: x => new { x.OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId, x.OS_OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId },
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplateBusinessUnits",
                        principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateDepartmentOr~",
                        columns: x => new { x.OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId, x.OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId },
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplateDepartments",
                        principalColumns: new[] { "OrganizationStructureTemplateId", "DepartmentTemplateId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisions_OS_OrganizationStructureTemplateDivisionOrgani~",
                        columns: x => new { x.OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId, x.OS_OrganizationStructureTemplateDivisionDivisionTemplateId },
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplateDivisions",
                        principalColumns: new[] { "OrganizationStructureTemplateId", "DivisionTemplateId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateBusinessUnits_ParentBUOrganizationStructureTemplateId_Pa~",
                        columns: x => new { x.ParentBUOrganizationStructureTemplateId, x.ParentBUBusinessUnitTemplateId },
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplateBusinessUnits",
                        principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_ParentDEPOrganizationStructureTemplateId_Par~",
                        columns: x => new { x.ParentDEPOrganizationStructureTemplateId, x.ParentDEPDepartmentTemplateId },
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplateDepartments",
                        principalColumns: new[] { "OrganizationStructureTemplateId", "DepartmentTemplateId" });
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDivisions_ParentDIVOrganizationStructureTemplateId_Paren~",
                        columns: x => new { x.ParentDIVOrganizationStructureTemplateId, x.ParentDIVDivisionTemplateId },
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplateDivisions",
                        principalColumns: new[] { "OrganizationStructureTemplateId", "DivisionTemplateId" });
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplatePositions_OrganizationStructureTemplateDepartments_ParentPositionOrganizationStructureTemplateI~",
                        columns: x => new { x.ParentPositionOrganizationStructureTemplateId, x.ParentPositionDepartmentTemplateId },
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplateDepartments",
                        principalColumns: new[] { "OrganizationStructureTemplateId", "DepartmentTemplateId" });
                });

            migrationBuilder.CreateTable(
                name: "OrganizationStructureTemplatePositionJobs",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    JobTemplateId = table.Column<int>(nullable: false),
                    OrganizationStructureTemplatePositionId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    OrganizationStructureTemplatePositionOrganizationStructureTemplateId = table.Column<int>(nullable: false),
                    OrganizationStructureTemplatePositionPositionTemplateId = table.Column<int>(nullable: false),
                    LevelId = table.Column<Guid>(nullable: false),
                    EmployeeClassId = table.Column<Guid>(nullable: false),
                    ContractTypeId = table.Column<Guid>(nullable: false),
                    ValidityFromDate = table.Column<DateTime>(nullable: false),
                    ValidityToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStructureTemplatePositionJobs", x => new { x.OrganizationStructureTemplatePositionId, x.JobTemplateId });
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplatePositionJobs_DictionaryValues_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplatePositionJobs_DictionaryValues_EmployeeClassId",
                        column: x => x.EmployeeClassId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplatePositionJobs_JobTemplates_JobTemplateId",
                        column: x => x.JobTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "JobTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplatePositionJobs_DictionaryValues_LevelId",
                        column: x => x.LevelId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositions_OrganizationStructureTemplatePositionOrgani~",
                        columns: x => new { x.OrganizationStructureTemplatePositionOrganizationStructureTemplateId, x.OrganizationStructureTemplatePositionPositionTemplateId },
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplatePositions",
                        principalColumns: new[] { "OrganizationStructureTemplateId", "PositionTemplateId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDivisions_HeadOrganizationStructureTemplateDivisionId_HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                columns: new[] { "HeadOrganizationStructureTemplateDivisionId", "HeadPositionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDivisions_ParentOrganizationStructureTemplateId_ParentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                columns: new[] { "ParentOrganizationStructureTemplateId", "ParentBusinessUnitTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_HeadOrganizationStructureTemplateDepartmentId_HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "HeadOrganizationStructureTemplateDepartmentId", "HeadPositionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_ParentBUOrganizationStructureTemplateId_ParentBUBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "ParentBUOrganizationStructureTemplateId", "ParentBUBusinessUnitTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_ParentDEPOrganizationStructureTemplateId_ParentDEPDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "ParentDEPOrganizationStructureTemplateId", "ParentDEPDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_ParentDIVOrganizationStructureTemplateId_ParentDIVDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "ParentDIVOrganizationStructureTemplateId", "ParentDIVDivisionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnits_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                column: "PayGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnits_HeadOrganizationStructureTemplateBusinessUnitId_HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                columns: new[] { "HeadOrganizationStructureTemplateBusinessUnitId", "HeadPositionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnitCostCenters_CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnitCostCenters_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateI~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                columns: new[] { "OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartmentCostCenters_CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartmentCostCenters_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_Or~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentCostCenters",
                columns: new[] { "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDivisionCostCenters_CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDivisionCostCenters_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId_Organi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters",
                columns: new[] { "OrganizationStructureTemplateDivisionOrganizationStructureTemplateId", "OrganizationStructureTemplateDivisionDivisionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositionJobs_ContractTypeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositionJobs_EmployeeClassId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                column: "EmployeeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositionJobs_JobTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                column: "JobTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositionJobs_LevelId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositionJobs_OrganizationStructureTemplatePositionOrganizationStructureTemplateId_OrganizationS~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositionJobs",
                columns: new[] { "OrganizationStructureTemplatePositionOrganizationStructureTemplateId", "OrganizationStructureTemplatePositionPositionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_PositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                column: "PositionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId_OS_Organi~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_OS_Organiza~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId_OS_Organizati~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "OS_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId", "OS_OrganizationStructureTemplateDivisionDivisionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentBUOrganizationStructureTemplateId_ParentBUBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentBUOrganizationStructureTemplateId", "ParentBUBusinessUnitTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentDEPOrganizationStructureTemplateId_ParentDEPDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentDEPOrganizationStructureTemplateId", "ParentDEPDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentDIVOrganizationStructureTemplateId_ParentDIVDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentDIVOrganizationStructureTemplateId", "ParentDIVDivisionTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplatePositions_ParentPositionOrganizationStructureTemplateId_ParentPositionDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplatePositions",
                columns: new[] { "ParentPositionOrganizationStructureTemplateId", "ParentPositionDepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_PayGroupes_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                column: "PayGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayGroupes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateBusinessUnitPositions_HeadOrganizationStructureTempl~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                columns: new[] { "HeadOrganizationStructureTemplateBusinessUnitId", "HeadPositionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnitPositions",
                principalColumns: new[] { "OrganizationStructureTemplateBusinessUnitId", "PositionTemplateId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartmentPositions_HeadOrganizationStructureTemplateD~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "HeadOrganizationStructureTemplateDepartmentId", "HeadPositionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartmentPositions",
                principalColumns: new[] { "OrganizationStructureTemplateDepartmentId", "PositionTemplateId" },
                onDelete: ReferentialAction.Cascade);

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
                columns: new[] { "ParentDEPOrganizationStructureTemplateId", "ParentDEPDepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDivisions_ParentDIVOrganizationStructureTemplateId_Par~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "ParentDIVOrganizationStructureTemplateId", "ParentDIVDivisionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisions",
                principalColumns: new[] { "OrganizationStructureTemplateId", "DivisionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateDivisionPositions_HeadOrganizationStructureTemplateDivis~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                columns: new[] { "HeadOrganizationStructureTemplateDivisionId", "HeadPositionTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDivisionPositions",
                principalColumns: new[] { "OrganizationStructureTemplateDivisionId", "PositionTemplateId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateBusinessUnits_ParentOrganizationStructureTemplateId_Pare~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                columns: new[] { "ParentOrganizationStructureTemplateId", "ParentBusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_PayGroupes_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateBusinessUnitPositions_HeadOrganizationStructureTempl~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepartmentPositions_HeadOrganizationStructureTemplateD~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

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
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateDivisionPositions_HeadOrganizationStructureTemplateDivis~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateBusinessUnits_ParentOrganizationStructureTemplateId_Pare~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropTable(
                name: "OrganizationStructureTemplateBusinessUnitCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "OrganizationStructureTemplateDepartmentCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "OrganizationStructureTemplateDivisionCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "OrganizationStructureTemplatePositionJobs",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "OrganizationStructureTemplatePositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDivisions_HeadOrganizationStructureTemplateDivisionId_HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDivisions_ParentOrganizationStructureTemplateId_ParentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartments_HeadOrganizationStructureTemplateDepartmentId_HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartments_ParentBUOrganizationStructureTemplateId_ParentBUBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartments_ParentDEPOrganizationStructureTemplateId_ParentDEPDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartments_ParentDIVOrganizationStructureTemplateId_ParentDIVDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnits_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnits_HeadOrganizationStructureTemplateBusinessUnitId_HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropColumn(
                name: "HeadId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropColumn(
                name: "HeadOrganizationStructureTemplateDivisionId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropColumn(
                name: "HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropColumn(
                name: "ParentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropColumn(
                name: "ParentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropColumn(
                name: "HeadId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "HeadOrganizationStructureTemplateDepartmentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

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
                name: "HeadId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropColumn(
                name: "HeadOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropColumn(
                name: "HeadPositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropColumn(
                name: "PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDivisionOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDivisionDivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateDepartmentDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnits_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                column: "LocationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_LocationTemplates_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                column: "LocationId1",
                principalSchema: "SETUP",
                principalTable: "LocationTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
