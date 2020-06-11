using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_Employee_Dependant_Ids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentAttachment",
                schema: "HR.Objects.Identities",
                table: "PassportTravelDocuments");

            migrationBuilder.DropColumn(
                name: "IDAttachment",
                schema: "HR.Objects.Identities",
                table: "NationalIdentities");

            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                schema: "HR.Objects.Identities",
                table: "PassportTravelDocuments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                schema: "HR.Objects.Identities",
                table: "NationalIdentities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachment",
                schema: "HR.Objects.Identities",
                table: "PassportTravelDocuments");

            migrationBuilder.DropColumn(
                name: "Attachment",
                schema: "HR.Objects.Identities",
                table: "NationalIdentities");

            migrationBuilder.AddColumn<string>(
                name: "DocumentAttachment",
                schema: "HR.Objects.Identities",
                table: "PassportTravelDocuments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDAttachment",
                schema: "HR.Objects.Identities",
                table: "NationalIdentities",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
