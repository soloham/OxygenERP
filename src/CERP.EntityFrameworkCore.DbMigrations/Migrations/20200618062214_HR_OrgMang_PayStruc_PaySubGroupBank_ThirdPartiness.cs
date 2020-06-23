using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PaySubGroupBank_ThirdPartiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaySubGroupBanks_PaySubGroups_PS_PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks");

            migrationBuilder.DropIndex(
                name: "IX_PaySubGroupBanks_PS_PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks");

            migrationBuilder.DropColumn(
                name: "PS_PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks");

            migrationBuilder.AddColumn<bool>(
                name: "IsThirdParty",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsThirdParty",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks");

            migrationBuilder.AddColumn<int>(
                name: "PS_PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaySubGroupBanks_PS_PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks",
                column: "PS_PaySubGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaySubGroupBanks_PaySubGroups_PS_PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks",
                column: "PS_PaySubGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PaySubGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
