using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class PayrollStrucutre_PayComponentType_Relationship_Update_AllowNumm_PS_OM_HR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ValueComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ValueComponentTypeId",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponentTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
