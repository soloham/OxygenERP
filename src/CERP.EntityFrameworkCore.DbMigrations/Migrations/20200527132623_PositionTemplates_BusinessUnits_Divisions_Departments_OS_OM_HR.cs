using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class PositionTemplates_BusinessUnits_Divisions_Departments_OS_OM_HR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OS_OrganizationStructureTemplateDepartments_DepartmentTemplates_DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OS_OrganizationStructureTemplateDepartments_LocationTemplates_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OS_OrganizationStructureTemplateDepartments_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OS_OrganizationStructureTemplateDivisions_DivisionTemplates_DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions");

            migrationBuilder.DropForeignKey(
                name: "FK_OS_OrganizationStructureTemplateDivisions_LocationTemplates_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions");

            migrationBuilder.DropForeignKey(
                name: "FK_OS_OrganizationStructureTemplateDivisions_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OS_OrganizationStructureTemplateDivisions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OS_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments");

            migrationBuilder.RenameTable(
                name: "OS_OrganizationStructureTemplateDivisions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                newName: "OrganizationStructureTemplateDivisions",
                newSchema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.RenameTable(
                name: "OS_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                newName: "OrganizationStructureTemplateDepartments",
                newSchema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.RenameIndex(
                name: "IX_OS_OrganizationStructureTemplateDivisions_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                newName: "IX_OrganizationStructureTemplateDivisions_LocationId1");

            migrationBuilder.RenameIndex(
                name: "IX_OS_OrganizationStructureTemplateDivisions_DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                newName: "IX_OrganizationStructureTemplateDivisions_DivisionTemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_OS_OrganizationStructureTemplateDepartments_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                newName: "IX_OrganizationStructureTemplateDepartments_LocationId1");

            migrationBuilder.RenameIndex(
                name: "IX_OS_OrganizationStructureTemplateDepartments_DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                newName: "IX_OrganizationStructureTemplateDepartments_DepartmentTemplateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDivisions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                columns: new[] { "OrganizationStructureTemplateId", "DivisionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "DepartmentTemplateId" });

            migrationBuilder.CreateTable(
                name: "OrganizationStructureTemplateBusinessUnitPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    PositionTemplateId = table.Column<int>(nullable: false),
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
                    ValidityFromDate = table.Column<DateTime>(nullable: false),
                    ValidityToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStructureTemplateBusinessUnitPositions", x => new { x.OrganizationStructureTemplateBusinessUnitId, x.PositionTemplateId });
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateBusinessUnitPositions_PositionTemplates_PositionTemplateId",
                        column: x => x.PositionTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "PositionTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateBusinessUnitPositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateB~",
                        columns: x => new { x.OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId, x.OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId },
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplateBusinessUnits",
                        principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });
                });

            migrationBuilder.CreateTable(
                name: "OrganizationStructureTemplateDepartmentPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    PositionTemplateId = table.Column<int>(nullable: false),
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
                    ValidityFromDate = table.Column<DateTime>(nullable: false),
                    ValidityToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStructureTemplateDepartmentPositions", x => new { x.OrganizationStructureTemplateDepartmentId, x.PositionTemplateId });
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateDepartmentPositions_PositionTemplates_PositionTemplateId",
                        column: x => x.PositionTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "PositionTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateDepartmentPositions_OrganizationStructureTemplateDepartments_OrganizationStructureTemplateDepar~",
                        columns: x => new { x.OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId, x.OrganizationStructureTemplateDepartmentDepartmentTemplateId },
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplateDepartments",
                        principalColumns: new[] { "OrganizationStructureTemplateId", "DepartmentTemplateId" });
                });

            migrationBuilder.CreateTable(
                name: "OrganizationStructureTemplateDivisionPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    PositionTemplateId = table.Column<int>(nullable: false),
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
                    ValidityFromDate = table.Column<DateTime>(nullable: false),
                    ValidityToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStructureTemplateDivisionPositions", x => new { x.OrganizationStructureTemplateDivisionId, x.PositionTemplateId });
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateDivisionPositions_PositionTemplates_PositionTemplateId",
                        column: x => x.PositionTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "PositionTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateDivisionPositions_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateDivisionO~",
                        columns: x => new { x.OrganizationStructureTemplateDivisionOrganizationStructureTemplateId, x.OrganizationStructureTemplateDivisionDivisionTemplateId },
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplateDivisions",
                        principalColumns: new[] { "OrganizationStructureTemplateId", "DivisionTemplateId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnitPositions_PositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions",
                column: "PositionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnitPositions_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId_~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitPositions",
                columns: new[] { "OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartmentPositions_PositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                column: "PositionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartmentPositions_OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId_Orga~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartmentPositions",
                columns: new[] { "OrganizationStructureTemplateDepartmentOrganizationStructureTemplateId", "OrganizationStructureTemplateDepartmentDepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDivisionPositions_PositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                column: "PositionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDivisionPositions_OrganizationStructureTemplateDivisionOrganizationStructureTemplateId_Organiza~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                columns: new[] { "OrganizationStructureTemplateDivisionOrganizationStructureTemplateId", "OrganizationStructureTemplateDivisionDivisionTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_DepartmentTemplates_DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                column: "DepartmentTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "DepartmentTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_LocationTemplates_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                column: "LocationId1",
                principalSchema: "SETUP",
                principalTable: "LocationTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                column: "OrganizationStructureTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_DivisionTemplates_DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                column: "DivisionTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "DivisionTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_LocationTemplates_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                column: "LocationId1",
                principalSchema: "SETUP",
                principalTable: "LocationTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                column: "OrganizationStructureTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_DepartmentTemplates_DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_LocationTemplates_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_DivisionTemplates_DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_LocationTemplates_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropTable(
                name: "OrganizationStructureTemplateBusinessUnitPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "OrganizationStructureTemplateDepartmentPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "OrganizationStructureTemplateDivisionPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDivisions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.RenameTable(
                name: "OrganizationStructureTemplateDivisions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                newName: "OS_OrganizationStructureTemplateDivisions",
                newSchema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.RenameTable(
                name: "OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                newName: "OS_OrganizationStructureTemplateDepartments",
                newSchema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationStructureTemplateDivisions_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions",
                newName: "IX_OS_OrganizationStructureTemplateDivisions_LocationId1");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationStructureTemplateDivisions_DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions",
                newName: "IX_OS_OrganizationStructureTemplateDivisions_DivisionTemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationStructureTemplateDepartments_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments",
                newName: "IX_OS_OrganizationStructureTemplateDepartments_LocationId1");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationStructureTemplateDepartments_DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments",
                newName: "IX_OS_OrganizationStructureTemplateDepartments_DepartmentTemplateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OS_OrganizationStructureTemplateDivisions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions",
                columns: new[] { "OrganizationStructureTemplateId", "DivisionTemplateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OS_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments",
                columns: new[] { "OrganizationStructureTemplateId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OS_OrganizationStructureTemplateDepartments_DepartmentTemplates_DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments",
                column: "DepartmentTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "DepartmentTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OS_OrganizationStructureTemplateDepartments_LocationTemplates_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments",
                column: "LocationId1",
                principalSchema: "SETUP",
                principalTable: "LocationTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OS_OrganizationStructureTemplateDepartments_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments",
                column: "OrganizationStructureTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OS_OrganizationStructureTemplateDivisions_DivisionTemplates_DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions",
                column: "DivisionTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "DivisionTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OS_OrganizationStructureTemplateDivisions_LocationTemplates_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions",
                column: "LocationId1",
                principalSchema: "SETUP",
                principalTable: "LocationTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OS_OrganizationStructureTemplateDivisions_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions",
                column: "OrganizationStructureTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplates",
                principalColumn: "Id");
        }
    }
}
