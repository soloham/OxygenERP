using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_JobsTasksFunctionsSkillsAcademiaCompensationMatrix_AndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobQualificationTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "TaskQualificationTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropColumn(
                name: "ActivationDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates");

            migrationBuilder.DropColumn(
                name: "ActivationDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates");

            migrationBuilder.DropColumn(
                name: "ActivationDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.AddColumn<int>(
                name: "CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "WorkflowLinkability",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxPositionsPerDepartment",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxJobPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CompensationMatrixTemplates",
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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameLocalized = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DoesKPI = table.Column<bool>(nullable: false),
                    ActivationDate = table.Column<DateTime>(nullable: false),
                    ValidityFromDate = table.Column<DateTime>(nullable: false),
                    ValidityToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompensationMatrixTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTaskTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    JobTemplateId = table.Column<int>(nullable: false),
                    TaskTemplateId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_JobTaskTemplates", x => new { x.JobTemplateId, x.TaskTemplateId });
                    table.ForeignKey(
                        name: "FK_JobTaskTemplates_JobTemplates_JobTemplateId",
                        column: x => x.JobTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "JobTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobTaskTemplates_TaskTemplates_TaskTemplateId",
                        column: x => x.TaskTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "TaskTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AcademiaTemplates",
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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameLocalized = table.Column<string>(nullable: true),
                    InstituteId = table.Column<Guid>(nullable: false),
                    AcademicType = table.Column<int>(nullable: false),
                    AcademiaCertificateType = table.Column<int>(nullable: false),
                    AcademiaCertificateSubTypeId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DoesKPI = table.Column<bool>(nullable: false),
                    CompensationMatrixId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademiaTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademiaTemplates_DictionaryValues_AcademiaCertificateSubTypeId",
                        column: x => x.AcademiaCertificateSubTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AcademiaTemplates_CompensationMatrixTemplates_CompensationMatrixId",
                        column: x => x.CompensationMatrixId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "CompensationMatrixTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademiaTemplates_DictionaryValues_InstituteId",
                        column: x => x.InstituteId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FunctionTemplates",
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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameLocalized = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DoesKPI = table.Column<bool>(nullable: false),
                    ValidityFromDate = table.Column<DateTime>(nullable: false),
                    ValidityToDate = table.Column<DateTime>(nullable: false),
                    CompensationMatrixId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FunctionTemplates_CompensationMatrixTemplates_CompensationMatrixId",
                        column: x => x.CompensationMatrixId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "CompensationMatrixTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillTemplates",
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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameLocalized = table.Column<string>(nullable: true),
                    SkillAquisitionType = table.Column<int>(nullable: false),
                    SkillType = table.Column<int>(nullable: false),
                    SkillSubTypeId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DoesKPI = table.Column<bool>(nullable: false),
                    SkillUpdatePeriod = table.Column<int>(nullable: false),
                    CompensationMatrixId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillTemplates_CompensationMatrixTemplates_CompensationMatrixId",
                        column: x => x.CompensationMatrixId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "CompensationMatrixTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillTemplates_DictionaryValues_SkillSubTypeId",
                        column: x => x.SkillSubTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobAcademiaTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    JobTemplateId = table.Column<int>(nullable: false),
                    AcademiaTemplateId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_JobAcademiaTemplates", x => new { x.JobTemplateId, x.AcademiaTemplateId });
                    table.ForeignKey(
                        name: "FK_JobAcademiaTemplates_AcademiaTemplates_AcademiaTemplateId",
                        column: x => x.AcademiaTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "AcademiaTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobAcademiaTemplates_JobTemplates_JobTemplateId",
                        column: x => x.JobTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "JobTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskAcademiaTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    TaskTemplateId = table.Column<int>(nullable: false),
                    AcademiaTemplateId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_TaskAcademiaTemplates", x => new { x.TaskTemplateId, x.AcademiaTemplateId });
                    table.ForeignKey(
                        name: "FK_TaskAcademiaTemplates_AcademiaTemplates_AcademiaTemplateId",
                        column: x => x.AcademiaTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "AcademiaTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskAcademiaTemplates_TaskTemplates_TaskTemplateId",
                        column: x => x.TaskTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "TaskTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FunctionAcademiaTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    FunctionTemplateId = table.Column<int>(nullable: false),
                    AcademiaTemplateId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_FunctionAcademiaTemplates", x => new { x.FunctionTemplateId, x.AcademiaTemplateId });
                    table.ForeignKey(
                        name: "FK_FunctionAcademiaTemplates_AcademiaTemplates_AcademiaTemplateId",
                        column: x => x.AcademiaTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "AcademiaTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FunctionAcademiaTemplates_FunctionTemplates_FunctionTemplateId",
                        column: x => x.FunctionTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "FunctionTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobFunctionTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    JobTemplateId = table.Column<int>(nullable: false),
                    FunctionTemplateId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_JobFunctionTemplates", x => new { x.JobTemplateId, x.FunctionTemplateId });
                    table.ForeignKey(
                        name: "FK_JobFunctionTemplates_FunctionTemplates_FunctionTemplateId",
                        column: x => x.FunctionTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "FunctionTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobFunctionTemplates_JobTemplates_JobTemplateId",
                        column: x => x.JobTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "JobTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FunctionSkillTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    FunctionTemplateId = table.Column<int>(nullable: false),
                    SkillTemplateId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_FunctionSkillTemplates", x => new { x.FunctionTemplateId, x.SkillTemplateId });
                    table.ForeignKey(
                        name: "FK_FunctionSkillTemplates_FunctionTemplates_FunctionTemplateId",
                        column: x => x.FunctionTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "FunctionTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FunctionSkillTemplates_SkillTemplates_SkillTemplateId",
                        column: x => x.SkillTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "SkillTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobSkillTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    JobTemplateId = table.Column<int>(nullable: false),
                    SkillTemplateId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_JobSkillTemplates", x => new { x.JobTemplateId, x.SkillTemplateId });
                    table.ForeignKey(
                        name: "FK_JobSkillTemplates_JobTemplates_JobTemplateId",
                        column: x => x.JobTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "JobTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobSkillTemplates_SkillTemplates_SkillTemplateId",
                        column: x => x.SkillTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "SkillTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskSkillTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    TaskTemplateId = table.Column<int>(nullable: false),
                    SkillTemplateId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_TaskSkillTemplates", x => new { x.TaskTemplateId, x.SkillTemplateId });
                    table.ForeignKey(
                        name: "FK_TaskSkillTemplates_SkillTemplates_SkillTemplateId",
                        column: x => x.SkillTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "SkillTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskSkillTemplates_TaskTemplates_TaskTemplateId",
                        column: x => x.TaskTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "TaskTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskTemplates_CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates",
                column: "CompensationMatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTemplates_CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates",
                column: "CompensationMatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademiaTemplates_AcademiaCertificateSubTypeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates",
                column: "AcademiaCertificateSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademiaTemplates_CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates",
                column: "CompensationMatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademiaTemplates_InstituteId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionAcademiaTemplates_AcademiaTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "FunctionAcademiaTemplates",
                column: "AcademiaTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionSkillTemplates_SkillTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "FunctionSkillTemplates",
                column: "SkillTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionTemplates_CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "FunctionTemplates",
                column: "CompensationMatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAcademiaTemplates_AcademiaTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobAcademiaTemplates",
                column: "AcademiaTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobFunctionTemplates_FunctionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobFunctionTemplates",
                column: "FunctionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkillTemplates_SkillTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobSkillTemplates",
                column: "SkillTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTaskTemplates_TaskTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTaskTemplates",
                column: "TaskTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTemplates_CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates",
                column: "CompensationMatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTemplates_SkillSubTypeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates",
                column: "SkillSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAcademiaTemplates_AcademiaTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskAcademiaTemplates",
                column: "AcademiaTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSkillTemplates_SkillTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskSkillTemplates",
                column: "SkillTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTemplates_CompensationMatrixTemplates_CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates",
                column: "CompensationMatrixId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "CompensationMatrixTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTemplates_CompensationMatrixTemplates_CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates",
                column: "CompensationMatrixId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "CompensationMatrixTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTemplates_CompensationMatrixTemplates_CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTemplates_CompensationMatrixTemplates_CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates");

            migrationBuilder.DropTable(
                name: "FunctionAcademiaTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "FunctionSkillTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "JobAcademiaTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "JobFunctionTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "JobSkillTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "JobTaskTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "TaskAcademiaTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "TaskSkillTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "FunctionTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "AcademiaTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "SkillTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "CompensationMatrixTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropIndex(
                name: "IX_TaskTemplates_CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates");

            migrationBuilder.DropIndex(
                name: "IX_JobTemplates_CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates");

            migrationBuilder.DropColumn(
                name: "CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates");

            migrationBuilder.DropColumn(
                name: "WorkflowLinkability",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates");

            migrationBuilder.DropColumn(
                name: "MaxPositionsPerDepartment",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropColumn(
                name: "CompensationMatrixId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates");

            migrationBuilder.DropColumn(
                name: "MaxJobPositions",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivationDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivationDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivationDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "JobQualificationTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DegreeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstituteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTemplateId = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PeriodEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DegreeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstituteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PeriodEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskTemplateId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
    }
}
