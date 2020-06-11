using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_EmployeeLoan_LoanStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLoans_DictionaryValues_LoanStatusId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeLoans_LoanStatusId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans");

            migrationBuilder.DropColumn(
                name: "LoanStatusId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans");

            migrationBuilder.AddColumn<int>(
                name: "LoanStatus",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanStatus",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans");

            migrationBuilder.AddColumn<Guid>(
                name: "LoanStatusId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLoans_LoanStatusId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans",
                column: "LoanStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLoans_DictionaryValues_LoanStatusId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans",
                column: "LoanStatusId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");
        }
    }
}
