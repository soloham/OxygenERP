using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_Identities_Cascading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DependantNationalIdentities_NationalIdentities_NationalIdentityId",
                schema: "HR.EmployeeCentral",
                table: "DependantNationalIdentities");

            migrationBuilder.DropForeignKey(
                name: "FK_DependantPassportTravelDocuments_PassportTravelDocuments_PassportTravelDocumentId",
                schema: "HR.EmployeeCentral",
                table: "DependantPassportTravelDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeNationalIdentities_NationalIdentities_NationalIdentityId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeNationalIdentities");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePassportTravelDocuments_PassportTravelDocuments_PassportTravelDocumentId",
                schema: "HR.EmployeeCentral",
                table: "EmployeePassportTravelDocuments");

            migrationBuilder.AddForeignKey(
                name: "FK_DependantNationalIdentities_NationalIdentities_NationalIdentityId",
                schema: "HR.EmployeeCentral",
                table: "DependantNationalIdentities",
                column: "NationalIdentityId",
                principalSchema: "HR.Objects.Identities",
                principalTable: "NationalIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DependantPassportTravelDocuments_PassportTravelDocuments_PassportTravelDocumentId",
                schema: "HR.EmployeeCentral",
                table: "DependantPassportTravelDocuments",
                column: "PassportTravelDocumentId",
                principalSchema: "HR.Objects.Identities",
                principalTable: "PassportTravelDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeNationalIdentities_NationalIdentities_NationalIdentityId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeNationalIdentities",
                column: "NationalIdentityId",
                principalSchema: "HR.Objects.Identities",
                principalTable: "NationalIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePassportTravelDocuments_PassportTravelDocuments_PassportTravelDocumentId",
                schema: "HR.EmployeeCentral",
                table: "EmployeePassportTravelDocuments",
                column: "PassportTravelDocumentId",
                principalSchema: "HR.Objects.Identities",
                principalTable: "PassportTravelDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DependantNationalIdentities_NationalIdentities_NationalIdentityId",
                schema: "HR.EmployeeCentral",
                table: "DependantNationalIdentities");

            migrationBuilder.DropForeignKey(
                name: "FK_DependantPassportTravelDocuments_PassportTravelDocuments_PassportTravelDocumentId",
                schema: "HR.EmployeeCentral",
                table: "DependantPassportTravelDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeNationalIdentities_NationalIdentities_NationalIdentityId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeNationalIdentities");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePassportTravelDocuments_PassportTravelDocuments_PassportTravelDocumentId",
                schema: "HR.EmployeeCentral",
                table: "EmployeePassportTravelDocuments");

            migrationBuilder.AddForeignKey(
                name: "FK_DependantNationalIdentities_NationalIdentities_NationalIdentityId",
                schema: "HR.EmployeeCentral",
                table: "DependantNationalIdentities",
                column: "NationalIdentityId",
                principalSchema: "HR.Objects.Identities",
                principalTable: "NationalIdentities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DependantPassportTravelDocuments_PassportTravelDocuments_PassportTravelDocumentId",
                schema: "HR.EmployeeCentral",
                table: "DependantPassportTravelDocuments",
                column: "PassportTravelDocumentId",
                principalSchema: "HR.Objects.Identities",
                principalTable: "PassportTravelDocuments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeNationalIdentities_NationalIdentities_NationalIdentityId",
                schema: "HR.EmployeeCentral",
                table: "EmployeeNationalIdentities",
                column: "NationalIdentityId",
                principalSchema: "HR.Objects.Identities",
                principalTable: "NationalIdentities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePassportTravelDocuments_PassportTravelDocuments_PassportTravelDocumentId",
                schema: "HR.EmployeeCentral",
                table: "EmployeePassportTravelDocuments",
                column: "PassportTravelDocumentId",
                principalSchema: "HR.Objects.Identities",
                principalTable: "PassportTravelDocuments",
                principalColumn: "Id");
        }
    }
}
