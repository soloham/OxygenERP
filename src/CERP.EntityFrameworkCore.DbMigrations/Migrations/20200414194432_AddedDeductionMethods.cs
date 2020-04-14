using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class AddedDeductionMethods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeductionMethodId",
                schema: "HR",
                table: "WorkShifts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeductionMethods",
                schema: "HR",
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
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    HoursMultiplicationFactor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeductionMethods", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_DeductionMethodId",
                schema: "HR",
                table: "WorkShifts",
                column: "DeductionMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShifts_DeductionMethods_DeductionMethodId",
                schema: "HR",
                table: "WorkShifts",
                column: "DeductionMethodId",
                principalSchema: "HR",
                principalTable: "DeductionMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkShifts_DeductionMethods_DeductionMethodId",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.DropTable(
                name: "DeductionMethods",
                schema: "HR");

            migrationBuilder.DropIndex(
                name: "IX_WorkShifts_DeductionMethodId",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "DeductionMethodId",
                schema: "HR",
                table: "WorkShifts");
        }
    }
}
