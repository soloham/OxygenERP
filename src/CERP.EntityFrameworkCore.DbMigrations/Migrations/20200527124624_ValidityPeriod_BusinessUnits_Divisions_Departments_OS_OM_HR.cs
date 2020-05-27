using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class ValidityPeriod_BusinessUnits_Divisions_Departments_OS_OM_HR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions");

            migrationBuilder.DropColumn(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDivisions");

            migrationBuilder.DropColumn(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OS_OrganizationStructureTemplateDepartments");

            migrationBuilder.DropColumn(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropColumn(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");
        }
    }
}
