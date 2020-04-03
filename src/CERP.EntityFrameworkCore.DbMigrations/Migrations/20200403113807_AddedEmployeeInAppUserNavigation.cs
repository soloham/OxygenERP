using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class AddedEmployeeInAppUserNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<Guid>(
            //    name: "EmployeeId2",
            //    table: "AbpUsers",
            //    nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_EmployeeId",
                table: "AbpUsers",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Employees_EmployeeId",
                table: "AbpUsers",
                column: "EmployeeId",
                principalSchema: "HR",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Employees_EmployeeId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_EmployeeId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeId2",
                table: "AbpUsers");
        }
    }
}
