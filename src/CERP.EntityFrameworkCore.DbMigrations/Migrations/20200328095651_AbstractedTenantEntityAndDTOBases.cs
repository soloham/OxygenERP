using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class AbstractedTenantEntityAndDTOBases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "SETUP",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "PR",
                table: "Payruns",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "HR",
                table: "WorkShifts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "HR",
                table: "Timesheets",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "HR",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "FM",
                table: "SubLedgerRequirements",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "FM",
                table: "SubLedgerRequirement_Account",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "FM",
                table: "COASubCategories",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "FM",
                table: "COASubCategories",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "FM",
                table: "COAs",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "FM",
                table: "AccountStatementTypes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "AvalonERP",
                table: "DictionaryValueTypes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "AvalonERP",
                table: "DictionaryValues",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "AvalonERP",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "AvalonERP",
                table: "Branches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "SETUP",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "PR",
                table: "Payruns");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "HR",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "FM",
                table: "SubLedgerRequirements");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "FM",
                table: "SubLedgerRequirement_Account");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "FM",
                table: "COASubCategories");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "FM",
                table: "AccountStatementTypes");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "AvalonERP",
                table: "DictionaryValueTypes");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "AvalonERP",
                table: "DictionaryValues");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "AvalonERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "AvalonERP",
                table: "Branches");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "FM",
                table: "COASubCategories",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
