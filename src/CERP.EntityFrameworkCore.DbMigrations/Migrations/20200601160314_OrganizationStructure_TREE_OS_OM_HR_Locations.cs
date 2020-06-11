using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class OrganizationStructure_TREE_OS_OM_HR_Locations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDepartments_LocationTemplates_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateDivisions_LocationTemplates_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDivisions_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateDepartments_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropColumn(
                name: "LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnits_LocationId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_LocationTemplates_LocationId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                column: "LocationId",
                principalSchema: "SETUP",
                principalTable: "LocationTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_LocationTemplates_LocationId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnits_LocationId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDivisions_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                column: "LocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateDepartments_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDepartments",
                column: "LocationId1");

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
                name: "FK_OrganizationStructureTemplateDivisions_LocationTemplates_LocationId1",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateDivisions",
                column: "LocationId1",
                principalSchema: "SETUP",
                principalTable: "LocationTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
