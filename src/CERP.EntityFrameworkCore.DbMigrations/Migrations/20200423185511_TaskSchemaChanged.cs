using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class TaskSchemaChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TaskTemplateItemEmployees",
                schema: "HR",
                newName: "TaskTemplateItemEmployees",
                newSchema: "OxygenERP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TaskTemplateItemEmployees",
                schema: "OxygenERP",
                newName: "TaskTemplateItemEmployees",
                newSchema: "HR");
        }
    }
}
