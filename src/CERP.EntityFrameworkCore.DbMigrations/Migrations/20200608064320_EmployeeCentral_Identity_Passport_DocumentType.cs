using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Identity_Passport_DocumentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassportTravelDocuments_DictionaryValues_DocumentTypeId",
                schema: "HR.Objects.Identities",
                table: "PassportTravelDocuments");

            migrationBuilder.DropIndex(
                name: "IX_PassportTravelDocuments_DocumentTypeId",
                schema: "HR.Objects.Identities",
                table: "PassportTravelDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                schema: "HR.Objects.Identities",
                table: "PassportTravelDocuments");

            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                schema: "HR.Objects.Identities",
                table: "PassportTravelDocuments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentType",
                schema: "HR.Objects.Identities",
                table: "PassportTravelDocuments");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentTypeId",
                schema: "HR.Objects.Identities",
                table: "PassportTravelDocuments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PassportTravelDocuments_DocumentTypeId",
                schema: "HR.Objects.Identities",
                table: "PassportTravelDocuments",
                column: "DocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PassportTravelDocuments_DictionaryValues_DocumentTypeId",
                schema: "HR.Objects.Identities",
                table: "PassportTravelDocuments",
                column: "DocumentTypeId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");
        }
    }
}
