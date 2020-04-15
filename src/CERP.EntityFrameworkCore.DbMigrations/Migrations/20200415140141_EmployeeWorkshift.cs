using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeWorkshift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId1",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_WorkShiftId1",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkShiftId1",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkShiftId2",
                schema: "HR",
                table: "Employees");

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

            migrationBuilder.AddColumn<int>(
                name: "WorkShiftId1",
                schema: "HR",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkShiftId2",
                schema: "HR",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorkShiftId1",
                schema: "HR",
                table: "Employees",
                column: "WorkShiftId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId",
                schema: "HR",
                table: "Employees",
                column: "WorkShiftId",
                principalSchema: "HR",
                principalTable: "WorkShifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId1",
                schema: "HR",
                table: "Employees",
                column: "WorkShiftId1",
                principalSchema: "HR",
                principalTable: "WorkShifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
