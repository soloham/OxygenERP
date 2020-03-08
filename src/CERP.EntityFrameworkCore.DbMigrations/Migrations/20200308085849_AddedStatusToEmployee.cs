using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class AddedStatusToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeStatusId",
                schema: "HR",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeStatusId",
                schema: "HR",
                table: "Employees",
                column: "EmployeeStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeStatusId",
                schema: "HR",
                table: "Employees",
                column: "EmployeeStatusId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeStatusId",
                schema: "HR",
                table: "Employees");
        }
    }
}
