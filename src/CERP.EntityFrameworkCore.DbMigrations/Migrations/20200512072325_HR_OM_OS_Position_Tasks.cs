using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_Position_Tasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskTemplates",
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
                    table.PrimaryKey("PK_TaskTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionTaskTemplates",
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
                    TaskTemplateId = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionTaskTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropTable(
                name: "TaskTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");
        }
    }
}
