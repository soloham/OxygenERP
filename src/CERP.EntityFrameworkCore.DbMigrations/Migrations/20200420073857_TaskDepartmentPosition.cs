using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class TaskDepartmentPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskTemplateItems_DepartmentId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTemplateItems_PositionId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTemplateItems_Departments_DepartmentId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                column: "DepartmentId",
                principalSchema: "SETUP",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTemplateItems_Positions_PositionId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                column: "PositionId",
                principalSchema: "SETUP",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskTemplateItems_Departments_DepartmentId",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTemplateItems_Positions_PositionId",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskTemplateItems_DepartmentId",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskTemplateItems_PositionId",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropColumn(
                name: "PositionId",
                schema: "OxygenERP",
                table: "TaskTemplateItems");
        }
    }
}
