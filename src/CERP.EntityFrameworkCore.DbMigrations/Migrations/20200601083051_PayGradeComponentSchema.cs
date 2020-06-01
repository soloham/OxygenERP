using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class PayGradeComponentSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PayGradeComponents",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                newName: "PayGradeComponents",
                newSchema: "HR.OrganizationalManagement.PayrollStructure");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PayGradeComponents",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                newName: "PayGradeComponents",
                newSchema: "HR.OrganizationalManagement.OrganizationStructure");
        }
    }
}
