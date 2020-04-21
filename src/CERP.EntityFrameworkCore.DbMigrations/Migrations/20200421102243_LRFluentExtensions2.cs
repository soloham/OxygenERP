using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LRFluentExtensions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplates_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplates_TaskTemplates_TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplates_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates",
                column: "ApprovalRouteTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "ApprovalRouteTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplates_TaskTemplates_TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates",
                column: "TaskTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "TaskTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplates_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplates_TaskTemplates_TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplates_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates",
                column: "ApprovalRouteTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "ApprovalRouteTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplates_TaskTemplates_TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates",
                column: "TaskTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "TaskTemplates",
                principalColumn: "Id");
        }
    }
}
