using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_Department_Positions_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropColumn(
                name: "TitleLocalized",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameLocalized",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.DropColumn(
                name: "NameLocalized",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleLocalized",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
