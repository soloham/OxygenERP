using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class PayComponentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayGradeStatus",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponents");

            migrationBuilder.AddColumn<int>(
                name: "PayComponentStatus",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponents",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayComponentStatus",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponents");

            migrationBuilder.AddColumn<int>(
                name: "PayGradeStatus",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
