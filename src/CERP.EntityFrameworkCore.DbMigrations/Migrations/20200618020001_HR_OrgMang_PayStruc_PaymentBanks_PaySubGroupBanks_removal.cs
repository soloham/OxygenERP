using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PaymentBanks_PaySubGroupBanks_removal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PS_PaySubGroupBank");

            migrationBuilder.CreateTable(
                name: "PaymentBanks",
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
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    AccountInitials = table.Column<string>(nullable: true),
                    AccountDigits = table.Column<int>(nullable: false),
                    HasAccountNumberRestriction = table.Column<bool>(nullable: false),
                    IBANInitials = table.Column<string>(nullable: true),
                    IBANDigits = table.Column<int>(nullable: false),
                    HasIBANNumberRestriction = table.Column<bool>(nullable: false),
                    EffectiveFrom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentBanks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentBanks",
                schema: "HR.OrganizationalManagement.PayrollStructure");

            migrationBuilder.CreateTable(
                name: "PS_PaySubGroupBank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PS_PaySubGroupId = table.Column<int>(type: "int", nullable: true),
                    PaySubGroupId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_PS_PaySubGroupBank_PS_PaySubGroupId",
                table: "PS_PaySubGroupBank",
                column: "PS_PaySubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PS_PaySubGroupBank_PaySubGroupId",
                table: "PS_PaySubGroupBank",
                column: "PaySubGroupId");
        }
    }
}
