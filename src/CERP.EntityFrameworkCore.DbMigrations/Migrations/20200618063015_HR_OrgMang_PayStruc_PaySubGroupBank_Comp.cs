using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PaySubGroupBank_Comp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaySubGroupBanks",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaySubGroupBanks",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks",
                columns: new[] { "PaySubGroupId", "BankId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaySubGroupBanks",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaySubGroupBanks",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks",
                columns: new[] { "PaySubGroupId", "BankId" });
        }
    }
}
