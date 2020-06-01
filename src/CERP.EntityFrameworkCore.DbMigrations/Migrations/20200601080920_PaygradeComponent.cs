using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class PaygradeComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PayGradeComponents");

            migrationBuilder.DropColumn(
                name: "AmountValueType",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PayGradeComponents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PayGradeComponents",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "AmountValueType",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PayGradeComponents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
