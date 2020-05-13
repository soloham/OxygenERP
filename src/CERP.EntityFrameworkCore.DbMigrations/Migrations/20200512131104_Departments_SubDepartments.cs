using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class Departments_SubDepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentSubDepartmentTemplates",
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
                    SubDepartmentRelationshipType = table.Column<int>(nullable: false),
                    SubDepartmentTemplateId = table.Column<int>(nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentSubDepartmentTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");
        }
    }
}
