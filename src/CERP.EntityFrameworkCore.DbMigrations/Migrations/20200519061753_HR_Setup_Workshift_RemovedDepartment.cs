using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_Setup_Workshift_RemovedDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkShifts_Departments_DepartmentId",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.DropIndex(
                name: "IX_WorkShifts_DepartmentId",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId",
                schema: "HR",
                table: "Employees",
                column: "WorkShiftId",
                principalSchema: "HR",
                principalTable: "WorkShifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                schema: "HR",
                table: "WorkShifts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_DepartmentId",
                schema: "HR",
                table: "WorkShifts",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId",
                schema: "HR",
                table: "Employees",
                column: "WorkShiftId",
                principalSchema: "HR",
                principalTable: "WorkShifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShifts_Departments_DepartmentId",
                schema: "HR",
                table: "WorkShifts",
                column: "DepartmentId",
                principalSchema: "SETUP",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
