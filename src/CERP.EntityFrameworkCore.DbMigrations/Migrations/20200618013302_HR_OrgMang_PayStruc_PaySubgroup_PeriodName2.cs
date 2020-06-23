using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PaySubgroup_PeriodName2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodName",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.AddColumn<string>(
                name: "PeriodName",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodName",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups");

            migrationBuilder.AddColumn<string>(
                name: "PeriodName",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
