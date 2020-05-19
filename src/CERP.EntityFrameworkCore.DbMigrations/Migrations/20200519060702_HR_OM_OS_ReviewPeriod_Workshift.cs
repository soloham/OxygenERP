using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_ReviewPeriod_Workshift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "FunctionTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "CompensationMatrixTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobWorkshiftTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    JobTemplateId = table.Column<int>(nullable: false),
                    WorkshiftId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_JobWorkshiftTemplates", x => new { x.JobTemplateId, x.WorkshiftId });
                    table.ForeignKey(
                        name: "FK_JobWorkshiftTemplates_JobTemplates_JobTemplateId",
                        column: x => x.JobTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "JobTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobWorkshiftTemplates_WorkShifts_WorkshiftId",
                        column: x => x.WorkshiftId,
                        principalSchema: "HR",
                        principalTable: "WorkShifts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobWorkshiftTemplates_WorkshiftId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobWorkshiftTemplates",
                column: "WorkshiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobWorkshiftTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropColumn(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates");

            migrationBuilder.DropColumn(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates");

            migrationBuilder.DropColumn(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropColumn(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates");

            migrationBuilder.DropColumn(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "FunctionTemplates");

            migrationBuilder.DropColumn(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropColumn(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "CompensationMatrixTemplates");

            migrationBuilder.DropColumn(
                name: "ReviewPeriod",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates");
        }
    }
}
