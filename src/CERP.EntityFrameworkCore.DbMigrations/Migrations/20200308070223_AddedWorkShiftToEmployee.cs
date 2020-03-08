using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class AddedWorkShiftToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "WorkShiftId",
                schema: "HR",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkShiftId1",
                schema: "HR",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkShiftId2",
                schema: "HR",
                table: "Employees",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "WorkShiftId",
                schema: "HR",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
