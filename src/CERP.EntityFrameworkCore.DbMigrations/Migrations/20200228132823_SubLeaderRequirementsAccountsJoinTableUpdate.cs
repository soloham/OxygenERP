using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class SubLeaderRequirementsAccountsJoinTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COA_SubLedgerRequirement_Account_COAs_AccountId",
                table: "COA_SubLedgerRequirement_Account");

            migrationBuilder.DropForeignKey(
                name: "FK_COA_SubLedgerRequirement_Account_SubLedgerRequirements_SubLedgerRequirementId",
                table: "COA_SubLedgerRequirement_Account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_COA_SubLedgerRequirement_Account",
                table: "COA_SubLedgerRequirement_Account");

            migrationBuilder.RenameTable(
                name: "COA_SubLedgerRequirement_Account",
                newName: "SubLedgerRequirement_Account",
                newSchema: "FM");

            migrationBuilder.RenameIndex(
                name: "IX_COA_SubLedgerRequirement_Account_SubLedgerRequirementId",
                schema: "FM",
                table: "SubLedgerRequirement_Account",
                newName: "IX_SubLedgerRequirement_Account_SubLedgerRequirementId");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "FM",
                table: "SubLedgerRequirement_Account",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "FM",
                table: "SubLedgerRequirement_Account",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "FM",
                table: "SubLedgerRequirement_Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "FM",
                table: "SubLedgerRequirement_Account",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "FM",
                table: "SubLedgerRequirement_Account",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "FM",
                table: "SubLedgerRequirement_Account",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "FM",
                table: "SubLedgerRequirement_Account",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubLedgerRequirement_Account",
                schema: "FM",
                table: "SubLedgerRequirement_Account",
                columns: new[] { "AccountId", "SubLedgerRequirementId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SubLedgerRequirement_Account_COAs_AccountId",
                schema: "FM",
                table: "SubLedgerRequirement_Account",
                column: "AccountId",
                principalSchema: "FM",
                principalTable: "COAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubLedgerRequirement_Account_SubLedgerRequirements_SubLedgerRequirementId",
                schema: "FM",
                table: "SubLedgerRequirement_Account",
                column: "SubLedgerRequirementId",
                principalSchema: "FM",
                principalTable: "SubLedgerRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubLedgerRequirement_Account_COAs_AccountId",
                schema: "FM",
                table: "SubLedgerRequirement_Account");

            migrationBuilder.DropForeignKey(
                name: "FK_SubLedgerRequirement_Account_SubLedgerRequirements_SubLedgerRequirementId",
                schema: "FM",
                table: "SubLedgerRequirement_Account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubLedgerRequirement_Account",
                schema: "FM",
                table: "SubLedgerRequirement_Account");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "FM",
                table: "SubLedgerRequirement_Account");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                schema: "FM",
                table: "SubLedgerRequirement_Account");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                schema: "FM",
                table: "SubLedgerRequirement_Account");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "FM",
                table: "SubLedgerRequirement_Account");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "FM",
                table: "SubLedgerRequirement_Account");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "FM",
                table: "SubLedgerRequirement_Account");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                schema: "FM",
                table: "SubLedgerRequirement_Account");

            migrationBuilder.RenameTable(
                name: "SubLedgerRequirement_Account",
                schema: "FM",
                newName: "COA_SubLedgerRequirement_Account");

            migrationBuilder.RenameIndex(
                name: "IX_SubLedgerRequirement_Account_SubLedgerRequirementId",
                table: "COA_SubLedgerRequirement_Account",
                newName: "IX_COA_SubLedgerRequirement_Account_SubLedgerRequirementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_COA_SubLedgerRequirement_Account",
                table: "COA_SubLedgerRequirement_Account",
                columns: new[] { "AccountId", "SubLedgerRequirementId" });

            migrationBuilder.AddForeignKey(
                name: "FK_COA_SubLedgerRequirement_Account_COAs_AccountId",
                table: "COA_SubLedgerRequirement_Account",
                column: "AccountId",
                principalSchema: "FM",
                principalTable: "COAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COA_SubLedgerRequirement_Account_SubLedgerRequirements_SubLedgerRequirementId",
                table: "COA_SubLedgerRequirement_Account",
                column: "SubLedgerRequirementId",
                principalSchema: "FM",
                principalTable: "SubLedgerRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
