using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LRTemplateTypoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HaAttachmentRequirement",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates");

            migrationBuilder.AddColumn<bool>(
                name: "HasAttachmentRequirement",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAttachmentRequirement",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates");

            migrationBuilder.AddColumn<bool>(
                name: "HaAttachmentRequirement",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
