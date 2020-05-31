using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class PayrollStrucutre_Update_PS_OM_HR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EffectiveDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EffectiveDate",
                schema: "HR.OrganizationalManagement.PayrollStructure",
                table: "PayComponents");
        }
    }
}
