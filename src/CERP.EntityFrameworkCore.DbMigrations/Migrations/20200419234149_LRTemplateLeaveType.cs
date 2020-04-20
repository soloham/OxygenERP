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
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
