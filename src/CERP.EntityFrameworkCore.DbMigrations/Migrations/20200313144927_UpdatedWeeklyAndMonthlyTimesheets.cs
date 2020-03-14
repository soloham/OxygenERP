using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedWeeklyAndMonthlyTimesheets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyTimesheets_MonthlyTimesheets_MonthTimesheetId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyTimesheets_MonthTimesheetId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "MonthTimesheetId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.AddColumn<bool>(
                name: "IsChargeable",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "HR",
                table: "MonthlyTimesheets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimesheets_MonthSheetId",
                schema: "HR",
                table: "WeeklyTimesheets",
                column: "MonthSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyTimesheets_MonthlyTimesheets_MonthSheetId",
                schema: "HR",
                table: "WeeklyTimesheets",
                column: "MonthSheetId",
                principalSchema: "HR",
                principalTable: "MonthlyTimesheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyTimesheets_MonthlyTimesheets_MonthSheetId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyTimesheets_MonthSheetId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "IsChargeable",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "HR",
                table: "MonthlyTimesheets");

            migrationBuilder.AddColumn<int>(
                name: "MonthTimesheetId",
                schema: "HR",
                table: "WeeklyTimesheets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimesheets_MonthTimesheetId",
                schema: "HR",
                table: "WeeklyTimesheets",
                column: "MonthTimesheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyTimesheets_MonthlyTimesheets_MonthTimesheetId",
                schema: "HR",
                table: "WeeklyTimesheets",
                column: "MonthTimesheetId",
                principalSchema: "HR",
                principalTable: "MonthlyTimesheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
