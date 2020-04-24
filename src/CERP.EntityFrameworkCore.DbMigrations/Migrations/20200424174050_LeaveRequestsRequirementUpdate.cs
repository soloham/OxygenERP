using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LeaveRequestsRequirementUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasAdvanceSalaryRequirement",
                schema: "HR",
                table: "LeaveRequestTemplates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasAirTicketRequirement",
                schema: "HR",
                table: "LeaveRequestTemplates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasExitReentryRequirement",
                schema: "HR",
                table: "LeaveRequestTemplates",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAdvanceSalaryRequirement",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropColumn(
                name: "HasAirTicketRequirement",
                schema: "HR",
                table: "LeaveRequestTemplates");

            migrationBuilder.DropColumn(
                name: "HasExitReentryRequirement",
                schema: "HR",
                table: "LeaveRequestTemplates");
        }
    }
}
