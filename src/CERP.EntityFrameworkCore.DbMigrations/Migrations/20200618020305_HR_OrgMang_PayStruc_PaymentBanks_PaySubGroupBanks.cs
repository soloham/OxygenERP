using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OrgMang_PayStruc_PaymentBanks_PaySubGroupBanks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaySubGroupBanks",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PaySubGroupId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    BankId = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    PS_PaySubGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaySubGroupBanks", x => new { x.PaySubGroupId, x.Id });
                    table.ForeignKey(
                        name: "FK_PaySubGroupBanks_PaymentBanks_BankId",
                        column: x => x.BankId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PaymentBanks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaySubGroupBanks_PaySubGroups_PS_PaySubGroupId",
                        column: x => x.PS_PaySubGroupId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PaySubGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaySubGroupBanks_PaySubGroups_PaySubGroupId",
                        column: x => x.PaySubGroupId,
                        principalSchema: "HR.OrganizationalManagement.PayrollStructure",
                        principalTable: "PaySubGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaySubGroupBanks_BankId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_PaySubGroupBanks_PS_PaySubGroupId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PaySubGroupBanks",
                column: "PS_PaySubGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaySubGroupBanks",
                schema: "HR.OrganizationalManagement.PayrollStructure");
        }
    }
}
