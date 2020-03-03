using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class COAEntityUpdatedForiegnKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat1Id",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat2Id",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropIndex(
                name: "IX_COAs_AccountSubCat1Id",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropIndex(
                name: "IX_COAs_AccountSubCat2Id",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropColumn(
                name: "AccountSubCat1Id",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropColumn(
                name: "AccountSubCat2Id",
                schema: "FM",
                table: "COAs");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_AccountGroupCatId",
                schema: "FM",
                table: "COAs",
                column: "AccountGroupCatId");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_AccountSubCatId",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_COASubCategories_AccountGroupCatId",
                schema: "FM",
                table: "COAs",
                column: "AccountGroupCatId",
                principalSchema: "FM",
                principalTable: "COASubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCatId",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCatId",
                principalSchema: "FM",
                principalTable: "COASubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COAs_COASubCategories_AccountGroupCatId",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCatId",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropIndex(
                name: "IX_COAs_AccountGroupCatId",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropIndex(
                name: "IX_COAs_AccountSubCatId",
                schema: "FM",
                table: "COAs");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountSubCat1Id",
                schema: "FM",
                table: "COAs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccountSubCat2Id",
                schema: "FM",
                table: "COAs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_COAs_AccountSubCat1Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat1Id");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_AccountSubCat2Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat1Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat1Id",
                principalSchema: "FM",
                principalTable: "COASubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat2Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat2Id",
                principalSchema: "FM",
                principalTable: "COASubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
