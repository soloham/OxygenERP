using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_Identity_Contract_ForeignKeysFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_EmployemeGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_EmployemeSubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_EmployementTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeContacts",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "EmployeeDisabilities",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "EmployeeEmailAddresses",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "EmployeeHomeAddresses",
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

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployemeGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployemeSubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployementTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployemeGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployemeSubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployementTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeSubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmploymentTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "IqamaLabourOfficeValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IqamaNumber",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IqamaNumberValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IqamaPlaceOfIssue",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IqamaSponsorAddressLine1",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IqamaSponsorAddressLine2",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IqamaSponsorAttachment",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IqamaSponsorContractSecured",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IqamaSponsorEmailAddress",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IqamaSponsorLabourOfficeNumber",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IqamaSponsorName",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IqamaSponsorNameLocal",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IqamaSponsorTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "LabourOfficeNumber",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LabourOfficePlaceOfIssue",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalIdentitiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NationalIdentityNameOnID",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalIdentityNameOnIDLocal",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalIdentityNumber",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NationalIdentityTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EmployeePrimaryValidityAttachments",
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
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePrimaryValidityAttachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryValidityAttachments",
                schema: "HR.Objects.Attributes",
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
                    EmployeePrimaryValidityAttachmentId = table.Column<int>(nullable: false),
                    Attachment = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    ValidityFromDate = table.Column<string>(nullable: true),
                    ValidityToDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryValidityAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrimaryValidityAttachments_EmployeePrimaryValidityAttachments_EmployeePrimaryValidityAttachmentId",
                        column: x => x.EmployeePrimaryValidityAttachmentId,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "EmployeePrimaryValidityAttachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "EmployeeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeSubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "EmployeeSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmploymentTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IqamaLabourOfficeValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "IqamaLabourOfficeValiditiesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IqamaNumberValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "IqamaNumberValiditiesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IqamaSponsorTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "IqamaSponsorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalIdentitiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "NationalIdentitiesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalIdentityTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "NationalIdentityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryValidityAttachments_EmployeePrimaryValidityAttachmentId",
                schema: "HR.Objects.Attributes",
                table: "PrimaryValidityAttachments",
                column: "EmployeePrimaryValidityAttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "EmployeeGroupId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeSubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "EmployeeSubGroupId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_EmploymentTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "EmploymentTypeId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeePrimaryValidityAttachments_IqamaLabourOfficeValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "IqamaLabourOfficeValiditiesId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "EmployeePrimaryValidityAttachments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeePrimaryValidityAttachments_IqamaNumberValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "IqamaNumberValiditiesId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "EmployeePrimaryValidityAttachments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_IqamaSponsorTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "IqamaSponsorTypeId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeePrimaryValidityAttachments_NationalIdentitiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "NationalIdentitiesId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "EmployeePrimaryValidityAttachments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_NationalIdentityTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "NationalIdentityTypeId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeSubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_EmploymentTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeePrimaryValidityAttachments_IqamaLabourOfficeValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeePrimaryValidityAttachments_IqamaNumberValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_IqamaSponsorTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeePrimaryValidityAttachments_NationalIdentitiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_NationalIdentityTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "PrimaryValidityAttachments",
                schema: "HR.Objects.Attributes");

            migrationBuilder.DropTable(
                name: "EmployeePrimaryValidityAttachments",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeSubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmploymentTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IqamaLabourOfficeValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IqamaNumberValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IqamaSponsorTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_NationalIdentitiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_NationalIdentityTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeSubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmploymentTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaLabourOfficeValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaNumber",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaNumberValiditiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaPlaceOfIssue",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaSponsorAddressLine1",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaSponsorAddressLine2",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaSponsorAttachment",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaSponsorContractSecured",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaSponsorEmailAddress",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaSponsorLabourOfficeNumber",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaSponsorName",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaSponsorNameLocal",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaSponsorTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LabourOfficeNumber",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LabourOfficePlaceOfIssue",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NationalIdentitiesId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NationalIdentityNameOnID",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NationalIdentityNameOnIDLocal",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NationalIdentityNumber",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NationalIdentityTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployemeGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployemeSubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployementTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EmployeeContacts",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "EmployeeDisabilities",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DisabilityId = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDisabilities", x => new { x.EmployeeId, x.DisabilityId });
                    table.ForeignKey(
                        name: "FK_EmployeeDisabilities_Disabilities_DisabilityId",
                        column: x => x.DisabilityId,
                        principalSchema: "HR.Objects.Attributes",
                        principalTable: "Disabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDisabilities_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEmailAddresses",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmailAddressId = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    HomeAddressId = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "EmployeeNationalIdentities",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    NationalIdentityId = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeNationalIdentities", x => new { x.EmployeeId, x.NationalIdentityId });
                    table.ForeignKey(
                        name: "FK_EmployeeNationalIdentities_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeNationalIdentities_NationalIdentities_NationalIdentityId",
                        column: x => x.NationalIdentityId,
                        principalSchema: "HR.Objects.Identities",
                        principalTable: "NationalIdentities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePassportTravelDocuments",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PassportTravelDocumentId = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePassportTravelDocuments", x => new { x.EmployeeId, x.PassportTravelDocumentId });
                    table.ForeignKey(
                        name: "FK_EmployeePassportTravelDocuments_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeePassportTravelDocuments_PassportTravelDocuments_PassportTravelDocumentId",
                        column: x => x.PassportTravelDocumentId,
                        principalSchema: "HR.Objects.Identities",
                        principalTable: "PassportTravelDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePhoneAddresses",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PhoneAddressId = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployemeGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "EmployemeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployemeSubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "EmployemeSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployementTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "EmployementTypeId");

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
                name: "IX_EmployeeDisabilities_DisabilityId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeDisabilities",
                column: "DisabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDisabilities_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeeDisabilities",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_EmployemeGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "EmployemeGroupId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_EmployemeSubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "EmployemeSubGroupId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_EmployementTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                column: "EmployementTypeId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");
        }
    }
}
