using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedEmployeeRemovedPhysicalIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpPhysicalIDs",
                schema: "HR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpPhysicalIDs",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDCopy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuedFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sponsor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpPhysicalIDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpPhysicalIDs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpPhysicalIDs_DictionaryValues_IDTypeId",
                        column: x => x.IDTypeId,
                        principalSchema: "CERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpPhysicalIDs_DictionaryValues_IssuedFromId",
                        column: x => x.IssuedFromId,
                        principalSchema: "CERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpPhysicalIDs_EmployeeId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPhysicalIDs_IDTypeId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                column: "IDTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPhysicalIDs_IssuedFromId",
                schema: "HR",
                table: "EmpPhysicalIDs",
                column: "IssuedFromId");
        }
    }
}
