using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LoanRequestTemplateUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxBasicSalryInstallmentPercentageAmountLimit",
                schema: "HR",
                table: "LoanRequestTemplates");

            migrationBuilder.AddColumn<double>(
                name: "MaxInstallmentAmount",
                schema: "HR",
                table: "LoanRequestTemplates",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "HasReplacementOption",
                schema: "HR",
                table: "LeaveRequestTemplates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasReplacementRequirement",
                schema: "HR",
                table: "LeaveRequestTemplates",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxInstallmentAmount",
                schema: "HR",
                table: "LoanRequestTemplates");

            migrationBuilder.DropColumn(
                name: "HasReplacementOption",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropColumn(
                name: "HasReplacementRequirement",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.AddColumn<int>(
                name: "MaxBasicSalryInstallmentPercentageAmountLimit",
                schema: "HR",
                table: "LoanRequestTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
