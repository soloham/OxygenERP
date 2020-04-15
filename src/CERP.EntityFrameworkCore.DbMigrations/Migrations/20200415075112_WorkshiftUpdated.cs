using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class WorkshiftUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFRI",
                schema: "HR",
                table: "WorkShifts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isMON",
                schema: "HR",
                table: "WorkShifts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isSAT",
                schema: "HR",
                table: "WorkShifts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isSUN",
                schema: "HR",
                table: "WorkShifts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isTHU",
                schema: "HR",
                table: "WorkShifts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isTUE",
                schema: "HR",
                table: "WorkShifts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isWED",
                schema: "HR",
                table: "WorkShifts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFRI",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "isMON",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "isSAT",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "isSUN",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "isTHU",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "isTUE",
                schema: "HR",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "isWED",
                schema: "HR",
                table: "WorkShifts");
        }
    }
}
