using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class CompanyRevamped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Companies_CompanyId",
                schema: "SETUP",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AddressLocalizationKey",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "BankDetail",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "BankDetailLocalizationKey",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CRNumber",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyCode",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FiscalYearBasis",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FiscalYearStartMonth",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "NameLocalizationKey",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "VATNumber",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Website",
                schema: "OxygenERP",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "OxygenERP",
                newName: "Companies",
                newSchema: "SETUP");

            migrationBuilder.AlterColumn<int>(
                name: "Language",
                schema: "SETUP",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                schema: "SETUP",
                table: "Companies",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyNameLocalized",
                schema: "SETUP",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationID",
                schema: "SETUP",
                table: "Companies",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SocialInsuranceID",
                schema: "SETUP",
                table: "Companies",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "SETUP",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TaxID",
                schema: "SETUP",
                table: "Companies",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VATID",
                schema: "SETUP",
                table: "Companies",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CompanyCurrencies",
                schema: "SETUP",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    CurrencyType = table.Column<int>(nullable: false),
                    ExchangeRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCurrencies", x => new { x.CompanyId, x.CurrencyId });
                    table.ForeignKey(
                        name: "FK_CompanyCurrencies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "SETUP",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyCurrencies_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "SETUP",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyLocations",
                schema: "SETUP",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    LocationId1 = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LocationValidityStart = table.Column<string>(nullable: true),
                    LocationValidityEnd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLocations", x => new { x.CompanyId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_CompanyLocations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "SETUP",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyLocations_LocationTemplates_LocationId1",
                        column: x => x.LocationId1,
                        principalSchema: "SETUP",
                        principalTable: "LocationTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPrintSizes",
                schema: "SETUP",
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
                    PrintSize = table.Column<int>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPrintSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyPrintSizes_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "SETUP",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCurrencies_CurrencyId",
                schema: "SETUP",
                table: "CompanyCurrencies",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLocations_LocationId1",
                schema: "SETUP",
                table: "CompanyLocations",
                column: "LocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPrintSizes_CompanyId",
                schema: "SETUP",
                table: "CompanyPrintSizes",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Companies_CompanyId",
                schema: "SETUP",
                table: "Departments",
                column: "CompanyId",
                principalSchema: "SETUP",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Companies_CompanyId",
                schema: "SETUP",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "CompanyCurrencies",
                schema: "SETUP");

            migrationBuilder.DropTable(
                name: "CompanyLocations",
                schema: "SETUP");

            migrationBuilder.DropTable(
                name: "CompanyPrintSizes",
                schema: "SETUP");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                schema: "SETUP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyNameLocalized",
                schema: "SETUP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "RegistrationID",
                schema: "SETUP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "SocialInsuranceID",
                schema: "SETUP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "SETUP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TaxID",
                schema: "SETUP",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "VATID",
                schema: "SETUP",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "SETUP",
                newName: "Companies",
                newSchema: "OxygenERP");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "OxygenERP",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "OxygenERP",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLocalizationKey",
                schema: "OxygenERP",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankDetail",
                schema: "OxygenERP",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BankDetailLocalizationKey",
                schema: "OxygenERP",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CRNumber",
                schema: "OxygenERP",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyCode",
                schema: "OxygenERP",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "OxygenERP",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FiscalYearBasis",
                schema: "OxygenERP",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearStartMonth",
                schema: "OxygenERP",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                schema: "OxygenERP",
                table: "Companies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "OxygenERP",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameLocalizationKey",
                schema: "OxygenERP",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "OxygenERP",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VATNumber",
                schema: "OxygenERP",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                schema: "OxygenERP",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Companies_CompanyId",
                schema: "SETUP",
                table: "Departments",
                column: "CompanyId",
                principalSchema: "OxygenERP",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
