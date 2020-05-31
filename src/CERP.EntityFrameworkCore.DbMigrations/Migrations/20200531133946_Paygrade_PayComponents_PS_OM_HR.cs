using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class Paygrade_PayComponents_PS_OM_HR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroupes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PayGradeComponents",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                columns: table => new
                {
                    PayComponentId = table.Column<int>(nullable: false),
                    PayGradeId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    MaxAnnualLimit = table.Column<int>(nullable: false),
                    AmountValueType = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayGradeComponents", x => new { x.PayGradeId, x.PayComponentId });
                    table.ForeignKey(
                        name: "FK_PayGradeComponents_PayComponents_PayComponentId",
                        column: x => x.PayComponentId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayComponents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PayGradeComponents_PayGrades_PayGradeId",
                        column: x => x.PayGradeId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayGrades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayGroupes_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroupes",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PayGradeComponents_PayComponentId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PayGradeComponents",
                column: "PayComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayGroupes_PayFrequencies_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroupes",
                column: "FrequencyId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayFrequencies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayGroupes_PayFrequencies_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroupes");

            migrationBuilder.DropTable(
                name: "PayGradeComponents",
                schema: "HR.OrganizationalManagement.OrganizationStructure");

            migrationBuilder.DropIndex(
                name: "IX_PayGroupes_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroupes");

            migrationBuilder.DropColumn(
                name: "FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroupes");
        }
    }
}
