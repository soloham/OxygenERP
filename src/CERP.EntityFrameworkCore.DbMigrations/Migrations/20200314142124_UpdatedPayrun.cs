using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class UpdatedPayrun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.EnsureSchema(
                name: "PR");

            migrationBuilder.CreateTable(
                name: "Payruns",
                schema: "PR",
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
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    TotalEarnings = table.Column<decimal>(nullable: false),
                    TotalDeductions = table.Column<decimal>(nullable: false),
                    NetTotal = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    IsPosted = table.Column<bool>(nullable: false),
                    PostedDate = table.Column<DateTime>(nullable: true),
                    PostedById = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payruns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payruns_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "CERP",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payruns_Employees_PostedById",
                        column: x => x.PostedById,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrunsDetails",
                schema: "PR",
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
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PayrunId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    BasicSalary = table.Column<decimal>(nullable: false),
                    GOSIAmount = table.Column<decimal>(nullable: false),
                    Loan = table.Column<decimal>(nullable: false),
                    Leaves = table.Column<decimal>(nullable: false),
                    Disciplinary = table.Column<decimal>(nullable: false),
                    GrossEarnings = table.Column<decimal>(nullable: false),
                    GrossDeductions = table.Column<decimal>(nullable: false),
                    NetAmount = table.Column<decimal>(nullable: false),
                    AmountPaid = table.Column<decimal>(nullable: false),
                    DifferAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrunsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrunsDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayrunsDetails_Payruns_PayrunId",
                        column: x => x.PayrunId,
                        principalSchema: "PR",
                        principalTable: "Payruns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrunsPayslips",
                schema: "PR",
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
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PayrunId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    Earning = table.Column<decimal>(nullable: false),
                    Deduction = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Remarks = table.Column<string>(nullable: false),
                    IsPosted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrunsPayslips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrunsPayslips_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayrunsPayslips_Payruns_PayrunId",
                        column: x => x.PayrunId,
                        principalSchema: "PR",
                        principalTable: "Payruns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrunsAllowancesSummaries",
                schema: "PR",
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
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    AllowanceTypeId = table.Column<Guid>(nullable: false),
                    PayrunDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrunsAllowancesSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrunsAllowancesSummaries_DictionaryValues_AllowanceTypeId",
                        column: x => x.AllowanceTypeId,
                        principalSchema: "CERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayrunsAllowancesSummaries_PayrunsDetails_PayrunDetailId",
                        column: x => x.PayrunDetailId,
                        principalSchema: "PR",
                        principalTable: "PayrunsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payruns_CompanyId",
                schema: "PR",
                table: "Payruns",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payruns_PostedById",
                schema: "PR",
                table: "Payruns",
                column: "PostedById");

            migrationBuilder.CreateIndex(
                name: "IX_PayrunsAllowancesSummaries_AllowanceTypeId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries",
                column: "AllowanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrunsAllowancesSummaries_PayrunDetailId",
                schema: "PR",
                table: "PayrunsAllowancesSummaries",
                column: "PayrunDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrunsDetails_EmployeeId",
                schema: "PR",
                table: "PayrunsDetails",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrunsDetails_PayrunId",
                schema: "PR",
                table: "PayrunsDetails",
                column: "PayrunId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrunsPayslips_EmployeeId",
                schema: "PR",
                table: "PayrunsPayslips",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrunsPayslips_PayrunId",
                schema: "PR",
                table: "PayrunsPayslips",
                column: "PayrunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeTypeId",
                schema: "HR",
                table: "Employees",
                column: "EmployeeTypeId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeTypeId",
                schema: "HR",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "PayrunsAllowancesSummaries",
                schema: "PR");

            migrationBuilder.DropTable(
                name: "PayrunsPayslips",
                schema: "PR");

            migrationBuilder.DropTable(
                name: "PayrunsDetails",
                schema: "PR");

            migrationBuilder.DropTable(
                name: "Payruns",
                schema: "PR");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DictionaryValues_EmployeeTypeId",
                schema: "HR",
                table: "Employees",
                column: "EmployeeTypeId",
                principalSchema: "CERP",
                principalTable: "DictionaryValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
