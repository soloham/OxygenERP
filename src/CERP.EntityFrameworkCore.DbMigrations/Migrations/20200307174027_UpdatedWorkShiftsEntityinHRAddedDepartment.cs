using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedWorkShiftsEntityinHRAddedDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                schema: "HR",
                table: "WorkShifts",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_DepartmentId",
                schema: "HR",
                table: "WorkShifts",
                column: "DepartmentId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
