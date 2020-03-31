using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeSI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SetupId",
                schema: "PR",
                table: "SICategories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IndemnityTypeId",
                schema: "HR",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SITypeId",
                schema: "HR",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IndemnityTypeId",
                schema: "HR",
                table: "Employees",
                column: "IndemnityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SITypeId",
                schema: "HR",
                table: "Employees",
                column: "SITypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_IndemnityTypeId",
                schema: "HR",
                table: "Employees",
                column: "IndemnityTypeId",
                principalSchema: "AvalonERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_SITypeId",
                schema: "HR",
                table: "Employees",
                column: "SITypeId",
                principalSchema: "AvalonERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_IndemnityTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_SITypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IndemnityTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SITypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IndemnityTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SITypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "SetupId",
                schema: "PR",
                table: "SICategories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
