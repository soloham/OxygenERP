using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedEmployeeAddedEmployeeTypeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeTypeId",
                schema: "HR",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                schema: "HR",
                table: "Employees",
                column: "EmployeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeTypeId",
                schema: "HR",
                table: "Employees",
                column: "EmployeeTypeId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeTypeId",
                schema: "HR",
                table: "Employees");
        }
    }
}
