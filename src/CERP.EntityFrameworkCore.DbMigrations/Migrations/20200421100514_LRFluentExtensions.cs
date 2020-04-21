using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LRFluentExtensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateDepartments_Departments_DepartmentId",
                schema: "HR",
                table: "LeaveRequestTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateEmployeeStatuses_DictionaryValues_EmployeeStatusId",
                schema: "HR",
                table: "LeaveRequestTemplateEmployeeStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateEmploymentTypes_DictionaryValues_EmploymentTypeId",
                schema: "HR",
                table: "LeaveRequestTemplateEmploymentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateHolidays_Holidays_HolidayId",
                schema: "HR",
                table: "LeaveRequestTemplateHolidays");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplatePositions_Positions_PositionId",
                schema: "HR",
                table: "LeaveRequestTemplatePositions");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateDepartments_Departments_DepartmentId",
                schema: "HR",
                table: "LeaveRequestTemplateDepartments",
                column: "DepartmentId",
                principalSchema: "SETUP",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateEmployeeStatuses_DictionaryValues_EmployeeStatusId",
                schema: "HR",
                table: "LeaveRequestTemplateEmployeeStatuses",
                column: "EmployeeStatusId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateEmploymentTypes_DictionaryValues_EmploymentTypeId",
                schema: "HR",
                table: "LeaveRequestTemplateEmploymentTypes",
                column: "EmploymentTypeId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateHolidays_Holidays_HolidayId",
                schema: "HR",
                table: "LeaveRequestTemplateHolidays",
                column: "HolidayId",
                principalSchema: "HR",
                principalTable: "Holidays",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplatePositions_Positions_PositionId",
                schema: "HR",
                table: "LeaveRequestTemplatePositions",
                column: "PositionId",
                principalSchema: "SETUP",
                principalTable: "Positions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateDepartments_Departments_DepartmentId",
                schema: "HR",
                table: "LeaveRequestTemplateDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateEmployeeStatuses_DictionaryValues_EmployeeStatusId",
                schema: "HR",
                table: "LeaveRequestTemplateEmployeeStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateEmploymentTypes_DictionaryValues_EmploymentTypeId",
                schema: "HR",
                table: "LeaveRequestTemplateEmploymentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplateHolidays_Holidays_HolidayId",
                schema: "HR",
                table: "LeaveRequestTemplateHolidays");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequestTemplatePositions_Positions_PositionId",
                schema: "HR",
                table: "LeaveRequestTemplatePositions");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateDepartments_Departments_DepartmentId",
                schema: "HR",
                table: "LeaveRequestTemplateDepartments",
                column: "DepartmentId",
                principalSchema: "SETUP",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateEmployeeStatuses_DictionaryValues_EmployeeStatusId",
                schema: "HR",
                table: "LeaveRequestTemplateEmployeeStatuses",
                column: "EmployeeStatusId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateEmploymentTypes_DictionaryValues_EmploymentTypeId",
                schema: "HR",
                table: "LeaveRequestTemplateEmploymentTypes",
                column: "EmploymentTypeId",
                principalSchema: "OxygenERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplateHolidays_Holidays_HolidayId",
                schema: "HR",
                table: "LeaveRequestTemplateHolidays",
                column: "HolidayId",
                principalSchema: "HR",
                principalTable: "Holidays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequestTemplatePositions_Positions_PositionId",
                schema: "HR",
                table: "LeaveRequestTemplatePositions",
                column: "PositionId",
                principalSchema: "SETUP",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
