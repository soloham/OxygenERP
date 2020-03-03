using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class COAEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat1Id",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat3Id",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat4Id",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropIndex(
                name: "IX_COAs_AccountSubCat3Id",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropIndex(
                name: "IX_COAs_AccountSubCat4Id",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropColumn(
                name: "AccountSubCat3Id",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropColumn(
                name: "AccountSubCat4Id",
                schema: "FM",
                table: "COAs");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountSubCat1Id",
                schema: "FM",
                table: "COAs",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountGroupCatId",
                schema: "FM",
                table: "COAs",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccountSubCatId",
                schema: "FM",
                table: "COAs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat1Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat1Id",
                principalSchema: "FM",
                principalTable: "COASubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat1Id",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropColumn(
                name: "AccountGroupCatId",
                schema: "FM",
                table: "COAs");

            migrationBuilder.DropColumn(
                name: "AccountSubCatId",
                schema: "FM",
                table: "COAs");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountSubCat1Id",
                schema: "FM",
                table: "COAs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccountSubCat3Id",
                schema: "FM",
                table: "COAs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccountSubCat4Id",
                schema: "FM",
                table: "COAs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_COAs_AccountSubCat3Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat3Id");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_AccountSubCat4Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat4Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat1Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat1Id",
                principalSchema: "FM",
                principalTable: "COASubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat3Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat3Id",
                principalSchema: "FM",
                principalTable: "COASubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat4Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat4Id",
                principalSchema: "FM",
                principalTable: "COASubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
