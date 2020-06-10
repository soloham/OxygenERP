using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class EmployeeCentral_PaymentTypes_CashPaymentTypes_LocationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashPaymentTypes",
                schema: "HR.Objects.PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    CollectionLocationId = table.Column<Guid>(nullable: false),
                    ValidityFromDate = table.Column<string>(nullable: true),
                    ValidityToDate = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashPaymentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashPaymentTypes_LocationTemplates_CollectionLocationId",
                        column: x => x.CollectionLocationId,
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
                name: "IX_CashPaymentTypes_CollectionLocationId",
                schema: "HR.Objects.PaymentTypes",
                table: "CashPaymentTypes",
                column: "CollectionLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentTypes_EmployeeId",
                schema: "HR.Objects.PaymentTypes",
                table: "CashPaymentTypes",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashPaymentTypes",
                schema: "HR.Objects.PaymentTypes");
        }
    }
}
