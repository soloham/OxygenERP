using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedDocumentEntityAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IssuedFromId",
                schema: "HR",
                table: "Documents",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Documents_IssuedFromId",
                schema: "HR",
                table: "Documents",
                column: "IssuedFromId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DictionaryValues_IssuedFromId",
                schema: "HR",
                table: "Documents",
                column: "IssuedFromId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DictionaryValues_IssuedFromId",
                schema: "HR",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_IssuedFromId",
                schema: "HR",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "IssuedFromId",
                schema: "HR",
                table: "Documents");
        }
    }
}
