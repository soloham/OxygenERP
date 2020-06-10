using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_PaymentTypes_CashPaymentTypes_Remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashPaymentTypes",
                schema: "HR.Objects.PaymentTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashPaymentTypes",
                schema: "HR.Objects.PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionLocationId = table.Column<int>(type: "int", nullable: false),
                    CollectionLocationId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ValidityFromDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidityToDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashPaymentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashPaymentTypes_LocationTemplates_CollectionLocationId1",
                        column: x => x.CollectionLocationId1,
                        principalSchema: "SETUP",
                        principalTable: "LocationTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CashPaymentTypes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR.EmployeeCentral",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentTypes_CollectionLocationId1",
                schema: "HR.Objects.PaymentTypes",
                table: "CashPaymentTypes",
                column: "CollectionLocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentTypes_EmployeeId",
                schema: "HR.Objects.PaymentTypes",
                table: "CashPaymentTypes",
                column: "EmployeeId");
        }
    }
}
