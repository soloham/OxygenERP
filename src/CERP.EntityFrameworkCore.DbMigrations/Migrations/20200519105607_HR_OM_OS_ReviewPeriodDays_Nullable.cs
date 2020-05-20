using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HR_OM_OS_ReviewPeriodDays_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "FunctionTemplates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "CompensationMatrixTemplates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "TaskTemplates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "SkillTemplates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "PositionTemplates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "JobTemplates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "FunctionTemplates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "DepartmentTemplates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "CompensationMatrixTemplates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewPeriodDays",
                schema: "HR.OrganizationalManagement.OrganizationStructure",
                table: "AcademiaTemplates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
