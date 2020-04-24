using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class AddedLoanRequestTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanRequestTemplates",
                schema: "HR",
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
                    LoanTypeId = table.Column<Guid>(nullable: false),
                    MinEmployeeDependants = table.Column<int>(nullable: false),
                    MaxIndemnityLimit = table.Column<int>(nullable: false),
                    MaxInstallmentsLimit = table.Column<int>(nullable: false),
                    MaxInstallmentAmount = table.Column<int>(nullable: false),
                    ApprovalRouteTemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequestTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanRequestTemplates_ApprovalRouteTemplates_ApprovalRouteTemplateId",
                        column: x => x.ApprovalRouteTemplateId,
                        principalSchema: "OxygenERP",
                        principalTable: "ApprovalRouteTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRequestTemplates_DictionaryValues_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoanRequestTemplateDepartments",
                schema: "HR",
                columns: table => new
                {
                    LoanRequestTemplateId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    LoanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequestTemplateDepartments", x => new { x.LoanRequestTemplateId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_LoanRequestTemplateDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "SETUP",
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanRequestTemplateDepartments_LoanRequestTemplates_LoanId",
                        column: x => x.LoanId,
                        principalSchema: "HR",
                        principalTable: "LoanRequestTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanRequestTemplateEmployeeStatuses",
                schema: "HR",
                columns: table => new
                {
                    LoanRequestTemplateId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_LoanRequestTemplateEmployeeStatuses", x => new { x.LoanRequestTemplateId, x.EmployeeStatusId });
                    table.ForeignKey(
                        name: "FK_LoanRequestTemplateEmployeeStatuses_DictionaryValues_EmployeeStatusId",
                        column: x => x.EmployeeStatusId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanRequestTemplateEmployeeStatuses_LoanRequestTemplates_LoanRequestTemplateId",
                        column: x => x.LoanRequestTemplateId,
                        principalSchema: "HR",
                        principalTable: "LoanRequestTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanRequestTemplateEmploymentTypes",
                schema: "HR",
                columns: table => new
                {
                    LoanRequestTemplateId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_LoanRequestTemplateEmploymentTypes", x => new { x.LoanRequestTemplateId, x.EmploymentTypeId });
                    table.ForeignKey(
                        name: "FK_LoanRequestTemplateEmploymentTypes_DictionaryValues_EmploymentTypeId",
                        column: x => x.EmploymentTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanRequestTemplateEmploymentTypes_LoanRequestTemplates_LoanRequestTemplateId",
                        column: x => x.LoanRequestTemplateId,
                        principalSchema: "HR",
                        principalTable: "LoanRequestTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanRequestTemplatePositions",
                schema: "HR",
                columns: table => new
                {
                    LoanRequestTemplateId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_LoanRequestTemplatePositions", x => new { x.LoanRequestTemplateId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_LoanRequestTemplatePositions_LoanRequestTemplates_LoanRequestTemplateId",
                        column: x => x.LoanRequestTemplateId,
                        principalSchema: "HR",
                        principalTable: "LoanRequestTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRequestTemplatePositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "SETUP",
                        principalTable: "Positions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestTemplateDepartments_DepartmentId",
                schema: "HR",
                table: "LoanRequestTemplateDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestTemplateDepartments_LoanId",
                schema: "HR",
                table: "LoanRequestTemplateDepartments",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestTemplateEmployeeStatuses_EmployeeStatusId",
                schema: "HR",
                table: "LoanRequestTemplateEmployeeStatuses",
                column: "EmployeeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestTemplateEmploymentTypes_EmploymentTypeId",
                schema: "HR",
                table: "LoanRequestTemplateEmploymentTypes",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestTemplatePositions_PositionId",
                schema: "HR",
                table: "LoanRequestTemplatePositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestTemplates_ApprovalRouteTemplateId",
                schema: "HR",
                table: "LoanRequestTemplates",
                column: "ApprovalRouteTemplateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestTemplates_LoanTypeId",
                schema: "HR",
                table: "LoanRequestTemplates",
                column: "LoanTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanRequestTemplateDepartments",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "LoanRequestTemplateEmployeeStatuses",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "LoanRequestTemplateEmploymentTypes",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "LoanRequestTemplatePositions",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "LoanRequestTemplates",
                schema: "HR");
        }
    }
}
