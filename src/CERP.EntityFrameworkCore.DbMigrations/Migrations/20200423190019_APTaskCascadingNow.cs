using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class APTaskCascadingNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRouteTemplateItems_TaskTemplates_TaskTemplateId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRouteTemplateItems_TaskTemplates_TaskTemplateId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                column: "TaskTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "TaskTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRouteTemplateItems_TaskTemplates_TaskTemplateId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRouteTemplateItems_TaskTemplates_TaskTemplateId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                column: "TaskTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "TaskTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
