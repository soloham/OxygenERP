using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_Objects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Benefits_PayFrequencies_PayFrequencyId",
                schema: "HR.EmployeeCentral",
                table: "Benefits");

            migrationBuilder.DropIndex(
                name: "IX_Benefits_PayFrequencyId",
                schema: "HR.EmployeeCentral",
                table: "Benefits");

            migrationBuilder.DropColumn(
                name: "PayFrequencyId",
                schema: "HR.EmployeeCentral",
                table: "Benefits");

            migrationBuilder.AddColumn<string>(
                name: "DateOfBirth",
                schema: "HR.EmployeeCentral",
                table: "Dependants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "HR.EmployeeCentral",
                table: "Dependants");

            migrationBuilder.AddColumn<int>(
                name: "PayFrequencyId",
                schema: "HR.EmployeeCentral",
                table: "Benefits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_PayFrequencyId",
                schema: "HR.EmployeeCentral",
                table: "Benefits",
                column: "PayFrequencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Benefits_PayFrequencies_PayFrequencyId",
                schema: "HR.EmployeeCentral",
                table: "Benefits",
                column: "PayFrequencyId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayFrequencies",
                principalColumn: "Id");
        }
    }
}
