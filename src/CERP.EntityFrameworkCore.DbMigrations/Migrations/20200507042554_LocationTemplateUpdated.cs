using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LocationTemplateUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationTemplates_Companies_CompanyId",
                schema: "SETUP",
                table: "LocationTemplates");

            migrationBuilder.DropIndex(
                name: "IX_LocationTemplates_CompanyId",
                schema: "SETUP",
                table: "LocationTemplates");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "SETUP",
                table: "LocationTemplates");

            migrationBuilder.AddColumn<string>(
                name: "LocationAbbreviation",
                schema: "SETUP",
                table: "LocationTemplates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationAbbreviation",
                schema: "SETUP",
                table: "LocationTemplates");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                schema: "SETUP",
                table: "LocationTemplates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationTemplates_CompanyId",
                schema: "SETUP",
                table: "LocationTemplates",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationTemplates_Companies_CompanyId",
                schema: "SETUP",
                table: "LocationTemplates",
                column: "CompanyId",
                principalSchema: "OxygenERP",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
