using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PaymentBanks_Country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaymentBanks");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaymentBanks",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PaymentBanks_CountryId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaymentBanks",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentBanks_DictionaryValues_CountryId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaymentBanks",
                column: "CountryId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentBanks_DictionaryValues_CountryId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaymentBanks");

            migrationBuilder.DropIndex(
                name: "IX_PaymentBanks_CountryId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaymentBanks");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaymentBanks");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaymentBanks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
