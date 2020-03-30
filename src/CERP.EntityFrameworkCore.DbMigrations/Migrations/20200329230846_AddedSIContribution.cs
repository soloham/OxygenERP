using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class AddedSIContribution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SocialInsuranceId",
                schema: "HR",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SICategories",
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
                    Title = table.Column<string>(nullable: false),
                    IsExpense = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SICategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SIContributions",
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
                    SICategoryId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    IsPercentage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIContributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SIContributions_SICategories_SICategoryId",
                        column: x => x.SICategoryId,
                        principalSchema: "PR",
                        principalTable: "SICategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SIContributions_SICategoryId",
                schema: "PR",
                table: "SIContributions",
                column: "SICategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SIContributions",
                schema: "PR");

            migrationBuilder.DropTable(
                name: "SICategories",
                schema: "PR");

            migrationBuilder.DropColumn(
                name: "SocialInsuranceId",
                schema: "HR",
                table: "Employees");
        }
    }
}
