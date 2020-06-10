using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class OrganizationStrucutre_StructureTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropColumn(
                name: "OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OS_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: true);

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
    }
}
