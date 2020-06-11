using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedTimesheetAndRemovedMonthlyTimesheets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyTimesheets_MonthlyTimesheets_MonthSheetId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropTable(
                name: "MonthlyTimesheets",
                schema: "HR");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyTimesheets_MonthSheetId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "MonthSheetId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<int>(
                name: "Month",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimesheetId",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                schema: "HR",
                table: "WeeklyTimesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dated",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "HR",
                table: "Timesheets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalMonthHours",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week1",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week2",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week3",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week4",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Week5",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                schema: "HR",
                table: "Timesheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimesheets_EmployeeId",
                schema: "HR",
                table: "WeeklyTimesheets",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimesheets_TimesheetId",
                schema: "HR",
                table: "WeeklyTimesheets",
                column: "TimesheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyTimesheets_Employees_EmployeeId",
                schema: "HR",
                table: "WeeklyTimesheets",
                column: "EmployeeId",
                principalSchema: "HR",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyTimesheets_Timesheets_TimesheetId",
                schema: "HR",
                table: "WeeklyTimesheets",
                column: "TimesheetId",
                principalSchema: "HR",
                principalTable: "Timesheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyTimesheets_Employees_EmployeeId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyTimesheets_Timesheets_TimesheetId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyTimesheets_EmployeeId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyTimesheets_TimesheetId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "Month",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "TimesheetId",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "Year",
                schema: "HR",
                table: "WeeklyTimesheets");

            migrationBuilder.DropColumn(
                name: "Dated",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Month",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "TotalMonthHours",
                schema: "HR",
                table: "Timesheets");

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

            migrationBuilder.DropColumn(
                name: "Year",
                schema: "HR",
                table: "Timesheets");

            migrationBuilder.AddColumn<int>(
                name: "MonthSheetId",
                schema: "HR",
                table: "WeeklyTimesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MonthlyTimesheets",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPosted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: false),
                    TimesheetId = table.Column<int>(type: "int", nullable: false),
                    TotalMonthHours = table.Column<int>(type: "int", nullable: false),
                    Week1 = table.Column<int>(type: "int", nullable: false),
                    Week2 = table.Column<int>(type: "int", nullable: false),
                    Week3 = table.Column<int>(type: "int", nullable: false),
                    Week4 = table.Column<int>(type: "int", nullable: false),
                    Week5 = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyTimesheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyTimesheets_Timesheets_TimesheetId",
                        column: x => x.TimesheetId,
                        principalSchema: "HR",
                        principalTable: "Timesheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimesheets_MonthSheetId",
                schema: "HR",
                table: "WeeklyTimesheets",
                column: "MonthSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyTimesheets_TimesheetId",
                schema: "HR",
                table: "MonthlyTimesheets",
                column: "TimesheetId");

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
    }
}
