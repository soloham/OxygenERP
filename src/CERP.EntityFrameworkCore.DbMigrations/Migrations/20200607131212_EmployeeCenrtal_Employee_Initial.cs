using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCenrtal_Employee_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_BloodGroupId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_ContractStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_ContractTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_GenderId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_IndemnityTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_MaritalStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_NationalityId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_POB_ID",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_ReligionId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ReportingToId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_SITypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BloodGroupId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ContractStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ContractTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IndemnityTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_POB_ID",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PositionId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ReligionId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ReportingToId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SITypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_WorkShiftId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BloodGroupId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContractEndDate",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContractEndHDate",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContractStartDate",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContractStartHDate",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContractStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContractTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DOB",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DOB_H",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeStatusId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FamilyName",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FamilyNameLocalized",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IndemnityTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "JoiningDate",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "JoiningHDate",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NoOfDependents",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "POB_ID",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PositionId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ReportingToId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SITypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SocialInsuranceId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "VacationDays",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkShiftId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.EnsureSchema(
                name: "HR.Objects.PaymentTypes");

            migrationBuilder.EnsureSchema(
                name: "HR.EmployeeCentral");

            migrationBuilder.EnsureSchema(
                name: "HR.Objects.Contacts");

            migrationBuilder.EnsureSchema(
                name: "HR.Objects.Addresses");

            migrationBuilder.EnsureSchema(
                name: "HR.Objects.Identities");

            migrationBuilder.RenameTable(
                name: "Employees",
                schema: "HR",
                newName: "Employees",
                newSchema: "HR.EmployeeCentral");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BioAttachment",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BirthCountryId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<Guid>(
                name: "CostCenterId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeparmentId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentOrganizationStructureTemplateDivisionId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentOrganizationStructureTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HiringDate",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Initials",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MarriedSince",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PayGradeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfBirth",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PreferredLanguageId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<string>(
                name: "PreferredName",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TimezoneId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<int>(
                name: "YearlyTimeOffAllowance",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Benefits",
                schema: "HR.EmployeeCentral",
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
                    PayComponentId = table.Column<int>(nullable: false),
                    PayComponentComponentTypeAmount = table.Column<string>(nullable: true),
                    PayFrequencyId = table.Column<int>(nullable: false),
                    ValidityFromDate = table.Column<string>(nullable: true),
                    ValidityToDate = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Benefits_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Benefits_PayComponents_PayComponentId",
                        column: x => x.PayComponentId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayComponents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Benefits_PayFrequencies_PayFrequencyId",
                        column: x => x.PayFrequencyId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PayFrequencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Dependants",
                schema: "HR.EmployeeCentral",
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
                    RelationshipTypeId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    FirstNameLocalized = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthCountryId = table.Column<Guid>(nullable: false),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    BioAttachment = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependants_DictionaryValues_BirthCountryId",
                        column: x => x.BirthCountryId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dependants_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dependants_DictionaryValues_RelationshipTypeId",
                        column: x => x.RelationshipTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLoans",
                schema: "HR.EmployeeCentral",
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
                    LoanTypeId = table.Column<Guid>(nullable: false),
                    LoanStatusId = table.Column<Guid>(nullable: false),
                    LoanAmount = table.Column<double>(nullable: false),
                    ValidityFromDate = table.Column<string>(nullable: true),
                    ValidityToDate = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeLoans_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLoans_DictionaryValues_LoanStatusId",
                        column: x => x.LoanStatusId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeLoans_DictionaryValues_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailAddresses",
                schema: "HR.Objects.Addresses",
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
                    EmailTypeId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAddresses_DictionaryValues_EmailTypeId",
                        column: x => x.EmailTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HomeAddresses",
                schema: "HR.Objects.Addresses",
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
                    AddressTypeId = table.Column<Guid>(nullable: false),
                    RegularAddress = table.Column<bool>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeAddresses_DictionaryValues_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HomeAddresses_DictionaryValues_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhoneAddresses",
                schema: "HR.Objects.Addresses",
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
                    PhoneTypeId = table.Column<Guid>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneAddresses_DictionaryValues_PhoneTypeId",
                        column: x => x.PhoneTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "HR.Objects.Contacts",
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
                    RelationshipTypeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneAddress = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    AlternatePhone = table.Column<string>(nullable: true),
                    IsEmergencyContact = table.Column<bool>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_DictionaryValues_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_DictionaryValues_RelationshipTypeId",
                        column: x => x.RelationshipTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NationalIdentities",
                schema: "HR.Objects.Identities",
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
                    IdTypeId = table.Column<Guid>(nullable: false),
                    IDNumber = table.Column<string>(nullable: true),
                    IDAttachment = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    ValidityFromDate = table.Column<DateTime>(nullable: false),
                    ValidityToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalIdentities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NationalIdentities_DictionaryValues_IdTypeId",
                        column: x => x.IdTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PassportTravelDocuments",
                schema: "HR.Objects.Identities",
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
                    DocumentTypeId = table.Column<Guid>(nullable: false),
                    IssuingCountryId = table.Column<Guid>(nullable: false),
                    DocumentNumber = table.Column<string>(nullable: true),
                    DocumentAttachment = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    ValidityFromDate = table.Column<DateTime>(nullable: false),
                    ValidityToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassportTravelDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassportTravelDocuments_DictionaryValues_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PassportTravelDocuments_DictionaryValues_IssuingCountryId",
                        column: x => x.IssuingCountryId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankPaymentTypes",
                schema: "HR.Objects.PaymentTypes",
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
                    BankId = table.Column<Guid>(nullable: true),
                    BankNameId = table.Column<Guid>(nullable: false),
                    BankAccountName = table.Column<string>(nullable: true),
                    BankAccountNumber = table.Column<string>(nullable: true),
                    BankIBAN = table.Column<string>(nullable: true),
                    BankAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false),
                    ValidityFromDate = table.Column<string>(nullable: true),
                    ValidityToDate = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankPaymentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankPaymentTypes_DictionaryValues_BankId",
                        column: x => x.BankId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankPaymentTypes_DictionaryValues_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankPaymentTypes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CashPaymentTypes",
                schema: "HR.Objects.PaymentTypes",
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
                    CollectionLocationId1 = table.Column<Guid>(nullable: true),
                    CollectionLocationId = table.Column<int>(nullable: false),
                    ValidityFromDate = table.Column<string>(nullable: true),
                    ValidityToDate = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashPaymentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashPaymentTypes_LocationTemplates_CollectionLocationId1",
                        column: x => x.CollectionLocationId1,
                        principalSchema: "SETUP",
                        principalTable: "LocationTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CashPaymentTypes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChequePaymentTypes",
                schema: "HR.Objects.PaymentTypes",
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
                    NameOnCheque = table.Column<string>(nullable: true),
                    ValidityFromDate = table.Column<string>(nullable: true),
                    ValidityToDate = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChequePaymentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChequePaymentTypes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEmailAddresses",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    EmailAddressId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    EmployeeId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEmailAddresses", x => new { x.EmployeeId, x.EmailAddressId });
                    table.ForeignKey(
                        name: "FK_EmployeeEmailAddresses_EmailAddresses_EmailAddressId",
                        column: x => x.EmailAddressId,
                        principalSchema: "HR.Objects.Addresses",
                        principalTable: "EmailAddresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEmailAddresses_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeHomeAddresses",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    HomeAddressId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    EmployeeId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHomeAddresses", x => new { x.EmployeeId, x.HomeAddressId });
                    table.ForeignKey(
                        name: "FK_EmployeeHomeAddresses_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeHomeAddresses_HomeAddresses_HomeAddressId",
                        column: x => x.HomeAddressId,
                        principalSchema: "HR.Objects.Addresses",
                        principalTable: "HomeAddresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeePhoneAddresses",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    PhoneAddressId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    EmployeeId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePhoneAddresses", x => new { x.EmployeeId, x.PhoneAddressId });
                    table.ForeignKey(
                        name: "FK_EmployeePhoneAddresses_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePhoneAddresses_PhoneAddresses_PhoneAddressId",
                        column: x => x.PhoneAddressId,
                        principalSchema: "HR.Objects.Addresses",
                        principalTable: "PhoneAddresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContacts",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    ContactId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    EmployeeId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContacts", x => new { x.EmployeeId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_EmployeeContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "HR.Objects.Contacts",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeContacts_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DependantNationalIdentities",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    DependantId = table.Column<int>(nullable: false),
                    NationalIdentityId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependantNationalIdentities", x => new { x.DependantId, x.NationalIdentityId });
                    table.ForeignKey(
                        name: "FK_DependantNationalIdentities_Dependants_DependantId",
                        column: x => x.DependantId,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Dependants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DependantNationalIdentities_NationalIdentities_NationalIdentityId",
                        column: x => x.NationalIdentityId,
                        principalSchema: "HR.Objects.Identities",
                        principalTable: "NationalIdentities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeNationalIdentities",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    NationalIdentityId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    EmployeeId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeNationalIdentities", x => new { x.EmployeeId, x.NationalIdentityId });
                    table.ForeignKey(
                        name: "FK_EmployeeNationalIdentities_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeNationalIdentities_NationalIdentities_NationalIdentityId",
                        column: x => x.NationalIdentityId,
                        principalSchema: "HR.Objects.Identities",
                        principalTable: "NationalIdentities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DependantPassportTravelDocuments",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    DependantId = table.Column<int>(nullable: false),
                    PassportTravelDocumentId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependantPassportTravelDocuments", x => new { x.DependantId, x.PassportTravelDocumentId });
                    table.ForeignKey(
                        name: "FK_DependantPassportTravelDocuments_Dependants_DependantId",
                        column: x => x.DependantId,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Dependants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DependantPassportTravelDocuments_PassportTravelDocuments_PassportTravelDocumentId",
                        column: x => x.PassportTravelDocumentId,
                        principalSchema: "HR.Objects.Identities",
                        principalTable: "PassportTravelDocuments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeePassportTravelDocuments",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    PassportTravelDocumentId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    EmployeeId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePassportTravelDocuments", x => new { x.EmployeeId, x.PassportTravelDocumentId });
                    table.ForeignKey(
                        name: "FK_EmployeePassportTravelDocuments_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePassportTravelDocuments_PassportTravelDocuments_PassportTravelDocumentId",
                        column: x => x.PassportTravelDocumentId,
                        principalSchema: "HR.Objects.Identities",
                        principalTable: "PassportTravelDocuments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_EmployeeId",
                schema: "SETUP",
                table: "Positions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTemplates_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademiaTemplates_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BirthCountryId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "BirthCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CostCenterId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PayGradeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "PayGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "PayGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PreferredLanguageId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "PreferredLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TimezoneId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "TimezoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentOrganizationStructureTemplateId_DepartmentOrganizationStructureTemplateBusinessUnitId_DepartmentOrganiza~",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                columns: new[] { "DepartmentOrganizationStructureTemplateId", "DepartmentOrganizationStructureTemplateBusinessUnitId", "DepartmentOrganizationStructureTemplateDivisionId", "DepartmentTemplateId" });

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_EmployeeId",
                schema: "HR.EmployeeCentral",
                table: "Benefits",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_PayComponentId",
                schema: "HR.EmployeeCentral",
                table: "Benefits",
                column: "PayComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_PayFrequencyId",
                schema: "HR.EmployeeCentral",
                table: "Benefits",
                column: "PayFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DependantNationalIdentities_NationalIdentityId",
                schema: "HR.EmployeeCentral",
                table: "DependantNationalIdentities",
                column: "NationalIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_DependantPassportTravelDocuments_PassportTravelDocumentId",
                schema: "HR.EmployeeCentral",
                table: "DependantPassportTravelDocuments",
                column: "PassportTravelDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependants_BirthCountryId",
                schema: "HR.EmployeeCentral",
                table: "Dependants",
                column: "BirthCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependants_EmployeeId",
                schema: "HR.EmployeeCentral",
                table: "Dependants",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependants_RelationshipTypeId",
                schema: "HR.EmployeeCentral",
                table: "Dependants",
                column: "RelationshipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContacts_ContactId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContacts_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeeContacts",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmailAddresses_EmailAddressId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeEmailAddresses",
                column: "EmailAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmailAddresses_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeeEmailAddresses",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHomeAddresses_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeeHomeAddresses",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHomeAddresses_HomeAddressId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeHomeAddresses",
                column: "HomeAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLoans_EmployeeId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLoans_LoanStatusId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans",
                column: "LoanStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLoans_LoanTypeId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeLoans",
                column: "LoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeNationalIdentities_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeeNationalIdentities",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeNationalIdentities_NationalIdentityId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeNationalIdentities",
                column: "NationalIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePassportTravelDocuments_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeePassportTravelDocuments",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePassportTravelDocuments_PassportTravelDocumentId",
                schema: "HR.EmployeeCentral",
                table: "EmployeePassportTravelDocuments",
                column: "PassportTravelDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhoneAddresses_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeePhoneAddresses",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhoneAddresses_PhoneAddressId",
                schema: "HR.EmployeeCentral",
                table: "EmployeePhoneAddresses",
                column: "PhoneAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_EmailTypeId",
                schema: "HR.Objects.Addresses",
                table: "EmailAddresses",
                column: "EmailTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeAddresses_AddressTypeId",
                schema: "HR.Objects.Addresses",
                table: "HomeAddresses",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeAddresses_CountryId",
                schema: "HR.Objects.Addresses",
                table: "HomeAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneAddresses_PhoneTypeId",
                schema: "HR.Objects.Addresses",
                table: "PhoneAddresses",
                column: "PhoneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CountryId",
                schema: "HR.Objects.Contacts",
                table: "Contacts",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_RelationshipTypeId",
                schema: "HR.Objects.Contacts",
                table: "Contacts",
                column: "RelationshipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NationalIdentities_IdTypeId",
                schema: "HR.Objects.Identities",
                table: "NationalIdentities",
                column: "IdTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PassportTravelDocuments_DocumentTypeId",
                schema: "HR.Objects.Identities",
                table: "PassportTravelDocuments",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PassportTravelDocuments_IssuingCountryId",
                schema: "HR.Objects.Identities",
                table: "PassportTravelDocuments",
                column: "IssuingCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BankPaymentTypes_BankId",
                schema: "HR.Objects.PaymentTypes",
                table: "BankPaymentTypes",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankPaymentTypes_CountryId",
                schema: "HR.Objects.PaymentTypes",
                table: "BankPaymentTypes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BankPaymentTypes_EmployeeId",
                schema: "HR.Objects.PaymentTypes",
                table: "BankPaymentTypes",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentTypes_CollectionLocationId1",
                schema: "HR.Objects.PaymentTypes",
                table: "CashPaymentTypes",
                column: "CollectionLocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentTypes_EmployeeId",
                schema: "HR.Objects.PaymentTypes",
                table: "CashPaymentTypes",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChequePaymentTypes_EmployeeId",
                schema: "HR.Objects.PaymentTypes",
                table: "ChequePaymentTypes",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_BirthCountryId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "BirthCountryId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_CostCenterId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "CostCenterId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_GenderId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "GenderId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_MaritalStatusId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "MaritalStatusId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_NationalityId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "NationalityId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PayGrades_PayGradeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "PayGradeId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayGrades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PayGroupes_PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "PayGroupId",
                principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                principalTable: "PayGroupes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_PreferredLanguageId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "PreferredLanguageId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_TimezoneId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "TimezoneId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_OrganizationStructureTemplateDepartments_DepartmentOrganizationStructureTemplateId_DepartmentOrganizationStructure~",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                columns: new[] { "DepartmentOrganizationStructureTemplateId", "DepartmentOrganizationStructureTemplateBusinessUnitId", "DepartmentOrganizationStructureTemplateDivisionId", "DepartmentTemplateId" },
                principalSchema: "HR.OrganizationalManagement.OrganizationStructure",
                principalTable: "OrganizationStructureTemplateDepartments",
                principalColumns: new[] { "OrganizationStructureTemplateId", "OrganizationStructureTemplateBusinessUnitId", "OrganizationStructureTemplateDivisionId", "DepartmentTemplateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AcademiaTemplates_Employees_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates",
                column: "EmployeeId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillTemplates_Employees_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates",
                column: "EmployeeId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Employees_EmployeeId",
                schema: "SETUP",
                table: "Positions",
                column: "EmployeeId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_BirthCountryId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_CostCenterId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_GenderId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_MaritalStatusId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_NationalityId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PayGrades_PayGradeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PayGroupes_PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_PreferredLanguageId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_TimezoneId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_OrganizationStructureTemplateDepartments_DepartmentOrganizationStructureTemplateId_DepartmentOrganizationStructure~",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademiaTemplates_Employees_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillTemplates_Employees_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Employees_EmployeeId",
                schema: "SETUP",
                table: "Positions");

            migrationBuilder.DropTable(
                name: "Benefits",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "DependantNationalIdentities",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "DependantPassportTravelDocuments",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "EmployeeContacts",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "EmployeeEmailAddresses",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "EmployeeHomeAddresses",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "EmployeeLoans",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "EmployeeNationalIdentities",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "EmployeePassportTravelDocuments",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "EmployeePhoneAddresses",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "BankPaymentTypes",
                schema: "HR.Objects.PaymentTypes");

            migrationBuilder.DropTable(
                name: "CashPaymentTypes",
                schema: "HR.Objects.PaymentTypes");

            migrationBuilder.DropTable(
                name: "ChequePaymentTypes",
                schema: "HR.Objects.PaymentTypes");

            migrationBuilder.DropTable(
                name: "Dependants",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "HR.Objects.Contacts");

            migrationBuilder.DropTable(
                name: "EmailAddresses",
                schema: "HR.Objects.Addresses");

            migrationBuilder.DropTable(
                name: "HomeAddresses",
                schema: "HR.Objects.Addresses");

            migrationBuilder.DropTable(
                name: "NationalIdentities",
                schema: "HR.Objects.Identities");

            migrationBuilder.DropTable(
                name: "PassportTravelDocuments",
                schema: "HR.Objects.Identities");

            migrationBuilder.DropTable(
                name: "PhoneAddresses",
                schema: "HR.Objects.Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Positions_EmployeeId",
                schema: "SETUP",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_SkillTemplates_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates");

            migrationBuilder.DropIndex(
                name: "IX_AcademiaTemplates_EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BirthCountryId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CostCenterId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PayGradeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PreferredLanguageId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TimezoneId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentOrganizationStructureTemplateId_DepartmentOrganizationStructureTemplateBusinessUnitId_DepartmentOrganiza~",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates");

            migrationBuilder.DropColumn(
                name: "BioAttachment",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BirthCountryId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DeparmentId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentOrganizationStructureTemplateBusinessUnitId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentOrganizationStructureTemplateDivisionId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentOrganizationStructureTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentTemplateId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "HiringDate",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Initials",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MarriedSince",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PayGradeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PayGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PlaceOfBirth",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PreferredLanguageId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PreferredName",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TimezoneId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "YearlyTimeOffAllowance",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                schema: "HR.EmployeeCentral",
                newName: "Employees",
                newSchema: "HR");

            migrationBuilder.AddColumn<Guid>(
                name: "BloodGroupId",
                schema: "HR",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractEndDate",
                schema: "HR",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractEndHDate",
                schema: "HR",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractStartDate",
                schema: "HR",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractStartHDate",
                schema: "HR",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContractStatusId",
                schema: "HR",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<Guid>(
                name: "ContractTypeId",
                schema: "HR",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<string>(
                name: "DOB",
                schema: "HR",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DOB_H",
                schema: "HR",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                schema: "HR",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeStatusId",
                schema: "HR",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeTypeId",
                schema: "HR",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<string>(
                name: "FamilyName",
                schema: "HR",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyNameLocalized",
                schema: "HR",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IndemnityTypeId",
                schema: "HR",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JoiningDate",
                schema: "HR",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JoiningHDate",
                schema: "HR",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfDependents",
                schema: "HR",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "POB_ID",
                schema: "HR",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                schema: "HR",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReligionId",
                schema: "HR",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReportingToId",
                schema: "HR",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SITypeId",
                schema: "HR",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialInsuranceId",
                schema: "HR",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacationDays",
                schema: "HR",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkShiftId",
                schema: "HR",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BloodGroupId",
                schema: "HR",
                table: "Employees",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContractStatusId",
                schema: "HR",
                table: "Employees",
                column: "ContractStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContractTypeId",
                schema: "HR",
                table: "Employees",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                schema: "HR",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeStatusId",
                schema: "HR",
                table: "Employees",
                column: "EmployeeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                schema: "HR",
                table: "Employees",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IndemnityTypeId",
                schema: "HR",
                table: "Employees",
                column: "IndemnityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_POB_ID",
                schema: "HR",
                table: "Employees",
                column: "POB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                schema: "HR",
                table: "Employees",
                column: "PositionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReligionId",
                schema: "HR",
                table: "Employees",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportingToId",
                schema: "HR",
                table: "Employees",
                column: "ReportingToId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SITypeId",
                schema: "HR",
                table: "Employees",
                column: "SITypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorkShiftId",
                schema: "HR",
                table: "Employees",
                column: "WorkShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_BloodGroupId",
                schema: "HR",
                table: "Employees",
                column: "BloodGroupId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_ContractStatusId",
                schema: "HR",
                table: "Employees",
                column: "ContractStatusId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_ContractTypeId",
                schema: "HR",
                table: "Employees",
                column: "ContractTypeId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                schema: "HR",
                table: "Employees",
                column: "DepartmentId",
                principalSchema: "SETUP",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeStatusId",
                schema: "HR",
                table: "Employees",
                column: "EmployeeStatusId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeTypeId",
                schema: "HR",
                table: "Employees",
                column: "EmployeeTypeId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_GenderId",
                schema: "HR",
                table: "Employees",
                column: "GenderId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_IndemnityTypeId",
                schema: "HR",
                table: "Employees",
                column: "IndemnityTypeId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_MaritalStatusId",
                schema: "HR",
                table: "Employees",
                column: "MaritalStatusId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_NationalityId",
                schema: "HR",
                table: "Employees",
                column: "NationalityId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_POB_ID",
                schema: "HR",
                table: "Employees",
                column: "POB_ID",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionId",
                schema: "HR",
                table: "Employees",
                column: "PositionId",
                principalSchema: "SETUP",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_ReligionId",
                schema: "HR",
                table: "Employees",
                column: "ReligionId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ReportingToId",
                schema: "HR",
                table: "Employees",
                column: "ReportingToId",
                principalSchema: "HR",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_SITypeId",
                schema: "HR",
                table: "Employees",
                column: "SITypeId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId",
                schema: "HR",
                table: "Employees",
                column: "WorkShiftId",
                principalSchema: "HR",
                principalTable: "WorkShifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
