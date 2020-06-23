using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PaySubGroup_Periods_Composition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PayPeriods",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropIndex(
                name: "IX_PayPeriods_PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayPeriods",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                columns: new[] { "PaySubGroupId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PayPeriods",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayPeriods",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PayPeriods_PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                column: "PaySubGroupId");
        }
    }
}
