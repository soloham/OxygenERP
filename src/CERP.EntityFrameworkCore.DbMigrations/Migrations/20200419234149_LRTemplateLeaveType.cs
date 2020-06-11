using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LRTemplateLeaveType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LeaveTypeId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestTemplates_LeaveTypeId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates",
                column: "LeaveTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplates_DictionaryValues_LeaveTypeId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates",
                column: "LeaveTypeId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplates_DictionaryValues_LeaveTypeId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequestTemplates_LeaveTypeId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropColumn(
                name: "LeaveTypeId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates");
        }
    }
}
