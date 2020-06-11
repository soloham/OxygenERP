using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_Identity_Contract_Optioanl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_IqamaLabourOfficeValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IqamaNumberValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_NationalIdentitiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "NationalIdentitiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "IqamaSponsorTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "IqamaNumberValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IqamaLabourOfficeValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IqamaLabourOfficeValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "IqamaLabourOfficeValiditiesId",
                unique: true,
                filter: "[IqamaLabourOfficeValiditiesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IqamaNumberValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "IqamaNumberValiditiesId",
                unique: true,
                filter: "[IqamaNumberValiditiesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalIdentitiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "NationalIdentitiesId",
                unique: true,
                filter: "[NationalIdentitiesId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_IqamaLabourOfficeValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IqamaNumberValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_NationalIdentitiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "NationalIdentitiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IqamaSponsorTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IqamaNumberValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IqamaLabourOfficeValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IqamaLabourOfficeValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "IqamaLabourOfficeValiditiesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IqamaNumberValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "IqamaNumberValiditiesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalIdentitiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "NationalIdentitiesId",
                unique: true);
        }
    }
}
