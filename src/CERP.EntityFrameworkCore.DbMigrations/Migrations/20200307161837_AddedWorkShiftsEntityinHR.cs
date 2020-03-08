using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class AddedWorkShiftsEntityinHR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkShiftId",
                schema: "SETUP",
                table: "Positions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkShifts",
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
                    Title = table.Column<string>(nullable: false),
                    StartHour = table.Column<int>(nullable: false),
                    EndHour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShifts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_WorkShiftId",
                schema: "SETUP",
                table: "Positions",
                column: "WorkShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_WorkShifts_WorkShiftId",
                schema: "SETUP",
                table: "Positions",
                column: "WorkShiftId",
                principalSchema: "HR",
                principalTable: "WorkShifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_WorkShifts_WorkShiftId",
                schema: "SETUP",
                table: "Positions");

            migrationBuilder.DropTable(
                name: "WorkShifts",
                schema: "HR");

            migrationBuilder.DropIndex(
                name: "IX_Positions_WorkShiftId",
                schema: "SETUP",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "WorkShiftId",
                schema: "SETUP",
                table: "Positions");
        }
    }
}
