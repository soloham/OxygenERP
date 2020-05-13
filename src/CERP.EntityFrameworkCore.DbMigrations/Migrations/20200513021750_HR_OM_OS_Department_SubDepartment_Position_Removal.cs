using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_Department_SubDepartment_Position_Removal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameLocalized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameLocalized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartmentTemplateId = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubDepartmentRelationshipType = table.Column<int>(type: "int", nullable: false),
                    SubDepartmentTemplateId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentSubDepartmentTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentSubDepartmentTemplates_DepartmentTemplates_DepartmentTemplateId",
                        column: x => x.DepartmentTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "DepartmentTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartmentTemplateId = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PositionTemplateId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentPositionTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentPositionTemplates_DepartmentTemplates_DepartmentTemplateId",
                        column: x => x.DepartmentTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "DepartmentTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTemplateId = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PositionTemplateId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionJobTemplates", x => x.Id);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PositionTaskTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PositionTemplateId = table.Column<int>(type: "int", nullable: false),
                    TaskTemplateId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionTaskTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionTaskTemplates_PositionTemplates_PositionTemplateId",
                        column: x => x.PositionTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "PositionTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionTaskTemplates_TaskTemplates_TaskTemplateId",
                        column: x => x.TaskTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "TaskTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentPositionTemplates_DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentPositionTemplates",
                column: "DepartmentTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentPositionTemplates_PositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentPositionTemplates",
                column: "PositionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSubDepartmentTemplates_DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentSubDepartmentTemplates",
                column: "DepartmentTemplateId");

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
                name: "IX_PositionJobTemplates_PositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionJobTemplates",
                column: "PositionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionTaskTemplates_PositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTaskTemplates",
                column: "PositionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionTaskTemplates_TaskTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTaskTemplates",
                column: "TaskTemplateId");
        }
    }
}
