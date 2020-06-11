using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_IqamaSponosorType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_IqamaSponsorTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IqamaSponsorTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaSponsorTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "IqamaSponsorType",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IqamaSponsorType",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "IqamaSponsorTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IqamaSponsorTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "IqamaSponsorTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_IqamaSponsorTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "IqamaSponsorTypeId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");
        }
    }
}
