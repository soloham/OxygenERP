using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class PostPropertiesForReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIndemnityPosted",
                schema: "PR",
                table: "Payruns",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPSPosted",
                schema: "PR",
                table: "Payruns",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSIPosted",
                schema: "PR",
                table: "Payruns",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIndemnityPosted",
                schema: "PR",
                table: "Payruns");

            migrationBuilder.DropColumn(
                name: "IsPSPosted",
                schema: "PR",
                table: "Payruns");

            migrationBuilder.DropColumn(
                name: "IsSIPosted",
                schema: "PR",
                table: "Payruns");
        }
    }
}
