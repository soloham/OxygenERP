using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class Validity_BusinessUnitDivision_OS_OM_HR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DivisionTemplates",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DivisionTemplates",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "BusinessUnitTemplates",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "BusinessUnitTemplates",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DivisionTemplates",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DivisionTemplates",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ValidityToDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "BusinessUnitTemplates",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ValidityFromDate",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "BusinessUnitTemplates",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
