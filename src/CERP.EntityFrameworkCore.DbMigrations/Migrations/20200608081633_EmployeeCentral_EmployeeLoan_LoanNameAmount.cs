using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_EmployeeLoan_LoanNameAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoanName",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanName",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans");
        }
    }
}
