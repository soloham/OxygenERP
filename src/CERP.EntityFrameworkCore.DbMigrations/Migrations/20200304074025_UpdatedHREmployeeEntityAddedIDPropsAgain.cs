using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedHREmployeeEntityAddedIDPropsAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDType",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.DropColumn(
                name: "IssuedFrom",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.AddColumn<Guid>(
                name: "IDTypeId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.AddColumn<Guid>(
                name: "IssuedFromId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                nullable: false,
                defaultValue: new Guid("ae4673e5-1442-30f0-0eb7-39f5b1547b17"));

            migrationBuilder.CreateIndex(
                name: "IX_EmpPhysicalIDs_IDTypeId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                column: "IDTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPhysicalIDs_IssuedFromId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                column: "IssuedFromId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpPhysicalIDs_DictionaryValues_IDTypeId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                column: "IDTypeId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpPhysicalIDs_DictionaryValues_IssuedFromId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                column: "IssuedFromId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpPhysicalIDs_DictionaryValues_IDTypeId",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpPhysicalIDs_DictionaryValues_IssuedFromId",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.DropIndex(
                name: "IX_EmpPhysicalIDs_IDTypeId",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.DropIndex(
                name: "IX_EmpPhysicalIDs_IssuedFromId",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.DropColumn(
                name: "IDTypeId",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.DropColumn(
                name: "IssuedFromId",
                schema: "HR",
                table: "EmpPhysicalIDs");

            migrationBuilder.AddColumn<int>(
                name: "IDType",
                schema: "HR",
                table: "EmpPhysicalIDs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IssuedFrom",
                schema: "HR",
                table: "EmpPhysicalIDs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
