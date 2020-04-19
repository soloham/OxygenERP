using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class LRApprovalRouteTemplateID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ApprovalRouteTemplateId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ApprovalRouteTemplateId",
                schema: "OxygenERP",
                table: "LeaveRequestTemplates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
