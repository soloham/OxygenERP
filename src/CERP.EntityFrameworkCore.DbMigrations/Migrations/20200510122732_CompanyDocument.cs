using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class CompanyDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyDocuments",
                schema: "SETUP",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    DocumentTitle = table.Column<string>(nullable: true),
                    DocumentTitleLocalized = table.Column<string>(nullable: true),
                    SoftCopy = table.Column<string>(nullable: true),
                    IssueDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    DocumentTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDocuments", x => new { x.CompanyId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_CompanyDocuments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "SETUP",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "HR",
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyDocuments_DictionaryValues_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDocuments_DocumentId",
                schema: "SETUP",
                table: "CompanyDocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDocuments_DocumentTypeId",
                schema: "SETUP",
                table: "CompanyDocuments",
                column: "DocumentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyDocuments",
                schema: "SETUP");
        }
    }
}
