using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class PS_PayGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowThirdPartyPayments",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBankPaymentAllowed",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCashPaymentAllowed",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsChequePaymentAllowed",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "LegalEntityId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                nullable: false,
                defaultValue: new Guid("6775D796-49B4-D4CB-858A-39F50B4C5B88"));

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                nullable: false,
                defaultValue: 1044);

            migrationBuilder.CreateTable(
                name: "PS_PayGroupBank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    PayGroupId = table.Column<int>(nullable: false),
                    BankId = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    PS_PayGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_PayGroupBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PS_PayGroupBank_PayGroups_PS_PayGroupId",
                        column: x => x.PS_PayGroupId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PS_PayGroupBank_PayGroups_PayGroupId",
                        column: x => x.PayGroupId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayGroupBusinessUnits",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                columns: table => new
                {
                    PayGroupId = table.Column<int>(nullable: false),
                    OrganizationStructureTemplateId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    BusinessUnitId = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayGroupBusinessUnits", x => new { x.PayGroupId, x.OrganizationStructureTemplateId });
                    table.ForeignKey(
                        name: "FK_PayGroupBusinessUnits_PayGroups_PayGroupId",
                        column: x => x.PayGroupId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayPeriods",
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
                    PeriodStartDate = table.Column<string>(nullable: true),
                    PeriodEndDate = table.Column<string>(nullable: true),
                    PeriodCutOffStartDate = table.Column<string>(nullable: true),
                    PeriodCutOffEndDate = table.Column<string>(nullable: true),
                    PeriodProcessingDate = table.Column<string>(nullable: true),
                    ReminderIssuanceDays = table.Column<int>(nullable: false),
                    ApprovalDate = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<string>(nullable: true),
                    PostPaymentSelfServiceAvailabilityDays = table.Column<int>(nullable: false),
                    GLExpensePostingDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PS_PayGroupBusinessUnitDivision",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    PayGroupId = table.Column<int>(nullable: false),
                    BusinessUnitId = table.Column<int>(nullable: false),
                    BusinessUnitDivisionId = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    PS_PayGroupBusinessUnitOrganizationStructureTemplateId = table.Column<int>(nullable: true),
                    PS_PayGroupBusinessUnitPayGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_PayGroupBusinessUnitDivision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PS_PayGroupBusinessUnitDivision_PayGroupBusinessUnits_PS_PayGroupBusinessUnitPayGroupId_PS_PayGroupBusinessUnitOrganizationS~",
                        columns: x => new { x.PS_PayGroupBusinessUnitPayGroupId, x.PS_PayGroupBusinessUnitOrganizationStructureTemplateId },
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayGroupBusinessUnits",
                        principalColumns: new[] { "PayGroupId", "OrganizationStructureTemplateId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PS_PayGroupBusinessUnitDivisionDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    PayGroupId = table.Column<int>(nullable: false),
                    BusinessUnitId = table.Column<int>(nullable: false),
                    BusinessUnitDivisionId = table.Column<int>(nullable: false),
                    BusinessUnitDivisionHeadDepartmentId = table.Column<int>(nullable: false),
                    BusinessUnitDivisionDepartmentId = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    PS_PayGroupBusinessUnitDivisionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_PayGroupBusinessUnitDivisionDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PS_PayGroupBusinessUnitDivisionDepartment_PS_PayGroupBusinessUnitDivision_PS_PayGroupBusinessUnitDivisionId",
                        column: x => x.PS_PayGroupBusinessUnitDivisionId,
                        principalTable: "PS_PayGroupBusinessUnitDivision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayGroups_LegalEntityId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                column: "LegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PayGroups_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                column: "OrganizationStructureTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PS_PayGroupBank_PS_PayGroupId",
                table: "PS_PayGroupBank",
                column: "PS_PayGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PS_PayGroupBank_PayGroupId",
                table: "PS_PayGroupBank",
                column: "PayGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PS_PayGroupBusinessUnitDivision_PS_PayGroupBusinessUnitPayGroupId_PS_PayGroupBusinessUnitOrganizationStructureTemplateId",
                table: "PS_PayGroupBusinessUnitDivision",
                columns: new[] { "PS_PayGroupBusinessUnitPayGroupId", "PS_PayGroupBusinessUnitOrganizationStructureTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_PS_PayGroupBusinessUnitDivisionDepartment_PS_PayGroupBusinessUnitDivisionId",
                table: "PS_PayGroupBusinessUnitDivisionDepartment",
                column: "PS_PayGroupBusinessUnitDivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayGroups_Companies_LegalEntityId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                column: "LegalEntityId",
                principalSchema: "SETUP",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PayGroups_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                column: "OrganizationStructureTemplateId",
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayGroups_Companies_LegalEntityId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PayGroups_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropTable(
                name: "PS_PayGroupBank");

            migrationBuilder.DropTable(
                name: "PS_PayGroupBusinessUnitDivisionDepartment");

            migrationBuilder.DropTable(
                name: "PayPeriods",
                schema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.DropTable(
                name: "PS_PayGroupBusinessUnitDivision");

            migrationBuilder.DropTable(
                name: "PayGroupBusinessUnits",
                schema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.DropIndex(
                name: "IX_PayGroups_LegalEntityId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropIndex(
                name: "IX_PayGroups_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropColumn(
                name: "AllowThirdPartyPayments",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropColumn(
                name: "IsBankPaymentAllowed",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropColumn(
                name: "IsCashPaymentAllowed",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropColumn(
                name: "IsChequePaymentAllowed",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropColumn(
                name: "LegalEntityId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropColumn(
                name: "OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");
        }
    }
}
