using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class Setup_LegalEntity_OrgStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PayGroupes_PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentTemplates_PayGroupes_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_PayGroupes_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_PayGroupes_PayFrequencies_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroupes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayGroupes",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroupes");

            migrationBuilder.RenameTable(
                name: "PayGroupes",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                newName: "PayGroups",
                newSchema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.RenameIndex(
                name: "IX_PayGroupes_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                newName: "IX_PayGroups_FrequencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayGroups",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PayGroups_PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "PayGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentTemplates_PayGroups_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                column: "PayGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_PayGroups_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                column: "PayGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayGroups_PayFrequencies_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                column: "FrequencyId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayFrequencies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PayGroups_PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentTemplates_PayGroups_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_PayGroups_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_PayGroups_PayFrequencies_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayGroups",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.RenameTable(
                name: "PayGroups",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                newName: "PayGroupes",
                newSchema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.RenameIndex(
                name: "IX_PayGroups_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroupes",
                newName: "IX_PayGroupes_FrequencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayGroupes",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroupes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PayGroupes_PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "PayGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayGroupes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentTemplates_PayGroupes_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                column: "PayGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayGroupes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_PayGroupes_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                column: "PayGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayGroupes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayGroupes_PayFrequencies_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroupes",
                column: "FrequencyId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayFrequencies",
                principalColumn: "Id");
        }
    }
}
