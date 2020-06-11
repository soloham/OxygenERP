using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LocationAddressCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocationCountryId",
                schema: "SETUP",
                table: "LocationTemplates",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.CreateIndex(
                name: "IX_LocationTemplates_LocationCountryId",
                schema: "SETUP",
                table: "LocationTemplates",
                column: "LocationCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationTemplates_DictionaryValues_LocationCountryId",
                schema: "SETUP",
                table: "LocationTemplates",
                column: "LocationCountryId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationTemplates_DictionaryValues_LocationCountryId",
                schema: "SETUP",
                table: "LocationTemplates");

            migrationBuilder.DropIndex(
                name: "IX_LocationTemplates_LocationCountryId",
                schema: "SETUP",
                table: "LocationTemplates");

            migrationBuilder.DropColumn(
                name: "LocationCountryId",
                schema: "SETUP",
                table: "LocationTemplates");
        }
    }
}
