using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_Position_Job : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTemplates",
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
                    table.PrimaryKey("PK_JobTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionJobTemplates",
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
                    PositionTemplateId = table.Column<int>(nullable: false),
                    JobTemplateId = table.Column<int>(nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionJobTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "JobTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");
        }
    }
}
