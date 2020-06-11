using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_DepartmentsPositions_CostCenters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentTemplates_DictionaryValues_CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionTemplates_DictionaryValues_CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropIndex(
                name: "IX_PositionTemplates_CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentTemplates_CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.CreateTable(
                name: "DepartmentCostCenterTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    DepartmentTemplateId = table.Column<int>(nullable: false),
                    CostCenterId = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    Percentage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentCostCenterTemplates", x => new { x.DepartmentTemplateId, x.CostCenterId });
                    table.ForeignKey(
                        name: "FK_DepartmentCostCenterTemplates_DictionaryValues_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartmentCostCenterTemplates_DepartmentTemplates_DepartmentTemplateId",
                        column: x => x.DepartmentTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "DepartmentTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PositionCostCenterTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    PositionTemplateId = table.Column<int>(nullable: false),
                    CostCenterId = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    Percentage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionCostCenterTemplates", x => new { x.PositionTemplateId, x.CostCenterId });
                    table.ForeignKey(
                        name: "FK_PositionCostCenterTemplates_DictionaryValues_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionCostCenterTemplates_PositionTemplates_PositionTemplateId",
                        column: x => x.PositionTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "PositionTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCostCenterTemplates_CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentCostCenterTemplates",
                column: "CostCenterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PositionCostCenterTemplates_CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionCostCenterTemplates",
                column: "CostCenterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentCostCenterTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "PositionCostCenterTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.AddColumn<Guid>(
                name: "CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<Guid>(
                name: "CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.CreateIndex(
                name: "IX_PositionTemplates_CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentTemplates_CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                column: "CostCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentTemplates_DictionaryValues_CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                column: "CostCenterId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionTemplates_DictionaryValues_CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                column: "CostCenterId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");
        }
    }
}
