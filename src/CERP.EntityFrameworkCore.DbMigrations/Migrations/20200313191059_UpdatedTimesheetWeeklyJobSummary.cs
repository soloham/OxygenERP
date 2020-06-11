using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedTimesheetWeeklyJobSummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChargeabilityId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<int>(
                name: "JobInWeekId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceLineId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimesheetsJobs_ChargeabilityId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs",
                column: "ChargeabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimesheetsJobs_ClientId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTimesheetsJobs_ServiceLineId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs",
                column: "ServiceLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyTimesheetsJobs_DictionaryValues_ChargeabilityId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs",
                column: "ChargeabilityId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyTimesheetsJobs_DictionaryValues_ClientId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs",
                column: "ClientId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyTimesheetsJobs_DictionaryValues_ServiceLineId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs",
                column: "ServiceLineId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyTimesheetsJobs_DictionaryValues_ChargeabilityId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyTimesheetsJobs_DictionaryValues_ClientId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyTimesheetsJobs_DictionaryValues_ServiceLineId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyTimesheetsJobs_ChargeabilityId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyTimesheetsJobs_ClientId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyTimesheetsJobs_ServiceLineId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs");

            migrationBuilder.DropColumn(
                name: "ChargeabilityId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs");

            migrationBuilder.DropColumn(
                name: "ClientId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs");

            migrationBuilder.DropColumn(
                name: "JobInWeekId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs");

            migrationBuilder.DropColumn(
                name: "ServiceLineId",
                schema: "HR",
                table: "WeeklyTimesheetsJobs");
        }
    }
}
