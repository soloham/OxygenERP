using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class SICatSetupIdRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SetupId",
                schema: "PR",
                table: "SICategories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SetupId",
                schema: "PR",
                table: "SICategories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
