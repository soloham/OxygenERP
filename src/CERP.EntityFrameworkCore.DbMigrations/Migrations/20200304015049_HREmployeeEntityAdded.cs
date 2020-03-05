using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class HREmployeeEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HR");

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<int>(nullable: false),
                    FirstNameLocalized = table.Column<int>(nullable: false),
                    MiddleName = table.Column<int>(nullable: false),
                    MiddleNameLocalized = table.Column<int>(nullable: false),
                    LastName = table.Column<int>(nullable: false),
                    LastNameLocalized = table.Column<int>(nullable: false),
                    FamilyName = table.Column<int>(nullable: false),
                    FamilyNameLocalized = table.Column<int>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    DOB_H = table.Column<DateTime>(nullable: false),
                    POB_ID = table.Column<Guid>(nullable: false),
                    NationalityId = table.Column<Guid>(nullable: false),
                    GenderId = table.Column<Guid>(nullable: false),
                    MaritalStatusId = table.Column<Guid>(nullable: false),
                    NoOfDependents = table.Column<int>(nullable: false),
                    BloodGroupId = table.Column<Guid>(nullable: true),
                    ReligionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_DictionaryValues_BloodGroupId",
                        column: x => x.BloodGroupId,
                        principalSchema: "CERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_DictionaryValues_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "CERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_DictionaryValues_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalSchema: "CERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_DictionaryValues_NationalityId",
                        column: x => x.NationalityId,
                        principalSchema: "CERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_DictionaryValues_POB_ID",
                        column: x => x.POB_ID,
                        principalSchema: "CERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_DictionaryValues_ReligionId",
                        column: x => x.ReligionId,
                        principalSchema: "CERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BloodGroupId",
                schema: "HR",
                table: "Employees",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderId",
                schema: "HR",
                table: "Employees",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MaritalStatusId",
                schema: "HR",
                table: "Employees",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalityId",
                schema: "HR",
                table: "Employees",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_POB_ID",
                schema: "HR",
                table: "Employees",
                column: "POB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReligionId",
                schema: "HR",
                table: "Employees",
                column: "ReligionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees",
                schema: "HR");
        }
    }
}
