using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class PayrollStructure_OM_HR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.CreateTable(
                name: "PayComponentTypes",
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
                    TenantId = table.Column<Guid>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    PercentageValue = table.Column<double>(nullable: false),
                    PercentagePayComponentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayComponentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayComponentTypes_PayComponentTypes_PercentagePayComponentTypeId",
                        column: x => x.PercentagePayComponentTypeId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayComponentTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PayFrequencies",
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
                    TenantId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameLocalized = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AnnualizationFactor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayFrequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayGroupes",
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
                    TenantId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameLocalized = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayGroupes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayRanges",
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
                    TenantId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameLocalized = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Min = table.Column<double>(nullable: false),
                    Mid = table.Column<double>(nullable: false),
                    Max = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayRanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayComponents",
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
                    TenantId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameLocalized = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PayGradeStatus = table.Column<int>(nullable: false),
                    PayComponentTypeId = table.Column<int>(nullable: false),
                    IsEarning = table.Column<bool>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    PayComponentValue = table.Column<double>(nullable: false),
                    PayFrequencyId = table.Column<int>(nullable: false),
                    IsRecurring = table.Column<bool>(nullable: false),
                    IsIncomeTaxTreatment = table.Column<bool>(nullable: false),
                    IsGOSITreatment = table.Column<bool>(nullable: false),
                    IsEOSBTreatment = table.Column<bool>(nullable: false),
                    CanOverride = table.Column<bool>(nullable: false),
                    SelfServiceVisibility = table.Column<bool>(nullable: false),
                    SelfServiceDescription = table.Column<string>(nullable: true),
                    IsUsedForCompPlanning = table.Column<bool>(nullable: false),
                    IsRecurringPaymentAndDeduction = table.Column<bool>(nullable: false),
                    MaxDecimalPlaces = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayComponents_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "SETUP",
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PayComponents_PayComponentTypes_PayComponentTypeId",
                        column: x => x.PayComponentTypeId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayComponentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PayComponents_PayFrequencies_PayFrequencyId",
                        column: x => x.PayFrequencyId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayFrequencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PayGrades",
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
                    TenantId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameLocalized = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PayGradeStatus = table.Column<int>(nullable: false),
                    PayGradeLevel = table.Column<int>(nullable: false),
                    PayRangeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayGrades_PayRanges_PayRangeId",
                        column: x => x.PayRangeId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayComponents_CurrencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponents",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PayComponents_PayComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponents",
                column: "PayComponentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayComponents_PayFrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponents",
                column: "PayFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PayComponentTypes_PercentagePayComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                column: "PercentagePayComponentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayGrades_PayRangeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGrades",
                column: "PayRangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayComponents",
                schema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.DropTable(
                name: "PayGrades",
                schema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.DropTable(
                name: "PayGroupes",
                schema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.DropTable(
                name: "PayComponentTypes",
                schema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.DropTable(
                name: "PayFrequencies",
                schema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.DropTable(
                name: "PayRanges",
                schema: "HR.OrganizationalManagement.PayrollStructure");
        }
    }
}
