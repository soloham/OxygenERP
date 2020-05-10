using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class DocumentOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Employees_OwnerId",
                schema: "HR",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_OwnerId",
                schema: "HR",
                table: "Documents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Documents_OwnerId",
                schema: "HR",
                table: "Documents",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Employees_OwnerId",
                schema: "HR",
                table: "Documents",
                column: "OwnerId",
                principalSchema: "HR",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
