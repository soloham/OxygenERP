using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedEmployeeAddedContractDetailsDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContractEndDate",
                schema: "HR",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractEndHDate",
                schema: "HR",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractStartDate",
                schema: "HR",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractStartHDate",
                schema: "HR",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContractStatusId",
                schema: "HR",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<Guid>(
                name: "ContractTypeId",
                schema: "HR",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                schema: "HR",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<string>(
                name: "JoiningDate",
                schema: "HR",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JoiningHDate",
                schema: "HR",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacationDays",
                schema: "HR",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContractStatusId",
                schema: "HR",
                table: "Employees",
                column: "ContractStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContractTypeId",
                schema: "HR",
                table: "Employees",
                column: "ContractTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_ContractStatusId",
                schema: "HR",
                table: "Employees",
                column: "ContractStatusId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_ContractTypeId",
                schema: "HR",
                table: "Employees",
                column: "ContractTypeId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_ContractStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_ContractTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ContractStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ContractTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContractEndDate",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContractEndHDate",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContractStartDate",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContractStartHDate",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContractStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContractTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "JoiningDate",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "JoiningHDate",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "VacationDays",
                schema: "HR",
                table: "Employees");
        }
    }
}
