using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class BusinessUnits_Divisions_Departments_OS_OM_HR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LegalEntityId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplates",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.CreateTable(
                name: "OrganizationStructureTemplateBusinessUnits",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    BusinessUnitTemplateId = table.Column<int>(nullable: false),
                    OrganizationStructureTemplateId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    LocationId1 = table.Column<Guid>(nullable: true),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStructureTemplateBusinessUnits", x => new { x.OrganizationStructureTemplateId, x.BusinessUnitTemplateId });
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateBusinessUnits_BusinessUnitTemplates_BusinessUnitTemplateId",
                        column: x => x.BusinessUnitTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "BusinessUnitTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateBusinessUnits_LocationTemplates_LocationId1",
                        column: x => x.LocationId1,
                        principalSchema: "SETUP",
                        principalTable: "LocationTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                        column: x => x.OrganizationStructureTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OS_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    DepartmentTemplateId = table.Column<int>(nullable: false),
                    OrganizationStructureTemplateId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    LocationId1 = table.Column<Guid>(nullable: true),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OS_OrganizationStructureTemplateDepartments", x => new { x.OrganizationStructureTemplateId, x.DepartmentTemplateId });
                    table.ForeignKey(
                        name: "FK_OS_OrganizationStructureTemplateDepartments_DepartmentTemplates_DepartmentTemplateId",
                        column: x => x.DepartmentTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "DepartmentTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OS_OrganizationStructureTemplateDepartments_LocationTemplates_LocationId1",
                        column: x => x.LocationId1,
                        principalSchema: "SETUP",
                        principalTable: "LocationTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OS_OrganizationStructureTemplateDepartments_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                        column: x => x.OrganizationStructureTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OS_OrganizationStructureTemplateDivisions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    DivisionTemplateId = table.Column<int>(nullable: false),
                    OrganizationStructureTemplateId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    LocationId1 = table.Column<Guid>(nullable: true),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OS_OrganizationStructureTemplateDivisions", x => new { x.OrganizationStructureTemplateId, x.DivisionTemplateId });
                    table.ForeignKey(
                        name: "FK_OS_OrganizationStructureTemplateDivisions_DivisionTemplates_DivisionTemplateId",
                        column: x => x.DivisionTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "DivisionTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OS_OrganizationStructureTemplateDivisions_LocationTemplates_LocationId1",
                        column: x => x.LocationId1,
                        principalSchema: "SETUP",
                        principalTable: "LocationTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OS_OrganizationStructureTemplateDivisions_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                        column: x => x.OrganizationStructureTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplates_LegalEntityId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplates",
                column: "LegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnits_BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                column: "BusinessUnitTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnits_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                column: "LocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_OS_OrganizationStructureTemplateDepartments_DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments",
                column: "DepartmentTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OS_OrganizationStructureTemplateDepartments_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments",
                column: "LocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_OS_OrganizationStructureTemplateDivisions_DivisionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions",
                column: "DivisionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OS_OrganizationStructureTemplateDivisions_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions",
                column: "LocationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplates_Companies_LegalEntityId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplates",
                column: "LegalEntityId",
                principalSchema: "SETUP",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplates_Companies_LegalEntityId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplates");

            migrationBuilder.DropTable(
                name: "OrganizationStructureTemplateBusinessUnits",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "OS_OrganizationStructureTemplateDepartments",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "OS_OrganizationStructureTemplateDivisions",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplates_LegalEntityId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplates");

            migrationBuilder.DropColumn(
                name: "LegalEntityId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplates");
        }
    }
}
