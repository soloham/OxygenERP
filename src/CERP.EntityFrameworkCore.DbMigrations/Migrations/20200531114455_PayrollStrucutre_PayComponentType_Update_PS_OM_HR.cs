using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class PayrollStrucutre_PayComponentType_Update_PS_OM_HR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayComponentTypes_PayComponentTypes_PercentagePayComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes");

            migrationBuilder.DropIndex(
                name: "IX_PayComponentTypes_PercentagePayComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes");

            migrationBuilder.DropColumn(
                name: "PercentagePayComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes");

            migrationBuilder.DropColumn(
                name: "PercentageValue",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameLocalized",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Percentage",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ValueComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValueType",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PayComponentTypes_ValueComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                column: "ValueComponentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayComponentTypes_PayComponentTypes_ValueComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                column: "ValueComponentTypeId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayComponentTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayComponentTypes_PayComponentTypes_ValueComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes");

            migrationBuilder.DropIndex(
                name: "IX_PayComponentTypes_ValueComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes");

            migrationBuilder.DropColumn(
                name: "NameLocalized",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes");

            migrationBuilder.DropColumn(
                name: "Percentage",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes");

            migrationBuilder.DropColumn(
                name: "ValueComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes");

            migrationBuilder.DropColumn(
                name: "ValueType",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes");

            migrationBuilder.AddColumn<int>(
                name: "PercentagePayComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PercentageValue",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_PayComponentTypes_PercentagePayComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                column: "PercentagePayComponentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayComponentTypes_PayComponentTypes_PercentagePayComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                column: "PercentagePayComponentTypeId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayComponentTypes",
                principalColumn: "Id");
        }
    }
}
