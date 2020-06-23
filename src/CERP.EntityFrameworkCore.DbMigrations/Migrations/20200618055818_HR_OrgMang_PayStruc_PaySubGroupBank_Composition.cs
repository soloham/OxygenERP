using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PaySubGroupBank_Composition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaySubGroupBanks",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaySubGroupBanks",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks",
                columns: new[] { "PaySubGroupId", "BankId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaySubGroupBanks",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaySubGroupBanks",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks",
                columns: new[] { "PaySubGroupId", "Id" });
        }
    }
}
