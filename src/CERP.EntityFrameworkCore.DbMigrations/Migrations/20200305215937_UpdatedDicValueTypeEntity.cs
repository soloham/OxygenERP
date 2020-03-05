using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedDicValueTypeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COAs_DictionaryValues_CashFlowStatementTypeId",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_GenderId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_MaritalStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_NationalityId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_POB_ID",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_ReligionId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpPhysicalIDs_DictionaryValues_IDTypeId",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpPhysicalIDs_DictionaryValues_IssuedFromId",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.AddColumn<int>(
                name: "ValueTypeFor",
                schema: "CERP",
                table: "DictionaryValueTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_DictionaryValues_CashFlowStatementTypeId",
                schema: "FM",
                table: "COAs",
                column: "CashFlowStatementTypeId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_GenderId",
                schema: "HR",
                table: "Employees",
                column: "GenderId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_MaritalStatusId",
                schema: "HR",
                table: "Employees",
                column: "MaritalStatusId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_NationalityId",
                schema: "HR",
                table: "Employees",
                column: "NationalityId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_POB_ID",
                schema: "HR",
                table: "Employees",
                column: "POB_ID",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_ReligionId",
                schema: "HR",
                table: "Employees",
                column: "ReligionId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpPhysicalIDs_DictionaryValues_IDTypeId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                column: "IDTypeId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpPhysicalIDs_DictionaryValues_IssuedFromId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                column: "IssuedFromId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COAs_DictionaryValues_CashFlowStatementTypeId",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_GenderId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_MaritalStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_NationalityId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_POB_ID",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_ReligionId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpPhysicalIDs_DictionaryValues_IDTypeId",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpPhysicalIDs_DictionaryValues_IssuedFromId",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.DropColumn(
                name: "ValueTypeFor",
                schema: "CERP",
                table: "DictionaryValueTypes");

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_DictionaryValues_CashFlowStatementTypeId",
                schema: "FM",
                table: "COAs",
                column: "CashFlowStatementTypeId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_GenderId",
                schema: "HR",
                table: "Employees",
                column: "GenderId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_MaritalStatusId",
                schema: "HR",
                table: "Employees",
                column: "MaritalStatusId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_NationalityId",
                schema: "HR",
                table: "Employees",
                column: "NationalityId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_POB_ID",
                schema: "HR",
                table: "Employees",
                column: "POB_ID",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_ReligionId",
                schema: "HR",
                table: "Employees",
                column: "ReligionId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpPhysicalIDs_DictionaryValues_IDTypeId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                column: "IDTypeId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpPhysicalIDs_DictionaryValues_IssuedFromId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                column: "IssuedFromId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
