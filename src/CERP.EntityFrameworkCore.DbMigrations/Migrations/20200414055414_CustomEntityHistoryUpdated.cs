using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class CustomEntityHistoryUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomEntityChanges_AbpAuditLogs_AuditLogId",
                schema: "OxygenERP",
                table: "CustomEntityChanges");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "OxygenERP",
                table: "CustomEntityPropertyChanges",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "TenantId",
                schema: "OxygenERP",
                table: "CustomEntityChanges",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "EntityTenantId",
                schema: "OxygenERP",
                table: "CustomEntityChanges",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuditLogId",
                schema: "OxygenERP",
                table: "CustomEntityChanges",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "EntityId",
                schema: "OxygenERP",
                table: "CustomEntityChanges",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomEntityChanges_AbpAuditLogs_AuditLogId",
                schema: "OxygenERP",
                table: "CustomEntityChanges",
                column: "AuditLogId",
                principalTable: "AbpAuditLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomEntityChanges_AbpAuditLogs_AuditLogId",
                schema: "OxygenERP",
                table: "CustomEntityChanges");

            migrationBuilder.DropColumn(
                name: "EntityId",
                schema: "OxygenERP",
                table: "CustomEntityChanges");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "OxygenERP",
                table: "CustomEntityPropertyChanges",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "OxygenERP",
                table: "CustomEntityChanges",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EntityTenantId",
                schema: "OxygenERP",
                table: "CustomEntityChanges",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AuditLogId",
                schema: "OxygenERP",
                table: "CustomEntityChanges",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomEntityChanges_AbpAuditLogs_AuditLogId",
                schema: "OxygenERP",
                table: "CustomEntityChanges",
                column: "AuditLogId",
                principalTable: "AbpAuditLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
