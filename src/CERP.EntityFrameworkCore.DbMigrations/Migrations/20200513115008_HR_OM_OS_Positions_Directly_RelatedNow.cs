using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_Positions_Directly_RelatedNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentPositionTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PositionTemplates_DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                column: "DepartmentTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionTemplates_DepartmentTemplates_DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                column: "DepartmentTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "DepartmentTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionTemplates_DepartmentTemplates_DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropIndex(
                name: "IX_PositionTemplates_DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropColumn(
                name: "DepartmentTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropColumn(
                name: "Level",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.CreateTable(
                name: "DepartmentPositionTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    DepartmentTemplateId = table.Column<int>(type: "int", nullable: false),
                    PositionTemplateId = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentPositionTemplates_PositionTemplateId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentPositionTemplates",
                column: "PositionTemplateId");
        }
    }
}
