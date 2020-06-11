using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_ContractValidity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidityFromDate",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ValidityToDate",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "ContractValidityFromDate",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractValidityToDate",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractValidityFromDate",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContractValidityToDate",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "ValidityFromDate",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValidityToDate",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
