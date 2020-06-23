using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class PaymentBanksFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentBankFiles",
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
                    Name = table.Column<string>(nullable: true),
                    NameLocalized = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentBankFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentBankFileBanks",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentBankFileId = table.Column<int>(nullable: false),
                    BankId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentBankFileBanks", x => new { x.PaymentBankFileId, x.BankId, x.Id });
                    table.ForeignKey(
                        name: "FK_PaymentBankFileBanks_PaymentBanks_BankId",
                        column: x => x.BankId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PaymentBanks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentBankFileBanks_PaymentBankFiles_PaymentBankFileId",
                        column: x => x.PaymentBankFileId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PaymentBankFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentBankFileBanks_BankId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaymentBankFileBanks",
                column: "BankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentBankFileBanks",
                schema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.DropTable(
                name: "PaymentBankFiles",
                schema: "HR.OrganizationalManagement.PayrollStructure");
        }
    }
}
