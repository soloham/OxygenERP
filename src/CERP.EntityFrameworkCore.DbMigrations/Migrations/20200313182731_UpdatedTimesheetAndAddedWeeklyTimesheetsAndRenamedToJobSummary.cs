using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedTimesheetAndAddedWeeklyTimesheetsAndRenamedToJobSummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeeklyTimesheets_EmployeeId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropIndex(
                name: "IX_Timesheets_EmployeeId",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Day1",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "Day2",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "Day3",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "Day4",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "Day5",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "Day6",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "Day7",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "IsChargeable",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "Week",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Week1",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Week2",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Week3",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Week4",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Week5",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.AddColumn<DateTime>(
                name: "Dated",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmitted",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SumFri",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SumMon",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SumSat",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SumSun",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SumThu",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SumTue",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SumWed",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week1Hours",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week2Hours",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week3Hours",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week4Hours",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week5Hours",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WeeklyTimesheetsJobs",
                schema: "HR",
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
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    WeekSheetId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Week = table.Column<int>(nullable: false),
                    IsChargeable = table.Column<bool>(nullable: false),
                    Sun = table.Column<int>(nullable: false),
                    Mon = table.Column<int>(nullable: false),
                    Tue = table.Column<int>(nullable: false),
                    Wed = table.Column<int>(nullable: false),
                    Thu = table.Column<int>(nullable: false),
                    Fri = table.Column<int>(nullable: false),
                    Sat = table.Column<int>(nullable: false),
                    TotalJobWeekHours = table.Column<int>(nullable: false),
                    IsSubmitted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyTimesheetsJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyTimesheetsJobs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyTimesheetsJobs_WeeklyTimesheets_WeekSheetId",
                        column: x => x.WeekSheetId,
                        principalSchema: "HR",
                        principalTable: "WeeklyTimesheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimesheets_EmployeeId",
                schema: "HR",
                table: "WeeklyTimesheets",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_EmployeeId",
                schema: "HR",
                table: "Timesheets",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimesheetsJobs_EmployeeId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimesheetsJobs_WeekSheetId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs",
                column: "WeekSheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklyTimesheetsJobs",
                schema: "HR");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyTimesheets_EmployeeId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropIndex(
                name: "IX_Timesheets_EmployeeId",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Dated",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "IsSubmitted",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "SumFri",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "SumMon",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "SumSat",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "SumSun",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "SumThu",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "SumTue",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "SumWed",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "Week1Hours",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Week2Hours",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Week3Hours",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Week4Hours",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Week5Hours",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.AddColumn<int>(
                name: "Day1",
                schema: "HR",
                table: "WeeklyTimesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Day2",
                schema: "HR",
                table: "WeeklyTimesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Day3",
                schema: "HR",
                table: "WeeklyTimesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Day4",
                schema: "HR",
                table: "WeeklyTimesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Day5",
                schema: "HR",
                table: "WeeklyTimesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Day6",
                schema: "HR",
                table: "WeeklyTimesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Day7",
                schema: "HR",
                table: "WeeklyTimesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsChargeable",
                schema: "HR",
                table: "WeeklyTimesheets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                schema: "HR",
                table: "WeeklyTimesheets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Week",
                schema: "HR",
                table: "Timesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week1",
                schema: "HR",
                table: "Timesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week2",
                schema: "HR",
                table: "Timesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week3",
                schema: "HR",
                table: "Timesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week4",
                schema: "HR",
                table: "Timesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week5",
                schema: "HR",
                table: "Timesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimesheets_EmployeeId",
                schema: "HR",
                table: "WeeklyTimesheets",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_EmployeeId",
                schema: "HR",
                table: "Timesheets",
                column: "EmployeeId",
                unique: true);
        }
    }
}
