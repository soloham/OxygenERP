using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LRFluentExtensions3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateDepartments_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateEmployeeStatuses_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateEmployeeStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateEmploymentTypes_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateEmploymentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateHolidays_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateHolidays");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplatePositions_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplates_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplates_TaskTemplates_TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRouteTemplateItems_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTemplateItems_TaskTemplates_TaskTemplateId",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequestTemplates_ApprovalRouteTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequestTemplates_TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestTemplates_ApprovalRouteTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates",
                column: "ApprovalRouteTemplateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestTemplates_TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates",
                column: "TaskTemplateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateDepartments_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateDepartments",
                column: "LeaveRequestTemplateId",
                principalSchema: "HR",
                principalTable: "LeaveRequestTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateEmployeeStatuses_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateEmployeeStatuses",
                column: "LeaveRequestTemplateId",
                principalSchema: "HR",
                principalTable: "LeaveRequestTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateEmploymentTypes_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateEmploymentTypes",
                column: "LeaveRequestTemplateId",
                principalSchema: "HR",
                principalTable: "LeaveRequestTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateHolidays_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateHolidays",
                column: "LeaveRequestTemplateId",
                principalSchema: "HR",
                principalTable: "LeaveRequestTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplatePositions_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplatePositions",
                column: "LeaveRequestTemplateId",
                principalSchema: "HR",
                principalTable: "LeaveRequestTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplates_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates",
                column: "ApprovalRouteTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "ApprovalRouteTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplates_TaskTemplates_TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates",
                column: "TaskTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "TaskTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRouteTemplateItems_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                column: "ApprovalRouteTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "ApprovalRouteTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTemplateItems_TaskTemplates_TaskTemplateId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                column: "TaskTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "TaskTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateDepartments_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateEmployeeStatuses_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateEmployeeStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateEmploymentTypes_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateEmploymentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateHolidays_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateHolidays");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplatePositions_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplatePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplates_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplates_TaskTemplates_TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRouteTemplateItems_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTemplateItems_TaskTemplates_TaskTemplateId",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequestTemplates_ApprovalRouteTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequestTemplates_TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestTemplates_ApprovalRouteTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates",
                column: "ApprovalRouteTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestTemplates_TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates",
                column: "TaskTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateDepartments_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateDepartments",
                column: "LeaveRequestTemplateId",
                principalSchema: "HR",
                principalTable: "LeaveRequestTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateEmployeeStatuses_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateEmployeeStatuses",
                column: "LeaveRequestTemplateId",
                principalSchema: "HR",
                principalTable: "LeaveRequestTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateEmploymentTypes_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateEmploymentTypes",
                column: "LeaveRequestTemplateId",
                principalSchema: "HR",
                principalTable: "LeaveRequestTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateHolidays_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplateHolidays",
                column: "LeaveRequestTemplateId",
                principalSchema: "HR",
                principalTable: "LeaveRequestTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplatePositions_LeaveRequestTemplates_LeaveRequestTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplatePositions",
                column: "LeaveRequestTemplateId",
                principalSchema: "HR",
                principalTable: "LeaveRequestTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRouteTemplateItems_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                column: "ApprovalRouteTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "ApprovalRouteTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTemplateItems_TaskTemplates_TaskTemplateId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                column: "TaskTemplateId",
                principalSchema: "OxygenERP",
                principalTable: "TaskTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
