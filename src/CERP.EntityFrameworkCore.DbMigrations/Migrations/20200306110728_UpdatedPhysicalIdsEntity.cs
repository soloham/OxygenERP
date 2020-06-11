using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedPhysicalIdsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<bool>(
                name: "IsPassport",
                schema: "HR",
                table: "EmpPhysicalIDs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmpPhysicalIDs_EmployeeId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpPhysicalIDs_Employees_EmployeeId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                column: "EmployeeId",
                principalSchema: "HR",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpPhysicalIDs_Employees_EmployeeId",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.DropIndex(
                name: "IX_EmpPhysicalIDs_EmployeeId",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.DropColumn(
                name: "IsPassport",
                schema: "HR",
                table: "EmpPhysicalIDs");
        }
    }
}
