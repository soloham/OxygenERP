using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_TaskJob_Qualification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobQualificationTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
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
                    JobTemplateId = table.Column<int>(nullable: false),
                    DegreeId = table.Column<Guid>(nullable: false),
                    InstituteId = table.Column<Guid>(nullable: false),
                    PeriodStartDate = table.Column<DateTime>(nullable: false),
                    PeriodEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobQualificationTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobQualificationTemplates_DictionaryValues_DegreeId",
                        column: x => x.DegreeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobQualificationTemplates_DictionaryValues_InstituteId",
                        column: x => x.InstituteId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobQualificationTemplates_JobTemplates_JobTemplateId",
                        column: x => x.JobTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "JobTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskQualificationTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
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
                    TaskTemplateId = table.Column<int>(nullable: false),
                    DegreeId = table.Column<Guid>(nullable: false),
                    InstituteId = table.Column<Guid>(nullable: false),
                    PeriodStartDate = table.Column<DateTime>(nullable: false),
                    PeriodEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskQualificationTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskQualificationTemplates_DictionaryValues_DegreeId",
                        column: x => x.DegreeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskQualificationTemplates_DictionaryValues_InstituteId",
                        column: x => x.InstituteId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskQualificationTemplates_TaskTemplates_TaskTemplateId",
                        column: x => x.TaskTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "TaskTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobQualificationTemplates_DegreeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobQualificationTemplates",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobQualificationTemplates_InstituteId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobQualificationTemplates",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_JobQualificationTemplates_JobTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobQualificationTemplates",
                column: "JobTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskQualificationTemplates_DegreeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskQualificationTemplates",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskQualificationTemplates_InstituteId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskQualificationTemplates",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskQualificationTemplates_TaskTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskQualificationTemplates",
                column: "TaskTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobQualificationTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "TaskQualificationTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");
        }
    }
}
