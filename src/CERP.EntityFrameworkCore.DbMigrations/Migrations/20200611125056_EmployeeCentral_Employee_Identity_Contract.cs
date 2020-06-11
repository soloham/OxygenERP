using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_Identity_Contract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeContacts",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(nullable: false),
                    ContactId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_EmployeeContacts", x => new { x.EmployeeId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_EmployeeContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "HR.Objects.Contacts",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeContacts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
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
                    EmployeeId = table.Column<Guid>(nullable: false),
                    DisabilityId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_EmployeeDisabilities", x => new { x.EmployeeId, x.DisabilityId });
                    table.ForeignKey(
                        name: "FK_EmployeeDisabilities_Disabilities_DisabilityId",
                        column: x => x.DisabilityId,
                        principalSchema: "HR.Objects.Attributes",
                        principalTable: "Disabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDisabilities_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEmailAddresses",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(nullable: false),
                    EmailAddressId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_EmployeeEmailAddresses", x => new { x.EmployeeId, x.EmailAddressId });
                    table.ForeignKey(
                        name: "FK_EmployeeEmailAddresses_EmailAddresses_EmailAddressId",
                        column: x => x.EmailAddressId,
                        principalSchema: "HR.Objects.Addresses",
                        principalTable: "EmailAddresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEmailAddresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
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
                    EmployeeId = table.Column<Guid>(nullable: false),
                    HomeAddressId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_EmployeeHomeAddresses", x => new { x.EmployeeId, x.HomeAddressId });
                    table.ForeignKey(
                        name: "FK_EmployeeHomeAddresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
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
                name: "EmployeePassportTravelDocuments",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_EmployeePassportTravelDocuments", x => new { x.EmployeeId, x.PassportTravelDocumentId });
                    table.ForeignKey(
                        name: "FK_EmployeePassportTravelDocuments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
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
                    EmployeeId = table.Column<Guid>(nullable: false),
                    PhoneAddressId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_EmployeePhoneAddresses", x => new { x.EmployeeId, x.PhoneAddressId });
                    table.ForeignKey(
                        name: "FK_EmployeePhoneAddresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
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
                name: "EmployeeSponsorLegalEntities",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(nullable: false),
                    LegalEntityId = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_EmployeeSponsorLegalEntities", x => new { x.EmployeeId, x.LegalEntityId });
                    table.ForeignKey(
                        name: "FK_EmployeeSponsorLegalEntities_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSponsorLegalEntities_Companies_LegalEntityId",
                        column: x => x.LegalEntityId,
                        principalSchema: "SETUP",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContacts_ContactId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDisabilities_DisabilityId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeDisabilities",
                column: "DisabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmailAddresses_EmailAddressId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeEmailAddresses",
                column: "EmailAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHomeAddresses_HomeAddressId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeHomeAddresses",
                column: "HomeAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePassportTravelDocuments_PassportTravelDocumentId",
                schema: "HR.EmployeeCentral",
                table: "EmployeePassportTravelDocuments",
                column: "PassportTravelDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhoneAddresses_PhoneAddressId",
                schema: "HR.EmployeeCentral",
                table: "EmployeePhoneAddresses",
                column: "PhoneAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSponsorLegalEntities_LegalEntityId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeSponsorLegalEntities",
                column: "LegalEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "EmployeePassportTravelDocuments",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "EmployeePhoneAddresses",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "EmployeeSponsorLegalEntities",
                schema: "HR.EmployeeCentral");
        }
    }
}
