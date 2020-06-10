using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademiaTemplates_Employees_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillTemplates_Employees_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates");

            migrationBuilder.EnsureSchema(
                name: "HR.Objects.Profiles");

            migrationBuilder.CreateTable(
                name: "AcademiaProfiles",
                schema: "HR.Objects.Profiles",
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
                    InstituteId = table.Column<Guid>(nullable: false),
                    AcademicType = table.Column<int>(nullable: false),
                    AcademiaCertificateType = table.Column<int>(nullable: false),
                    AcademiaCertificateSubTypeId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PassoutYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademiaProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademiaProfiles_DictionaryValues_AcademiaCertificateSubTypeId",
                        column: x => x.AcademiaCertificateSubTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AcademiaProfiles_DictionaryValues_InstituteId",
                        column: x => x.InstituteId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkillProfiles",
                schema: "HR.Objects.Profiles",
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
                    SkillAquisitionType = table.Column<int>(nullable: false),
                    SkillType = table.Column<int>(nullable: false),
                    SkillSubTypeId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DoesKPI = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillProfiles_DictionaryValues_SkillSubTypeId",
                        column: x => x.SkillSubTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademiaProfiles_AcademiaCertificateSubTypeId",
                schema: "HR.Objects.Profiles",
                table: "AcademiaProfiles",
                column: "AcademiaCertificateSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademiaProfiles_InstituteId",
                schema: "HR.Objects.Profiles",
                table: "AcademiaProfiles",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillProfiles_SkillSubTypeId",
                schema: "HR.Objects.Profiles",
                table: "SkillProfiles",
                column: "SkillSubTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademiaTemplates_Employees_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates",
                column: "EmployeeId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillTemplates_Employees_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates",
                column: "EmployeeId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademiaTemplates_Employees_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillTemplates_Employees_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates");

            migrationBuilder.DropTable(
                name: "AcademiaProfiles",
                schema: "HR.Objects.Profiles");

            migrationBuilder.DropTable(
                name: "SkillProfiles",
                schema: "HR.Objects.Profiles");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademiaTemplates_Employees_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates",
                column: "EmployeeId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillTemplates_Employees_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates",
                column: "EmployeeId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
