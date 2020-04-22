using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LeaveRequestRedesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplates_TaskTemplates_TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRouteTemplateItems_Departments_DepartmentId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRouteTemplateItems_Employees_EmployeeId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRouteTemplateItems_Positions_PositionId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTemplateItems_Departments_DepartmentId",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTemplateItems_Employees_EmployeeId",
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
                name: "IX_TaskTemplateItems_EmployeeId",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskTemplateItems_PositionId",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalRouteTemplateItems_DepartmentId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalRouteTemplateItems_EmployeeId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalRouteTemplateItems_PositionId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequestTemplates_TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropColumn(
                name: "PositionId",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropColumn(
                name: "PositionId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropColumn(
                name: "TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalRouteTemplateItemId",
                schema: "OxygenERP",
                table: "TaskTemplates",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAny",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NotifyEmployee",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAny",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPoster",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NotifyEmployee",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TaskTemplateId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskTemplateItemEmployees",
                schema: "HR",
                columns: table => new
                {
                    TaskTemplateItemId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTemplateItemEmployees", x => new { x.TaskTemplateItemId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_TaskTemplateItemEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskTemplateItemEmployees_TaskTemplateItems_TaskTemplateItemId",
                        column: x => x.TaskTemplateItemId,
                        principalSchema: "OxygenERP",
                        principalTable: "TaskTemplateItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalRouteTemplateItemEmployees",
                schema: "OxygenERP",
                columns: table => new
                {
                    ApprovalRouteTemplateItemId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRouteTemplateItemEmployees", x => new { x.ApprovalRouteTemplateItemId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_ApprovalRouteTemplateItemEmployees_ApprovalRouteTemplateItems_ApprovalRouteTemplateItemId",
                        column: x => x.ApprovalRouteTemplateItemId,
                        principalSchema: "OxygenERP",
                        principalTable: "ApprovalRouteTemplateItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRouteTemplateItemEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRouteTemplateItems_TaskTemplateId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                column: "TaskTemplateId",
                unique: true,
                filter: "[TaskTemplateId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTemplateItemEmployees_EmployeeId",
                schema: "HR",
                table: "TaskTemplateItemEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRouteTemplateItemEmployees_EmployeeId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItemEmployees",
                column: "EmployeeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRouteTemplateItems_TaskTemplates_TaskTemplateId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropTable(
                name: "TaskTemplateItemEmployees",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "ApprovalRouteTemplateItemEmployees",
                schema: "OxygenERP");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalRouteTemplateItems_TaskTemplateId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropColumn(
                name: "ApprovalRouteTemplateItemId",
                schema: "OxygenERP",
                table: "TaskTemplates");

            migrationBuilder.DropColumn(
                name: "IsAny",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropColumn(
                name: "NotifyEmployee",
                schema: "OxygenERP",
                table: "TaskTemplateItems");

            migrationBuilder.DropColumn(
                name: "IsAny",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropColumn(
                name: "IsPoster",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropColumn(
                name: "NotifyEmployee",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.DropColumn(
                name: "TaskTemplateId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TaskTemplateItems_DepartmentId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTemplateItems_EmployeeId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTemplateItems_PositionId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRouteTemplateItems_DepartmentId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRouteTemplateItems_EmployeeId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRouteTemplateItems_PositionId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestTemplates_TaskTemplateId",
                schema: "HR",
                table: "LeaveRequestTemplates",
                column: "TaskTemplateId",
                unique: true);

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
                name: "FK_ApprovalRouteTemplateItems_Departments_DepartmentId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                column: "DepartmentId",
                principalSchema: "SETUP",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRouteTemplateItems_Employees_EmployeeId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                column: "EmployeeId",
                principalSchema: "HR",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRouteTemplateItems_Positions_PositionId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                column: "PositionId",
                principalSchema: "SETUP",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_TaskTemplateItems_Employees_EmployeeId",
                schema: "OxygenERP",
                table: "TaskTemplateItems",
                column: "EmployeeId",
                principalSchema: "HR",
                principalTable: "Employees",
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
    }
}
