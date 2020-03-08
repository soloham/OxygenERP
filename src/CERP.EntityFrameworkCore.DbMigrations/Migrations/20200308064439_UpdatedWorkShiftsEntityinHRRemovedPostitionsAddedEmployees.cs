using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedWorkShiftsEntityinHRRemovedPostitionsAddedEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_WorkShifts_WorkShiftId",
                schema: "SETUP",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_WorkShiftId",
                schema: "SETUP",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "WorkShiftId",
                schema: "SETUP",
                table: "Positions");

            migrationBuilder.AddColumn<int>(
                name: "WorkShiftId",
                schema: "HR",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorkShiftId",
                schema: "HR",
                table: "Employees",
                column: "WorkShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId",
                schema: "HR",
                table: "Employees",
                column: "WorkShiftId",
                principalSchema: "HR",
                principalTable: "WorkShifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_WorkShiftId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkShiftId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "WorkShiftId",
                schema: "SETUP",
                table: "Positions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_WorkShiftId",
                schema: "SETUP",
                table: "Positions",
                column: "WorkShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_WorkShifts_WorkShiftId",
                schema: "SETUP",
                table: "Positions",
                column: "WorkShiftId",
                principalSchema: "HR",
                principalTable: "WorkShifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
