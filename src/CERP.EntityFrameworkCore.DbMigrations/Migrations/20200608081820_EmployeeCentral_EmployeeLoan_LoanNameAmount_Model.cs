using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_EmployeeLoan_LoanNameAmount_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanAmount",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans");

            migrationBuilder.DropColumn(
                name: "LoanName",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans");

            migrationBuilder.AddColumn<double>(
                name: "LoanAmount",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "LoanName",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
