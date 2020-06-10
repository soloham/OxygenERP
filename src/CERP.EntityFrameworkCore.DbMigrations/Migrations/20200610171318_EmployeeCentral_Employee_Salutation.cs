using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_Salutation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TitleId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TitleId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_TitleId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "TitleId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_TitleId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TitleId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TitleId",
                schema: "HR.EmployeeCentral",
                table: "Employees");
        }
    }
}
