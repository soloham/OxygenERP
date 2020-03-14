using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class CreatedTimesheetsAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Timesheets",
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
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timesheets_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyTimesheets",
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
                    TimesheetId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Week1 = table.Column<int>(nullable: false),
                    Week2 = table.Column<int>(nullable: false),
                    Week3 = table.Column<int>(nullable: false),
                    Week4 = table.Column<int>(nullable: false),
                    Week5 = table.Column<int>(nullable: false),
                    TotalMonthHours = table.Column<int>(nullable: false),
                    IsPosted = table.Column<bool>(nullable: false),
                    Dated = table.Column<DateTime>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "WeeklyTimesheets",
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
                    MonthTimesheetId = table.Column<int>(nullable: true),
                    MonthSheetId = table.Column<int>(nullable: false),
                    Week = table.Column<int>(nullable: false),
                    Day1 = table.Column<int>(nullable: false),
                    Day2 = table.Column<int>(nullable: false),
                    Day3 = table.Column<int>(nullable: false),
                    Day4 = table.Column<int>(nullable: false),
                    Day5 = table.Column<int>(nullable: false),
                    Day6 = table.Column<int>(nullable: false),
                    Day7 = table.Column<int>(nullable: false),
                    TotalWeekHours = table.Column<int>(nullable: false),
                    IsPosted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyTimesheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyTimesheets_MonthlyTimesheets_MonthTimesheetId",
                        column: x => x.MonthTimesheetId,
                        principalSchema: "HR",
                        principalTable: "MonthlyTimesheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyTimesheets_TimesheetId",
                schema: "HR",
                table: "MonthlyTimesheets",
                column: "TimesheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_EmployeeId",
                schema: "HR",
                table: "Timesheets",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimesheets_MonthTimesheetId",
                schema: "HR",
                table: "WeeklyTimesheets",
                column: "MonthTimesheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklyTimesheets",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "MonthlyTimesheets",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Timesheets",
                schema: "HR");
        }
    }
}
