using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedPayrunAllowancesSummaryAddedEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.CreateIndex(
                name: "IX_PayrunsAllowancesSummaries_EmployeeId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrunsAllowancesSummaries_Employees_EmployeeId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries",
                column: "EmployeeId",
                principalSchema: "HR",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrunsAllowancesSummaries_Employees_EmployeeId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries");

            migrationBuilder.DropIndex(
                name: "IX_PayrunsAllowancesSummaries_EmployeeId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries");
        }
    }
}
