using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedEmployeeAddedReportingTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReportingToId",
                schema: "HR",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportingToId",
                schema: "HR",
                table: "Employees",
                column: "ReportingToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ReportingToId",
                schema: "HR",
                table: "Employees",
                column: "ReportingToId",
                principalSchema: "HR",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ReportingToId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ReportingToId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ReportingToId",
                schema: "HR",
                table: "Employees");
        }
    }
}
