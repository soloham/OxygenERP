using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_All : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActivationDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivationDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivationDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivationDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ActivationDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates");

            migrationBuilder.DropColumn(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates");

            migrationBuilder.DropColumn(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates");

            migrationBuilder.DropColumn(
                name: "ActivationDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropColumn(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropColumn(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropColumn(
                name: "ActivationDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates");

            migrationBuilder.DropColumn(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates");

            migrationBuilder.DropColumn(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates");

            migrationBuilder.DropColumn(
                name: "ActivationDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropColumn(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropColumn(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");
        }
    }
}
