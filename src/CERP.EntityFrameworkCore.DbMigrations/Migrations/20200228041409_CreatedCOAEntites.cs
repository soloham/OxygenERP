using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CERP.Migrations
{
    public partial class CreatedCOAEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CERP");

            migrationBuilder.EnsureSchema(
                name: "FM");

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "CERP",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    NameLocalizationKey = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: false),
                    AddressLocalizationKey = table.Column<string>(nullable: true),
                    BankDetail = table.Column<string>(nullable: false),
                    BankDetailLocalizationKey = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    FiscalYearStartMonth = table.Column<int>(nullable: false),
                    FiscalYearBasis = table.Column<string>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: true),
                    Language = table.Column<string>(nullable: false),
                    VATNumber = table.Column<string>(nullable: false),
                    CRNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountStatementTypes",
                schema: "FM",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    AccountStatementTypeId = table.Column<int>(nullable: false),
                    AccountStatementDetailTypeId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    TitleLocalizationKey = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStatementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COAHeadAccounts",
                schema: "FM",
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
                    HeadCode = table.Column<int>(nullable: false),
                    AccountName = table.Column<string>(nullable: false),
                    LocalizationKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COAHeadAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                schema: "CERP",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    BranchCode = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "CERP",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryValueTypes",
                schema: "CERP",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    ValueTypeName = table.Column<string>(nullable: false),
                    ValueTypeNameLocalizationKey = table.Column<string>(nullable: true),
                    ActiveStatus = table.Column<bool>(nullable: false),
                    Locked = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: true),
                    BranchId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryValueTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictionaryValueTypes_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "CERP",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DictionaryValueTypes_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "CERP",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COASubCategories",
                schema: "FM",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    HeadAccountId = table.Column<Guid>(nullable: false),
                    SubCategoryId = table.Column<int>(nullable: false),
                    SubCategoryCode = table.Column<string>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: false),
                    CLI = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    LocalizationKey = table.Column<string>(nullable: true),
                    BranchId = table.Column<Guid>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COASubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COASubCategories_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "CERP",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COASubCategories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "CERP",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COASubCategories_COAHeadAccounts_HeadAccountId",
                        column: x => x.HeadAccountId,
                        principalSchema: "FM",
                        principalTable: "COAHeadAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryValues",
                schema: "CERP",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ValueLocalizationKey = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    Dimension_1_Key = table.Column<string>(nullable: true),
                    Dimension_1_Value = table.Column<string>(nullable: true),
                    Dimension_2_Key = table.Column<string>(nullable: true),
                    Dimension_2_Value = table.Column<string>(nullable: true),
                    Dimension_3_Key = table.Column<string>(nullable: true),
                    Dimension_3_Value = table.Column<string>(nullable: true),
                    Dimension_4_Key = table.Column<string>(nullable: true),
                    Dimension_4_Value = table.Column<string>(nullable: true),
                    ActiveStatus = table.Column<bool>(nullable: true),
                    ValueTypeId = table.Column<Guid>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: true),
                    BranchId = table.Column<Guid>(nullable: true),
                    DictionaryValueTypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictionaryValues_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "CERP",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DictionaryValues_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "CERP",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DictionaryValues_DictionaryValueTypes_DictionaryValueTypeId",
                        column: x => x.DictionaryValueTypeId,
                        principalSchema: "CERP",
                        principalTable: "DictionaryValueTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DictionaryValues_DictionaryValueTypes_ValueTypeId",
                        column: x => x.ValueTypeId,
                        principalSchema: "CERP",
                        principalTable: "DictionaryValueTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COAs",
                schema: "FM",
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
                    HeadAccountId = table.Column<Guid>(nullable: false),
                    AccountSubCat1Id = table.Column<Guid>(nullable: false),
                    AccountSubCat2Id = table.Column<Guid>(nullable: false),
                    AccountSubCat3Id = table.Column<Guid>(nullable: false),
                    AccountSubCat4Id = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    SubLedgerAccountId = table.Column<Guid>(nullable: true),
                    SubLedgerTypeId = table.Column<int>(nullable: true),
                    AccountCode = table.Column<int>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    BranchId = table.Column<Guid>(nullable: false),
                    AccountName = table.Column<string>(nullable: false),
                    AccountNameLocalizationKey = table.Column<string>(nullable: true),
                    AccountStatementTypeId = table.Column<Guid>(nullable: false),
                    AccountStatementDetailTypeId = table.Column<Guid>(nullable: false),
                    CashFlowStatementTypeId = table.Column<Guid>(nullable: false),
                    AllowPosting = table.Column<bool>(nullable: false),
                    AllowPayment = table.Column<bool>(nullable: false),
                    AllowReceipt = table.Column<bool>(nullable: false),
                    ActiveStatus = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COAs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COAs_AccountStatementTypes_AccountStatementDetailTypeId",
                        column: x => x.AccountStatementDetailTypeId,
                        principalSchema: "FM",
                        principalTable: "AccountStatementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COAs_AccountStatementTypes_AccountStatementTypeId",
                        column: x => x.AccountStatementTypeId,
                        principalSchema: "FM",
                        principalTable: "AccountStatementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COAs_COASubCategories_AccountSubCat1Id",
                        column: x => x.AccountSubCat1Id,
                        principalSchema: "FM",
                        principalTable: "COASubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COAs_COASubCategories_AccountSubCat2Id",
                        column: x => x.AccountSubCat2Id,
                        principalSchema: "FM",
                        principalTable: "COASubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COAs_COASubCategories_AccountSubCat3Id",
                        column: x => x.AccountSubCat3Id,
                        principalSchema: "FM",
                        principalTable: "COASubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COAs_COASubCategories_AccountSubCat4Id",
                        column: x => x.AccountSubCat4Id,
                        principalSchema: "FM",
                        principalTable: "COASubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COAs_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "CERP",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COAs_DictionaryValues_CashFlowStatementTypeId",
                        column: x => x.CashFlowStatementTypeId,
                        principalSchema: "CERP",
                        principalTable: "DictionaryValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COAs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "CERP",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COAs_COAHeadAccounts_HeadAccountId",
                        column: x => x.HeadAccountId,
                        principalSchema: "FM",
                        principalTable: "COAHeadAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COAs_COAs_SubLedgerAccountId",
                        column: x => x.SubLedgerAccountId,
                        principalSchema: "FM",
                        principalTable: "COAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubLedgerRequirements",
                schema: "FM",
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
                    Title = table.Column<string>(nullable: false),
                    TitleLocalizationKey = table.Column<string>(nullable: true),
                    COA_AccountId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLedgerRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubLedgerRequirements_COAs_COA_AccountId",
                        column: x => x.COA_AccountId,
                        principalSchema: "FM",
                        principalTable: "COAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CompanyId",
                schema: "CERP",
                table: "Branches",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryValues_BranchId",
                schema: "CERP",
                table: "DictionaryValues",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryValues_CompanyId",
                schema: "CERP",
                table: "DictionaryValues",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryValues_DictionaryValueTypeId",
                schema: "CERP",
                table: "DictionaryValues",
                column: "DictionaryValueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryValues_ValueTypeId",
                schema: "CERP",
                table: "DictionaryValues",
                column: "ValueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryValueTypes_BranchId",
                schema: "CERP",
                table: "DictionaryValueTypes",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryValueTypes_CompanyId",
                schema: "CERP",
                table: "DictionaryValueTypes",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_AccountStatementDetailTypeId",
                schema: "FM",
                table: "COAs",
                column: "AccountStatementDetailTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_AccountStatementTypeId",
                schema: "FM",
                table: "COAs",
                column: "AccountStatementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_AccountSubCat1Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat1Id");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_AccountSubCat2Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat2Id");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_AccountSubCat3Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat3Id");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_AccountSubCat4Id",
                schema: "FM",
                table: "COAs",
                column: "AccountSubCat4Id");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_BranchId",
                schema: "FM",
                table: "COAs",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_CashFlowStatementTypeId",
                schema: "FM",
                table: "COAs",
                column: "CashFlowStatementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_CompanyId",
                schema: "FM",
                table: "COAs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_HeadAccountId",
                schema: "FM",
                table: "COAs",
                column: "HeadAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_COAs_SubLedgerAccountId",
                schema: "FM",
                table: "COAs",
                column: "SubLedgerAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_COASubCategories_BranchId",
                schema: "FM",
                table: "COASubCategories",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_COASubCategories_CompanyId",
                schema: "FM",
                table: "COASubCategories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COASubCategories_HeadAccountId",
                schema: "FM",
                table: "COASubCategories",
                column: "HeadAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgerRequirements_COA_AccountId",
                schema: "FM",
                table: "SubLedgerRequirements",
                column: "COA_AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubLedgerRequirements",
                schema: "FM");

            migrationBuilder.DropTable(
                name: "COAs",
                schema: "FM");

            migrationBuilder.DropTable(
                name: "AccountStatementTypes",
                schema: "FM");

            migrationBuilder.DropTable(
                name: "COASubCategories",
                schema: "FM");

            migrationBuilder.DropTable(
                name: "DictionaryValues",
                schema: "CERP");

            migrationBuilder.DropTable(
                name: "COAHeadAccounts",
                schema: "FM");

            migrationBuilder.DropTable(
                name: "DictionaryValueTypes",
                schema: "CERP");

            migrationBuilder.DropTable(
                name: "Branches",
                schema: "CERP");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "CERP");
        }
    }
}
