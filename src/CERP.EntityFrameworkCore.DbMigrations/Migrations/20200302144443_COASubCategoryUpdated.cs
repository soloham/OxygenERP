using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class COASubCategoryUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupCategoryId",
                schema: "FM",
                table: "COASubCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentCategoryId",
                schema: "FM",
                table: "COASubCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_COASubCategories_ParentCategoryId",
                schema: "FM",
                table: "COASubCategories",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_COASubCategories_COASubCategories_ParentCategoryId",
                schema: "FM",
                table: "COASubCategories",
                column: "ParentCategoryId",
                principalSchema: "FM",
                principalTable: "COASubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COASubCategories_COASubCategories_ParentCategoryId",
                schema: "FM",
                table: "COASubCategories");

            migrationBuilder.DropIndex(
                name: "IX_COASubCategories_ParentCategoryId",
                schema: "FM",
                table: "COASubCategories");

            migrationBuilder.DropColumn(
                name: "GroupCategoryId",
                schema: "FM",
                table: "COASubCategories");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                schema: "FM",
                table: "COASubCategories");
        }
    }
}
