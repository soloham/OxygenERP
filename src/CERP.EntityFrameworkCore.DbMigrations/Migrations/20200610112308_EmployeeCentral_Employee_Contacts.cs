using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_Contacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneAddress",
                schema: "HR.Objects.Contacts",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "HR.Objects.Contacts",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "HR.Objects.Contacts",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "PhoneAddress",
                schema: "HR.Objects.Contacts",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
