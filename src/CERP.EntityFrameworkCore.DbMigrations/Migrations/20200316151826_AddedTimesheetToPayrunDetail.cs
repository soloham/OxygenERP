using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class AddedTimesheetToPayrunDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeTimesheetId",
                schema: "PR",
                table: "PayrunsDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PayrunsDetails_EmployeeTimesheetId",
                schema: "PR",
                table: "PayrunsDetails",
                column: "EmployeeTimesheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrunsDetails_Timesheets_EmployeeTimesheetId",
                schema: "PR",
                table: "PayrunsDetails",
                column: "EmployeeTimesheetId",
                principalSchema: "HR",
                principalTable: "Timesheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrunsDetails_Timesheets_EmployeeTimesheetId",
                schema: "PR",
                table: "PayrunsDetails");

            migrationBuilder.DropIndex(
                name: "IX_PayrunsDetails_EmployeeTimesheetId",
                schema: "PR",
                table: "PayrunsDetails");

            migrationBuilder.DropColumn(
                name: "EmployeeTimesheetId",
                schema: "PR",
                table: "PayrunsDetails");
        }
    }
}
