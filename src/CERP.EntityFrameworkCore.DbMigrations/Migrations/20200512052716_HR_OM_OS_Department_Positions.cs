using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_Department_Positions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HR.OrganizationalManagement.OrganizationStructure");

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
                    Title = table.Column<string>(nullable: true),
                    TitleLocalized = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentPositionTemplates",
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
                    DepartmentTemplateId = table.Column<int>(nullable: false),
                    PositionTemplateId = table.Column<int>(nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentPositionTemplates",
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
