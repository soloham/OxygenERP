using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class RemovedIsPassportProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPassport",
                schema: "HR",
                table: "EmpPhysicalIDs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPassport",
                schema: "HR",
                table: "EmpPhysicalIDs",
                type: "bit",
                nullable: true);
        }
    }
}
