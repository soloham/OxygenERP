using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PayGroup_OrgStrcu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodCutOffEndDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "PeriodCutOffStartDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "PeriodProcessingDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "ReminderIssuanceDays",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalReminderIssuanceDays",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AttendanceCutOffDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeTransactionCutOffDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayrollProcessingDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PayrollReminderIssuanceDays",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalReminderIssuanceDays",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "AttendanceCutOffDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "EmployeeTransactionCutOffDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "PayrollProcessingDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "PayrollReminderIssuanceDays",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.AddColumn<string>(
                name: "PeriodCutOffEndDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeriodCutOffStartDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeriodProcessingDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReminderIssuanceDays",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
