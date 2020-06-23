using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PaySubgroup_PeriodName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PeriodName",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodName",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");
        }
    }
}
