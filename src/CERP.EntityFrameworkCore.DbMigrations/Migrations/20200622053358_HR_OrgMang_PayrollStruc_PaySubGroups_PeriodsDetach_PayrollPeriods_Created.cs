using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayrollStruc_PaySubGroups_PeriodsDetach_PayrollPeriods_Created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayPeriods_PaySubGroups_PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayPeriods",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "ExtraPeriods",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups");

            migrationBuilder.DropColumn(
                name: "PeriodEndDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups");

            migrationBuilder.DropColumn(
                name: "PeriodFrequency",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups");

            migrationBuilder.DropColumn(
                name: "PeriodName",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups");

            migrationBuilder.DropColumn(
                name: "PeriodStartDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups");

            migrationBuilder.DropColumn(
                name: "PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.AddColumn<int>(
                name: "PayrollPeriodId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PayrollPeriodId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayPeriods",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                columns: new[] { "PayrollPeriodId", "Id" });

            migrationBuilder.CreateTable(
                name: "PayrollPeriods",
                schema: "HR.OrganizationalManagement.PayrollStructure",
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
                    Name = table.Column<string>(nullable: true),
                    PeriodFrequency = table.Column<int>(nullable: false),
                    PeriodStartDate = table.Column<string>(nullable: true),
                    PeriodEndDate = table.Column<string>(nullable: true),
                    ExtraPeriods = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollPeriods", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaySubGroups_PayrollPeriodId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                column: "PayrollPeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayPeriods_PayrollPeriods_PayrollPeriodId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                column: "PayrollPeriodId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayrollPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaySubGroups_PayrollPeriods_PayrollPeriodId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                column: "PayrollPeriodId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayrollPeriods",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayPeriods_PayrollPeriods_PayrollPeriodId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_PaySubGroups_PayrollPeriods_PayrollPeriodId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups");

            migrationBuilder.DropTable(
                name: "PayrollPeriods",
                schema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.DropIndex(
                name: "IX_PaySubGroups_PayrollPeriodId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayPeriods",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "PayrollPeriodId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups");

            migrationBuilder.DropColumn(
                name: "PayrollPeriodId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.AddColumn<int>(
                name: "ExtraPeriods",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PeriodEndDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeriodFrequency",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PeriodName",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeriodStartDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayPeriods",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                columns: new[] { "PaySubGroupId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_PayPeriods_PaySubGroups_PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                column: "PaySubGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PaySubGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
