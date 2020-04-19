using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplates_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplates_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates",
                column: "ApprovalRouteTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "ApprovalRouteTemplates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplates_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplates_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates",
                column: "ApprovalRouteTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "ApprovalRouteTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
