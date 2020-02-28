using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedCOAEntitesCOASubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "FM",
                table: "COASubCategories",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "FM",
                table: "COASubCategories",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
