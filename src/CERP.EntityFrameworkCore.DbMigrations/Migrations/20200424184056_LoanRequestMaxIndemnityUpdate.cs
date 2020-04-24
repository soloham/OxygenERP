using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LoanRequestMaxIndemnityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MaxIndemnityLimit",
                schema: "HR",
                table: "LoanRequestTemplates",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MaxIndemnityLimit",
                schema: "HR",
                table: "LoanRequestTemplates",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
