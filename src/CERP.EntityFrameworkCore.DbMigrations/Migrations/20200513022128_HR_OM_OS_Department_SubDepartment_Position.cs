using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_Department_SubDepartment_Position : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentTemplates",
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
                    Name = table.Column<string>(nullable: true),
                    NameLocalized = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionTemplates",
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
                    NameLocalized = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentSubDepartmentTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    DepartmentTemplateId = table.Column<int>(nullable: false),
                    SubDepartmentTemplateId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    SubDepartmentRelationshipType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentSubDepartmentTemplates", x => new { x.DepartmentTemplateId, x.SubDepartmentTemplateId });
                    table.ForeignKey(
                        name: "FK_DepartmentSubDepartmentTemplates_DepartmentTemplates_DepartmentTemplateId",
                        column: x => x.DepartmentTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "DepartmentTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartmentSubDepartmentTemplates_DepartmentTemplates_SubDepartmentTemplateId",
                        column: x => x.SubDepartmentTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "DepartmentTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentPositionTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    DepartmentTemplateId = table.Column<int>(nullable: false),
                    PositionTemplateId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_DepartmentPositionTemplates", x => new { x.DepartmentTemplateId, x.PositionTemplateId });
                    table.ForeignKey(
                        name: "FK_DepartmentPositionTemplates_DepartmentTemplates_DepartmentTemplateId",
                        column: x => x.DepartmentTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "DepartmentTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartmentPositionTemplates_PositionTemplates_PositionTemplateId",
                        column: x => x.PositionTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "PositionTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PositionJobTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    PositionTemplateId = table.Column<int>(nullable: false),
                    JobTemplateId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_PositionJobTemplates", x => new { x.PositionTemplateId, x.JobTemplateId });
                    table.ForeignKey(
                        name: "FK_PositionJobTemplates_JobTemplates_JobTemplateId",
                        column: x => x.JobTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "JobTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionJobTemplates_PositionTemplates_PositionTemplateId",
                        column: x => x.PositionTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "PositionTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PositionTaskTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    PositionTemplateId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_PositionTaskTemplates", x => new { x.PositionTemplateId, x.TaskTemplateId });
                    table.ForeignKey(
                        name: "FK_PositionTaskTemplates_PositionTemplates_PositionTemplateId",
                        column: x => x.PositionTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "PositionTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositionTaskTemplates_TaskTemplates_TaskTemplateId",
                        column: x => x.TaskTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "TaskTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentPositionTemplates_PositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentPositionTemplates",
                column: "PositionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSubDepartmentTemplates_SubDepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentSubDepartmentTemplates",
                column: "SubDepartmentTemplateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PositionJobTemplates_JobTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionJobTemplates",
                column: "JobTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionTaskTemplates_TaskTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTaskTemplates",
                column: "TaskTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentPositionTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "DepartmentSubDepartmentTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "PositionJobTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "PositionTaskTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "DepartmentTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "PositionTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");
        }
    }
}
