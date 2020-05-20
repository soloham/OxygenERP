using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class GR_OM_OS_Structures_Basic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationStructureTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameLocalized = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ValidityFromDate = table.Column<DateTime>(nullable: false),
                    ValidityToDate = table.Column<DateTime>(nullable: false),
                    StructureStatus = table.Column<int>(nullable: false),
                    ReviewPeriod = table.Column<int>(nullable: false),
                    ReviewPeriodDays = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStructureTemplates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationStructureTemplates",
                schema: "HR.OrganizationalManagement.OrganizationStructure");
        }
    }
}
