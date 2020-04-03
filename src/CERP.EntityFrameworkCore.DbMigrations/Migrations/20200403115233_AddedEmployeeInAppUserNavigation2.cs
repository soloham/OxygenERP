using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class AddedEmployeeInAppUserNavigation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AbpUsers_Employees_EmployeeId2",
            //    table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_EmployeeId",
                table: "AbpUsers");

            //migrationBuilder.DropIndex(
            //    name: "IX_AbpUsers_EmployeeId2",
            //    table: "AbpUsers");

            //migrationBuilder.DropColumn(
            //    name: "EmployeeId2",
            //    table: "AbpUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_EmployeeId",
                table: "AbpUsers",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_EmployeeId",
                table: "AbpUsers");

            //migrationBuilder.AddColumn<Guid>(
            //    name: "EmployeeId2",
            //    table: "AbpUsers",
            //    type: "uniqueidentifier",
            //    nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_EmployeeId",
                table: "AbpUsers",
                column: "EmployeeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AbpUsers_EmployeeId2",
            //    table: "AbpUsers",
            //    column: "EmployeeId2",
            //    unique: true,
            //    filter: "[EmployeeId2] IS NOT NULL");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AbpUsers_Employees_EmployeeId2",
            //    table: "AbpUsers",
            //    column: "EmployeeId2",
            //    principalSchema: "HR",
            //    principalTable: "Employees",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
