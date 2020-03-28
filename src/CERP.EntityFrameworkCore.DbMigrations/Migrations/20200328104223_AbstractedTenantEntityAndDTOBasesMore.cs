using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class AbstractedTenantEntityAndDTOBasesMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "SETUP",
                table: "Positions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "PR",
                table: "PayrunsPayslips",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "PR",
                table: "PayrunsDetails",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "HR",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "FM",
                table: "COAHeadAccounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "SETUP",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "PR",
                table: "PayrunsPayslips");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "PR",
                table: "PayrunsDetails");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "FM",
                table: "COAHeadAccounts");
        }
    }
}
