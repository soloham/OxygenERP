using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HolidayAndSchemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "LeaveRequestTemplates",
                schema: "OxygenERP",
                newName: "LeaveRequestTemplates",
                newSchema: "HR");

            migrationBuilder.RenameTable(
                name: "LeaveRequestTemplatePositions",
                schema: "OxygenERP",
                newName: "LeaveRequestTemplatePositions",
                newSchema: "HR");

            migrationBuilder.RenameTable(
                name: "LeaveRequestTemplateEmploymentTypes",
                schema: "OxygenERP",
                newName: "LeaveRequestTemplateEmploymentTypes",
                newSchema: "HR");

            migrationBuilder.RenameTable(
                name: "LeaveRequestTemplateEmployeeStatuses",
                schema: "OxygenERP",
                newName: "LeaveRequestTemplateEmployeeStatuses",
                newSchema: "HR");

            migrationBuilder.RenameTable(
                name: "LeaveRequestTemplateDepartments",
                schema: "OxygenERP",
                newName: "LeaveRequestTemplateDepartments",
                newSchema: "HR");

            migrationBuilder.CreateTable(
                name: "Holidays",
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
                    TenantId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    TitleLocalized = table.Column<string>(nullable: true),
                    HolidayTypeId = table.Column<Guid>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    ReligiousDenominationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holidays_DictionaryValues_HolidayTypeId",
                        column: x => x.HolidayTypeId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holidays_DictionaryValues_ReligiousDenominationId",
                        column: x => x.ReligiousDenominationId,
                        principalSchema: "OxygenERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_HolidayTypeId",
                schema: "HR",
                table: "Holidays",
                column: "HolidayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_ReligiousDenominationId",
                schema: "HR",
                table: "Holidays",
                column: "ReligiousDenominationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays",
                schema: "HR");

            migrationBuilder.RenameTable(
                name: "LeaveRequestTemplates",
                schema: "HR",
                newName: "LeaveRequestTemplates",
                newSchema: "OxygenERP");

            migrationBuilder.RenameTable(
                name: "LeaveRequestTemplatePositions",
                schema: "HR",
                newName: "LeaveRequestTemplatePositions",
                newSchema: "OxygenERP");

            migrationBuilder.RenameTable(
                name: "LeaveRequestTemplateEmploymentTypes",
                schema: "HR",
                newName: "LeaveRequestTemplateEmploymentTypes",
                newSchema: "OxygenERP");

            migrationBuilder.RenameTable(
                name: "LeaveRequestTemplateEmployeeStatuses",
                schema: "HR",
                newName: "LeaveRequestTemplateEmployeeStatuses",
                newSchema: "OxygenERP");

            migrationBuilder.RenameTable(
                name: "LeaveRequestTemplateDepartments",
                schema: "HR",
                newName: "LeaveRequestTemplateDepartments",
                newSchema: "OxygenERP");
        }
    }
}
