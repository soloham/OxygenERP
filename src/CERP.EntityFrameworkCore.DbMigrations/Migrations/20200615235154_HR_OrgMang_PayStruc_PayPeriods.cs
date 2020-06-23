using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PayPeriods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayGroups_PayFrequencies_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropIndex(
                name: "IX_PayGroups_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropColumn(
                name: "FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.AddColumn<int>(
                name: "PayGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PayPeriods_PayGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                column: "PayGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayPeriods_PayGroups_PayGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                column: "PayGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayPeriods_PayGroups_PayGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropIndex(
                name: "IX_PayPeriods_PayGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "PayGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.AddColumn<int>(
                name: "FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PayGroups_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                column: "FrequencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayGroups_PayFrequencies_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                column: "FrequencyId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayFrequencies",
                principalColumn: "Id");
        }
    }
}
