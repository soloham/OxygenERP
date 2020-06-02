using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class OrganizationStructure_TREE_OS_OM_DIV_BU_TertiaryCompositeKey_BU_DIV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnitCostCenters_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplat~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionCostCenters_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionCostCenters_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionPositions_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionPositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_Bu~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateBusinessUnits_ParentOrganizationStructureTemplateId_Pare~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDivisions_ParentOrganizationStructureTemplateId_ParentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateBusinessUnitCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnitCostCenters_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateI~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

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
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateBusinessUnitCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId", "CostCenterId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDivisions_OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                column: "OS_OrganizationStructureTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                column: "OS_OrganizationStructureTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnitCostCenters_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplat~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplates_OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                column: "OS_OrganizationStructureTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplates_OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                column: "OS_OrganizationStructureTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnitCostCenters_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplat~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplates_OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplates_OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDivisions_OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartments_OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationStructureTemplateBusinessUnitCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.DropColumn(
                name: "BusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters");

            migrationBuilder.AddColumn<int>(
                name: "ParentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationStructureTemplateBusinessUnitCostCenters",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                columns: new[] { "OrganizationStructureTemplateBusinessUnitId", "CostCenterId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDivisions_ParentOrganizationStructureTemplateId_ParentBusinessUnitTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                columns: new[] { "ParentOrganizationStructureTemplateId", "ParentBusinessUnitTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnitCostCenters_OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateI~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                columns: new[] { "OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnitCostCenters_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplat~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnitCostCenters",
                columns: new[] { "OrganizationStructureTemplateBusinessUnitOrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitBusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                column: "OrganizationStructureTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionCostCenters_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters",
                column: "OrganizationStructureTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionCostCenters_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionCostCenters",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionPositions_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                column: "OrganizationStructureTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisionPositions_OrganizationStructureTemplateBusinessUnits_OrganizationStructureTemplateId_Bu~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisionPositions",
                columns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                column: "OrganizationStructureTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_OrganizationStructureTemplateBusinessUnits_ParentOrganizationStructureTemplateId_Pare~",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                columns: new[] { "ParentOrganizationStructureTemplateId", "ParentBusinessUnitTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateBusinessUnits",
                principalColumns: new[] { "OrganizationStructureTemplateId", "BusinessUnitTemplateId" });
        }
    }
}
