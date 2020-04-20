using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class TaskTemplateInLeaveRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskTemplateId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestTemplates_TaskTemplateId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates",
                column: "TaskTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplates_TaskTemplates_TaskTemplateId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates",
                column: "TaskTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "TaskTemplates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplates_TaskTemplates_TaskTemplateId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequestTemplates_TaskTemplateId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropColumn(
                name: "TaskTemplateId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates");
        }
    }
}
