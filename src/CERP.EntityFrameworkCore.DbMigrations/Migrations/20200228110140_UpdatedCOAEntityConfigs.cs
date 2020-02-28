using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedCOAEntityConfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat2Id",
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

            migrationBuilder.DropForeignKey(
                name: "FK_COAs_Branches_BranchId",
                schema: "FM",
                table: "COAs");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                schema: "FM",
                table: "COAs",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountSubCat4Id",
                schema: "FM",
                table: "COAs",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountSubCat3Id",
                schema: "FM",
                table: "COAs",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountSubCat2Id",
                schema: "FM",
                table: "COAs",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat2Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat2Id",
                principalSchema: "FM",
                principalTable: "COASubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_Branches_BranchId",
                schema: "FM",
                table: "COAs",
                column: "BranchId",
                principalSchema: "CERP",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat2Id",
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

            migrationBuilder.DropForeignKey(
                name: "FK_COAs_Branches_BranchId",
                schema: "FM",
                table: "COAs");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                schema: "FM",
                table: "COAs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountSubCat4Id",
                schema: "FM",
                table: "COAs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountSubCat3Id",
                schema: "FM",
                table: "COAs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountSubCat2Id",
                schema: "FM",
                table: "COAs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat2Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat2Id",
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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_COASubCategories_AccountSubCat4Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat4Id",
                principalSchema: "FM",
                principalTable: "COASubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COAs_Branches_BranchId",
                schema: "FM",
                table: "COAs",
                column: "BranchId",
                principalSchema: "CERP",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
