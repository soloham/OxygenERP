using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class CustomEntityHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomEntityChanges",
                schema: "AvalonERP",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuditLogId = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    ChanegeTime = table.Column<DateTime>(nullable: false),
                    ChangeType = table.Column<byte>(nullable: false),
                    EntityTenantId = table.Column<Guid>(nullable: false),
                    EntityTypeFullName = table.Column<string>(nullable: true),
                    ExtraProperties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomEntityChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomEntityChanges_AbpAuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalTable: "AbpAuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomEntityPropertyChanges",
                schema: "AvalonERP",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    EntityChangeId = table.Column<Guid>(nullable: false),
                    PropertyTypeFullName = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true),
                    OriginalValue = table.Column<string>(nullable: true),
                    PropertyName = table.Column<string>(nullable: true),
                    ExtraProperties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomEntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomEntityPropertyChanges_CustomEntityChanges_EntityChangeId",
                        column: x => x.EntityChangeId,
                        principalSchema: "AvalonERP",
                        principalTable: "CustomEntityChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomEntityChanges_AuditLogId",
                schema: "AvalonERP",
                table: "CustomEntityChanges",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomEntityPropertyChanges_EntityChangeId",
                schema: "AvalonERP",
                table: "CustomEntityPropertyChanges",
                column: "EntityChangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomEntityPropertyChanges",
                schema: "AvalonERP");

            migrationBuilder.DropTable(
                name: "CustomEntityChanges",
                schema: "AvalonERP");
        }
    }
}
