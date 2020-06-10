using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_AcademiaSkills : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_SkillTemplates_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates");

            migrationBuilder.DropIndex(
                name: "IX_AcademiaTemplates_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "HR.Objects.Profiles",
                table: "SkillProfiles",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "HR.Objects.Profiles",
                table: "AcademiaProfiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillProfiles_EmployeeId",
                schema: "HR.Objects.Profiles",
                table: "SkillProfiles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademiaProfiles_EmployeeId",
                schema: "HR.Objects.Profiles",
                table: "AcademiaProfiles",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademiaProfiles_Employees_EmployeeId",
                schema: "HR.Objects.Profiles",
                table: "AcademiaProfiles",
                column: "EmployeeId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillProfiles_Employees_EmployeeId",
                schema: "HR.Objects.Profiles",
                table: "SkillProfiles",
                column: "EmployeeId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademiaProfiles_Employees_EmployeeId",
                schema: "HR.Objects.Profiles",
                table: "AcademiaProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillProfiles_Employees_EmployeeId",
                schema: "HR.Objects.Profiles",
                table: "SkillProfiles");

            migrationBuilder.DropIndex(
                name: "IX_SkillProfiles_EmployeeId",
                schema: "HR.Objects.Profiles",
                table: "SkillProfiles");

            migrationBuilder.DropIndex(
                name: "IX_AcademiaProfiles_EmployeeId",
                schema: "HR.Objects.Profiles",
                table: "AcademiaProfiles");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "HR.Objects.Profiles",
                table: "SkillProfiles");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "HR.Objects.Profiles",
                table: "AcademiaProfiles");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillTemplates_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademiaTemplates_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates",
                column: "EmployeeId");

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
    }
}
