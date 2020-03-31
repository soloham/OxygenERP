using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class SI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SetupId",
                schema: "PR",
                table: "SICategories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SISetup",
                schema: "PR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    SI_UpperLimit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISetup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SICategories_SetupId",
                schema: "PR",
                table: "SICategories",
                column: "SetupId");

            migrationBuilder.AddForeignKey(
                name: "FK_SICategories_SISetup_SetupId",
                schema: "PR",
                table: "SICategories",
                column: "SetupId",
                principalSchema: "PR",
                principalTable: "SISetup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SICategories_SISetup_SetupId",
                schema: "PR",
                table: "SICategories");

            migrationBuilder.DropTable(
                name: "SISetup",
                schema: "PR");

            migrationBuilder.DropIndex(
                name: "IX_SICategories_SetupId",
                schema: "PR",
                table: "SICategories");

            migrationBuilder.DropColumn(
                name: "SetupId",
                schema: "PR",
                table: "SICategories");
        }
    }
}
