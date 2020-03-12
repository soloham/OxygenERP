using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_ContractStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_ContractTypeId",
                schema: "HR",
                table: "Employees");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_ContractStatusId",
                schema: "HR",
                table: "Employees",
                column: "ContractStatusId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_ContractTypeId",
                schema: "HR",
                table: "Employees",
                column: "ContractTypeId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
