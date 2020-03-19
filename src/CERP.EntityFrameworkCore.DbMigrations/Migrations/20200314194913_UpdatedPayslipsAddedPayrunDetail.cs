using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedPayslipsAddedPayrunDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PayrunId",
                schema: "PR",
                table: "PayrunsPayslips",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PayrunDetailId",
                schema: "PR",
                table: "PayrunsPayslips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PayrunsPayslips_PayrunDetailId",
                schema: "PR",
                table: "PayrunsPayslips",
                column: "PayrunDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrunsPayslips_PayrunsDetails_PayrunDetailId",
                schema: "PR",
                table: "PayrunsPayslips",
                column: "PayrunDetailId",
                principalSchema: "PR",
                principalTable: "PayrunsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrunsPayslips_PayrunsDetails_PayrunDetailId",
                schema: "PR",
                table: "PayrunsPayslips");

            migrationBuilder.DropIndex(
                name: "IX_PayrunsPayslips_PayrunDetailId",
                schema: "PR",
                table: "PayrunsPayslips");

            migrationBuilder.DropColumn(
                name: "PayrunDetailId",
                schema: "PR",
                table: "PayrunsPayslips");

            migrationBuilder.AlterColumn<int>(
                name: "PayrunId",
                schema: "PR",
                table: "PayrunsPayslips",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
