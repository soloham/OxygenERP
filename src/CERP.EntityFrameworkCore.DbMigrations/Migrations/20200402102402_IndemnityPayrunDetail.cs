using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class IndemnityPayrunDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndemnityId",
                schema: "PR",
                table: "PayrunsDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PayrunDetailIndemnityId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PayrunDetailIndemnities",
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
                    EmployeeId = table.Column<Guid>(nullable: true),
                    BasicSalary = table.Column<double>(nullable: false),
                    GrossSalary = table.Column<double>(nullable: false),
                    TotalEmploymentDays = table.Column<int>(nullable: false),
                    TotalEOSB = table.Column<double>(nullable: false),
                    ActuarialEvaluation = table.Column<double>(nullable: false),
                    LastMonthEOSB = table.Column<double>(nullable: false),
                    Difference = table.Column<double>(nullable: false),
                    PayrunDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrunDetailIndemnities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrunDetailIndemnities_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayrunsDetails_IndemnityId",
                schema: "PR",
                table: "PayrunsDetails",
                column: "IndemnityId",
                unique: true,
                filter: "[IndemnityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PayrunsAllowancesSummaries_PayrunDetailIndemnityId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries",
                column: "PayrunDetailIndemnityId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrunDetailIndemnities_EmployeeId",
                schema: "PR",
                table: "PayrunDetailIndemnities",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrunsAllowancesSummaries_PayrunDetailIndemnities_PayrunDetailIndemnityId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries",
                column: "PayrunDetailIndemnityId",
                principalSchema: "PR",
                principalTable: "PayrunDetailIndemnities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PayrunsDetails_PayrunDetailIndemnities_IndemnityId",
                schema: "PR",
                table: "PayrunsDetails",
                column: "IndemnityId",
                principalSchema: "PR",
                principalTable: "PayrunDetailIndemnities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrunsAllowancesSummaries_PayrunDetailIndemnities_PayrunDetailIndemnityId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_PayrunsDetails_PayrunDetailIndemnities_IndemnityId",
                schema: "PR",
                table: "PayrunsDetails");

            migrationBuilder.DropTable(
                name: "PayrunDetailIndemnities",
                schema: "PR");

            migrationBuilder.DropIndex(
                name: "IX_PayrunsDetails_IndemnityId",
                schema: "PR",
                table: "PayrunsDetails");

            migrationBuilder.DropIndex(
                name: "IX_PayrunsAllowancesSummaries_PayrunDetailIndemnityId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries");

            migrationBuilder.DropColumn(
                name: "IndemnityId",
                schema: "PR",
                table: "PayrunsDetails");

            migrationBuilder.DropColumn(
                name: "PayrunDetailIndemnityId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries");
        }
    }
}
