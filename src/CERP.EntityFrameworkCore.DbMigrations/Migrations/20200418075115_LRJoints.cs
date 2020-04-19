using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LRJoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovalRouteTemplates",
                schema: "OxygenERP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    ApprovalRouteModule = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRouteTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalRouteTemplateItems",
                schema: "OxygenERP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    ApprovalRouteTemplateId = table.Column<int>(nullable: false),
                    RouteIndex = table.Column<int>(nullable: false),
                    IsDepartmentHead = table.Column<bool>(nullable: false),
                    IsReportingTo = table.Column<bool>(nullable: false),
                    DepartmentId = table.Column<Guid>(nullable: true),
                    PositionId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRouteTemplateItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalRouteTemplateItems_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                        column: x => x.ApprovalRouteTemplateId,
                        principalSchema: "OxygenERP",
                        principalTable: "ApprovalRouteTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRouteTemplateItems_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "SETUP",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRouteTemplateItems_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRouteTemplateItems_Positions_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "SETUP",
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequestTemplates",
                schema: "OxygenERP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    TitleLocalized = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    StartingNo = table.Column<int>(nullable: false),
                    EntitlementDays = table.Column<int>(nullable: false),
                    ApprovalRouteTemplateId = table.Column<int>(nullable: true),
                    HasAdvanceSalaryRequest = table.Column<bool>(nullable: false),
                    HasExitReentryRequest = table.Column<bool>(nullable: false),
                    HasAirTicketRequest = table.Column<bool>(nullable: false),
                    HasNotesRequirement = table.Column<bool>(nullable: false),
                    HaAttachmentRequirement = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequestTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequestTemplates_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                        column: x => x.ApprovalRouteTemplateId,
                        principalSchema: "OxygenERP",
                        principalTable: "ApprovalRouteTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequestTemplateDepartments",
                schema: "OxygenERP",
                columns: table => new
                {
                    LeaveRequestTemplateId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_LeaveRequestTemplateDepartments", x => new { x.LeaveRequestTemplateId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_LeaveRequestTemplateDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "SETUP",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveRequestTemplateDepartments_LeaveRequestTemplates_LeaveRequestTemplateId",
                        column: x => x.LeaveRequestTemplateId,
                        principalSchema: "OxygenERP",
                        principalTable: "LeaveRequestTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequestTemplateEmployeeStatuses",
                schema: "OxygenERP",
                columns: table => new
                {
                    LeaveRequestTemplateId = table.Column<int>(nullable: false),
                    EmployeeStatusId = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_LeaveRequestTemplateEmployeeStatuses", x => new { x.LeaveRequestTemplateId, x.EmployeeStatusId });
                    table.ForeignKey(
                        name: "FK_LeaveRequestTemplateEmployeeStatuses_DictionaryValues_EmployeeStatusId",
                        column: x => x.EmployeeStatusId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveRequestTemplateEmployeeStatuses_LeaveRequestTemplates_LeaveRequestTemplateId",
                        column: x => x.LeaveRequestTemplateId,
                        principalSchema: "OxygenERP",
                        principalTable: "LeaveRequestTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequestTemplateEmploymentTypes",
                schema: "OxygenERP",
                columns: table => new
                {
                    LeaveRequestTemplateId = table.Column<int>(nullable: false),
                    EmploymentTypeId = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_LeaveRequestTemplateEmploymentTypes", x => new { x.LeaveRequestTemplateId, x.EmploymentTypeId });
                    table.ForeignKey(
                        name: "FK_LeaveRequestTemplateEmploymentTypes_DictionaryValues_EmploymentTypeId",
                        column: x => x.EmploymentTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveRequestTemplateEmploymentTypes_LeaveRequestTemplates_LeaveRequestTemplateId",
                        column: x => x.LeaveRequestTemplateId,
                        principalSchema: "OxygenERP",
                        principalTable: "LeaveRequestTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequestTemplatePositions",
                schema: "OxygenERP",
                columns: table => new
                {
                    LeaveRequestTemplateId = table.Column<int>(nullable: false),
                    PositionId = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_LeaveRequestTemplatePositions", x => new { x.LeaveRequestTemplateId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_LeaveRequestTemplatePositions_LeaveRequestTemplates_LeaveRequestTemplateId",
                        column: x => x.LeaveRequestTemplateId,
                        principalSchema: "OxygenERP",
                        principalTable: "LeaveRequestTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveRequestTemplatePositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "SETUP",
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRouteTemplateItems_ApprovalRouteTemplateId",
                schema: "OxygenERP",
                table: "ApprovalRouteTemplateItems",
                column: "ApprovalRouteTemplateId");

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
                name: "IX_LeaveRequestTemplateDepartments_DepartmentId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplateDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestTemplateEmployeeStatuses_EmployeeStatusId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplateEmployeeStatuses",
                column: "EmployeeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestTemplateEmploymentTypes_EmploymentTypeId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplateEmploymentTypes",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestTemplatePositions_PositionId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplatePositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestTemplates_ApprovalRouteTemplateId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates",
                column: "ApprovalRouteTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalRouteTemplateItems",
                schema: "OxygenERP");

            migrationBuilder.DropTable(
                name: "LeaveRequestTemplateDepartments",
                schema: "OxygenERP");

            migrationBuilder.DropTable(
                name: "LeaveRequestTemplateEmployeeStatuses",
                schema: "OxygenERP");

            migrationBuilder.DropTable(
                name: "LeaveRequestTemplateEmploymentTypes",
                schema: "OxygenERP");

            migrationBuilder.DropTable(
                name: "LeaveRequestTemplatePositions",
                schema: "OxygenERP");

            migrationBuilder.DropTable(
                name: "LeaveRequestTemplates",
                schema: "OxygenERP");

            migrationBuilder.DropTable(
                name: "ApprovalRouteTemplates",
                schema: "OxygenERP");
        }
    }
}
