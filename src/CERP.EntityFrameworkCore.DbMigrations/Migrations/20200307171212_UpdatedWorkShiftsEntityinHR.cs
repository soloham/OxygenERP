using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedWorkShiftsEntityinHR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                schema: "HR",
                table: "WorkShifts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndHDate",
                schema: "HR",
                table: "WorkShifts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartDate",
                schema: "HR",
                table: "WorkShifts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartHDate",
                schema: "HR",
                table: "WorkShifts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "EndHDate",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "StartDate",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "StartHDate",
                schema: "HR",
                table: "WorkShifts");
        }
    }
}
