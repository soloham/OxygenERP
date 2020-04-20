using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HolidayInLR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequestTemplateHolidays",
                schema: "HR",
                columns: table => new
                {
                    LeaveRequestTemplateId = table.Column<int>(nullable: false),
                    HolidayId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequestTemplateHolidays", x => new { x.LeaveRequestTemplateId, x.HolidayId });
                    table.ForeignKey(
                        name: "FK_LeaveRequestTemplateHolidays_Holidays_HolidayId",
                        column: x => x.HolidayId,
                        principalSchema: "HR",
                        principalTable: "Holidays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveRequestTemplateHolidays_LeaveRequestTemplates_LeaveRequestTemplateId",
                        column: x => x.LeaveRequestTemplateId,
                        principalSchema: "HR",
                        principalTable: "LeaveRequestTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestTemplateHolidays_HolidayId",
                schema: "HR",
                table: "LeaveRequestTemplateHolidays",
                column: "HolidayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequestTemplateHolidays",
                schema: "HR");
        }
    }
}
