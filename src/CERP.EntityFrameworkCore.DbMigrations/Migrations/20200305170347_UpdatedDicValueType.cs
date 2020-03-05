using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedDicValueType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DictionaryValues_DictionaryValueTypes_DictionaryValueTypeId",
                schema: "CERP",
                table: "DictionaryValues");

            //migrationBuilder.DropIndex(
            //    name: "IX_DictionaryValues_DictionaryValueTypeId",
            //    schema: "CERP",
            //    table: "DictionaryValues");

            migrationBuilder.DropColumn(
                name: "DictionaryValueTypeId",
                schema: "CERP",
                table: "DictionaryValues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DictionaryValueTypeId",
                schema: "CERP",
                table: "DictionaryValues",
                type: "uniqueidentifier",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_DictionaryValues_DictionaryValueTypeId",
            //    schema: "CERP",
            //    table: "DictionaryValues",
            //    column: "DictionaryValueTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DictionaryValues_DictionaryValueTypes_DictionaryValueTypeId",
                schema: "CERP",
                table: "DictionaryValues",
                column: "DictionaryValueTypeId",
                principalSchema: "CERP",
                principalTable: "DictionaryValueTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
