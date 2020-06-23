using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PayGroup_Period_Freq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodEndDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "PeriodStartDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.AddColumn<int>(
                name: "FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                nullable: true,
                defaultValue: 10);

            migrationBuilder.AddColumn<string>(
                name: "PeriodEndDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeriodStartDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PeriodEndDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropColumn(
                name: "PeriodStartDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.AddColumn<string>(
                name: "PeriodEndDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeriodStartDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
