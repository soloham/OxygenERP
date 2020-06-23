using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PayGroup_Period_OffCycle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OffCyclePayroll",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OffCyclePayroll",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
