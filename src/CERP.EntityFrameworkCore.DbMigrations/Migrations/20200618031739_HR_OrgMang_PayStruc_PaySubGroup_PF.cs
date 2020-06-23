using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PaySubGroup_PF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeriodFrequency",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodFrequency",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups");
        }
    }
}
