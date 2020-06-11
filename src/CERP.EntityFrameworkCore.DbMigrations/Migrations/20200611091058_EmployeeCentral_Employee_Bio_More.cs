using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_Bio_More : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DependantNationalIdentities_Dependants_DependantId",
                schema: "HR.EmployeeCentral",
                table: "DependantNationalIdentities");

            migrationBuilder.DropForeignKey(
                name: "FK_DependantPassportTravelDocuments_Dependants_DependantId",
                schema: "HR.EmployeeCentral",
                table: "DependantPassportTravelDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeNationalIdentities_Employees_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeeNationalIdentities");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePassportTravelDocuments_Employees_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeePassportTravelDocuments");

            migrationBuilder.EnsureSchema(
                name: "HR.Objects.Attributes");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployemeGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployemeSubGroupId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployementTypeId",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<string>(
                name: "ValidityFromDate",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValidityToDate",
                schema: "HR.EmployeeCentral",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NationalityId",
                schema: "HR.EmployeeCentral",
                table: "Dependants",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.CreateTable(
                name: "Disabilities",
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
                    CertificateIssuingAuthority = table.Column<string>(nullable: true),
                    Attachment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disabilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDisabilities",
                schema: "HR.EmployeeCentral",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    DisabilityId = table.Column<int>(nullable: false),
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
                name: "IX_Dependants_NationalityId",
                schema: "HR.EmployeeCentral",
                table: "Dependants",
                column: "NationalityId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DependantNationalIdentities_Dependants_DependantId",
                schema: "HR.EmployeeCentral",
                table: "DependantNationalIdentities",
                column: "DependantId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Dependants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DependantPassportTravelDocuments_Dependants_DependantId",
                schema: "HR.EmployeeCentral",
                table: "DependantPassportTravelDocuments",
                column: "DependantId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Dependants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependants_DictionaryValues_NationalityId",
                schema: "HR.EmployeeCentral",
                table: "Dependants",
                column: "NationalityId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeNationalIdentities_Employees_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeeNationalIdentities",
                column: "EmployeeId1",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePassportTravelDocuments_Employees_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeePassportTravelDocuments",
                column: "EmployeeId1",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Employees",
                principalColumn: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DependantNationalIdentities_Dependants_DependantId",
                schema: "HR.EmployeeCentral",
                table: "DependantNationalIdentities");

            migrationBuilder.DropForeignKey(
                name: "FK_DependantPassportTravelDocuments_Dependants_DependantId",
                schema: "HR.EmployeeCentral",
                table: "DependantPassportTravelDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_Dependants_DictionaryValues_NationalityId",
                schema: "HR.EmployeeCentral",
                table: "Dependants");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeNationalIdentities_Employees_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeeNationalIdentities");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePassportTravelDocuments_Employees_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeePassportTravelDocuments");

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
                name: "EmployeeDisabilities",
                schema: "HR.EmployeeCentral");

            migrationBuilder.DropTable(
                name: "Disabilities",
                schema: "HR.Objects.Attributes");

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

            migrationBuilder.DropIndex(
                name: "IX_Dependants_NationalityId",
                schema: "HR.EmployeeCentral",
                table: "Dependants");

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

            migrationBuilder.DropColumn(
                name: "ValidityFromDate",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ValidityToDate",
                schema: "HR.EmployeeCentral",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                schema: "HR.EmployeeCentral",
                table: "Dependants");

            migrationBuilder.AddForeignKey(
                name: "FK_DependantNationalIdentities_Dependants_DependantId",
                schema: "HR.EmployeeCentral",
                table: "DependantNationalIdentities",
                column: "DependantId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Dependants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DependantPassportTravelDocuments_Dependants_DependantId",
                schema: "HR.EmployeeCentral",
                table: "DependantPassportTravelDocuments",
                column: "DependantId",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Dependants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeNationalIdentities_Employees_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeeNationalIdentities",
                column: "EmployeeId1",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePassportTravelDocuments_Employees_EmployeeId1",
                schema: "HR.EmployeeCentral",
                table: "EmployeePassportTravelDocuments",
                column: "EmployeeId1",
                principalSchema: "HR.EmployeeCentral",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
