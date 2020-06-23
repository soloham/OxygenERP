using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PaySubGroup_PayGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PayGroups_PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentTemplates_PayGroups_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_PayGroups_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_PayGroups_PayFrequencies_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PayGroups_Companies_LegalEntityId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PayGroups_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PayPeriods_PayGroups_PayGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropTable(
                name: "PS_PayGroupBank");

            migrationBuilder.DropTable(
                name: "PS_PayGroupBusinessUnitDivisionDepartment");

            migrationBuilder.DropTable(
                name: "PS_PayGroupBusinessUnitDivision");

            migrationBuilder.DropTable(
                name: "PayGroupBusinessUnits",
                schema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.DropIndex(
                name: "IX_PayPeriods_PayGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropIndex(
                name: "IX_PayGroups_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropIndex(
                name: "IX_PayGroups_LegalEntityId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropIndex(
                name: "IX_PayGroups_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnits_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentTemplates_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PayGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "AllowThirdPartyPayments",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropColumn(
                name: "FrequencyId",
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

            migrationBuilder.DropColumn(
                name: "PeriodEndDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropColumn(
                name: "PeriodStartDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups");

            migrationBuilder.DropColumn(
                name: "PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropColumn(
                name: "PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropColumn(
                name: "PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaySubGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaySubGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaySubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaySubGroups",
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
                    PayGroupId = table.Column<int>(nullable: true),
                    FrequencyId = table.Column<int>(nullable: false),
                    LegalEntityId = table.Column<Guid>(nullable: false),
                    OrganizationStructureTemplateId = table.Column<int>(nullable: true),
                    IsCashPaymentAllowed = table.Column<bool>(nullable: false),
                    IsChequePaymentAllowed = table.Column<bool>(nullable: false),
                    IsBankPaymentAllowed = table.Column<bool>(nullable: false),
                    AllowThirdPartyPayments = table.Column<bool>(nullable: false),
                    PeriodStartDate = table.Column<string>(nullable: true),
                    PeriodEndDate = table.Column<string>(nullable: true),
                    PS_PayGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaySubGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaySubGroups_PayFrequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayFrequencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaySubGroups_Companies_LegalEntityId",
                        column: x => x.LegalEntityId,
                        principalSchema: "SETUP",
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaySubGroups_OrganizationStructureTemplates_OrganizationStructureTemplateId",
                        column: x => x.OrganizationStructureTemplateId,
                        principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                        principalTable: "OrganizationStructureTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaySubGroups_PayGroups_PS_PayGroupId",
                        column: x => x.PS_PayGroupId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaySubGroups_PayGroups_PayGroupId",
                        column: x => x.PayGroupId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PS_PaySubGroupBank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    PaySubGroupId = table.Column<int>(nullable: false),
                    BankId = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    PS_PaySubGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_PaySubGroupBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PS_PaySubGroupBank_PaySubGroups_PS_PaySubGroupId",
                        column: x => x.PS_PaySubGroupId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PaySubGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PS_PaySubGroupBank_PaySubGroups_PaySubGroupId",
                        column: x => x.PaySubGroupId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PaySubGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaySubGroupBusinessUnits",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                columns: table => new
                {
                    PaySubGroupId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_PaySubGroupBusinessUnits", x => new { x.PaySubGroupId, x.OrganizationStructureTemplateId });
                    table.ForeignKey(
                        name: "FK_PaySubGroupBusinessUnits_PaySubGroups_PaySubGroupId",
                        column: x => x.PaySubGroupId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PaySubGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PS_PaySubGroupBusinessUnitDivision",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    PaySubGroupId = table.Column<int>(nullable: false),
                    BusinessUnitId = table.Column<int>(nullable: false),
                    BusinessUnitDivisionId = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    PS_PaySubGroupBusinessUnitOrganizationStructureTemplateId = table.Column<int>(nullable: true),
                    PS_PaySubGroupBusinessUnitPaySubGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_PaySubGroupBusinessUnitDivision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PS_PaySubGroupBusinessUnitDivision_PaySubGroupBusinessUnits_PS_PaySubGroupBusinessUnitPaySubGroupId_PS_PaySubGroupBusinessUn~",
                        columns: x => new { x.PS_PaySubGroupBusinessUnitPaySubGroupId, x.PS_PaySubGroupBusinessUnitOrganizationStructureTemplateId },
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PaySubGroupBusinessUnits",
                        principalColumns: new[] { "PaySubGroupId", "OrganizationStructureTemplateId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PS_PaySubGroupBusinessUnitDivisionDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    PaySubGroupId = table.Column<int>(nullable: false),
                    BusinessUnitId = table.Column<int>(nullable: false),
                    BusinessUnitDivisionId = table.Column<int>(nullable: false),
                    BusinessUnitDivisionHeadDepartmentId = table.Column<int>(nullable: false),
                    BusinessUnitDivisionDepartmentId = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    PS_PaySubGroupBusinessUnitDivisionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_PaySubGroupBusinessUnitDivisionDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PS_PaySubGroupBusinessUnitDivisionDepartment_PS_PaySubGroupBusinessUnitDivision_PS_PaySubGroupBusinessUnitDivisionId",
                        column: x => x.PS_PaySubGroupBusinessUnitDivisionId,
                        principalTable: "PS_PaySubGroupBusinessUnitDivision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayPeriods_PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                column: "PaySubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnits_PaySubGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                column: "PaySubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentTemplates_PaySubGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                column: "PaySubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PaySubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "PaySubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PS_PaySubGroupBank_PS_PaySubGroupId",
                table: "PS_PaySubGroupBank",
                column: "PS_PaySubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PS_PaySubGroupBank_PaySubGroupId",
                table: "PS_PaySubGroupBank",
                column: "PaySubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PS_PaySubGroupBusinessUnitDivision_PS_PaySubGroupBusinessUnitPaySubGroupId_PS_PaySubGroupBusinessUnitOrganizationStructureTe~",
                table: "PS_PaySubGroupBusinessUnitDivision",
                columns: new[] { "PS_PaySubGroupBusinessUnitPaySubGroupId", "PS_PaySubGroupBusinessUnitOrganizationStructureTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_PS_PaySubGroupBusinessUnitDivisionDepartment_PS_PaySubGroupBusinessUnitDivisionId",
                table: "PS_PaySubGroupBusinessUnitDivisionDepartment",
                column: "PS_PaySubGroupBusinessUnitDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PaySubGroups_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PaySubGroups_LegalEntityId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                column: "LegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PaySubGroups_OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                column: "OrganizationStructureTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PaySubGroups_PS_PayGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                column: "PS_PayGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PaySubGroups_PayGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroups",
                column: "PayGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PaySubGroups_PaySubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "PaySubGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PaySubGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentTemplates_PaySubGroups_PaySubGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                column: "PaySubGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PaySubGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_PaySubGroups_PaySubGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                column: "PaySubGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PaySubGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PaySubGroups_PaySubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentTemplates_PaySubGroups_PaySubGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_PaySubGroups_PaySubGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_PayPeriods_PaySubGroups_PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropTable(
                name: "PS_PaySubGroupBank");

            migrationBuilder.DropTable(
                name: "PS_PaySubGroupBusinessUnitDivisionDepartment");

            migrationBuilder.DropTable(
                name: "PS_PaySubGroupBusinessUnitDivision");

            migrationBuilder.DropTable(
                name: "PaySubGroupBusinessUnits",
                schema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.DropTable(
                name: "PaySubGroups",
                schema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.DropIndex(
                name: "IX_PayPeriods_PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationStructureTemplateBusinessUnits_PaySubGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentTemplates_PaySubGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PaySubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "PaySubGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits");

            migrationBuilder.DropColumn(
                name: "PaySubGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates");

            migrationBuilder.DropColumn(
                name: "PaySubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "PayGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "AllowThirdPartyPayments",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBankPaymentAllowed",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCashPaymentAllowed",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsChequePaymentAllowed",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "LegalEntityId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "OrganizationStructureTemplateId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeriodEndDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeriodStartDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PS_PayGroupBank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PS_PayGroupId = table.Column<int>(type: "int", nullable: true),
                    PayGroupId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    PayGroupId = table.Column<int>(type: "int", nullable: false),
                    OrganizationStructureTemplateId = table.Column<int>(type: "int", nullable: false),
                    BusinessUnitId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "PS_PayGroupBusinessUnitDivision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessUnitDivisionId = table.Column<int>(type: "int", nullable: false),
                    BusinessUnitId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PS_PayGroupBusinessUnitOrganizationStructureTemplateId = table.Column<int>(type: "int", nullable: true),
                    PS_PayGroupBusinessUnitPayGroupId = table.Column<int>(type: "int", nullable: true),
                    PayGroupId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessUnitDivisionDepartmentId = table.Column<int>(type: "int", nullable: false),
                    BusinessUnitDivisionHeadDepartmentId = table.Column<int>(type: "int", nullable: false),
                    BusinessUnitDivisionId = table.Column<int>(type: "int", nullable: false),
                    BusinessUnitId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PS_PayGroupBusinessUnitDivisionId = table.Column<int>(type: "int", nullable: true),
                    PayGroupId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "IX_PayPeriods_PayGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                column: "PayGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PayGroups_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                column: "FrequencyId");

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
                name: "IX_OrganizationStructureTemplateBusinessUnits_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                column: "PayGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentTemplates_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                column: "PayGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "PayGroupId");

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
                name: "FK_Employees_PayGroups_PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "PayGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentTemplates_PayGroups_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                column: "PayGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationStructureTemplateBusinessUnits_PayGroups_PayGroupId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "OrganizationStructureTemplateBusinessUnits",
                column: "PayGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayGroups_PayFrequencies_FrequencyId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayGroups",
                column: "FrequencyId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayFrequencies",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PayPeriods_PayGroups_PayGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayPeriods",
                column: "PayGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
