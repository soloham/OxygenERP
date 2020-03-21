using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedCOAEntityConfigsAddedJoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubLedgerRequirements_COAs_COA_AccountId",
                schema: "FM",
                table: "SubLedgerRequirements");

            migrationBuilder.DropIndex(
                name: "IX_SubLedgerRequirements_COA_AccountId",
                schema: "FM",
                table: "SubLedgerRequirements");

            migrationBuilder.DropColumn(
                name: "COA_AccountId",
                schema: "FM",
                table: "SubLedgerRequirements");

            migrationBuilder.CreateTable(
                name: "SubLedgerRequirement_Account",
                schema: "FM",
                columns: table => new
                {
                    SubLedgerRequirementId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLedgerRequirement_Account", x => new { x.AccountId, x.SubLedgerRequirementId });
                    table.ForeignKey(
                        name: "FK_SubLedgerRequirement_Account_COAs_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "FM",
                        principalTable: "COAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubLedgerRequirement_Account_SubLedgerRequirements_SubLedgerRequirementId",
                        column: x => x.SubLedgerRequirementId,
                        principalSchema: "FM",
                        principalTable: "SubLedgerRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgerRequirement_Account_SubLedgerRequirementId",
                schema: "FM",
                table: "SubLedgerRequirement_Account",
                column: "SubLedgerRequirementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubLedgerRequirement_Account",
                schema: "FM");

            migrationBuilder.AddColumn<Guid>(
                name: "COA_AccountId",
                schema: "FM",
                table: "SubLedgerRequirements",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubLedgerRequirements_COAs_COA_AccountId",
                schema: "FM",
                table: "SubLedgerRequirements",
                column: "COA_AccountId",
                principalSchema: "FM",
                principalTable: "COAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            
            migrationBuilder.CreateIndex(
                name: "IX_SubLedgerRequirements_COA_AccountId",
                schema: "FM",
                table: "SubLedgerRequirements",
                column: "COA_AccountId");
        }
    }
}
