﻿using CERP.FM.COA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace CERP.FM
{
    public class CERP_FM_DataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Company, Guid> _CompanyRepo;
        private readonly IRepository<Branch, Guid> _BrachRepo;
        private readonly IRepository<COA_HeadAccount, Guid> _COAHeadAccountRepo;
        private readonly IRepository<AccountStatementType, Guid> _AccountStatementTypeRepo;
        //private readonly IRepository<CashFlowStatementType, Guid> _CashFlowStatementTypeRepo;
        private readonly IRepository<COA_AccountSubCategory, Guid> _COASubCategoriesRepo;

        private readonly IRepository<COA_SubLedgerRequirement, Guid> _SubLedgerRequirements;

        private readonly IGuidGenerator _guidGenerator;

        public CERP_FM_DataSeedContributor(IRepository<COA_HeadAccount, Guid> cOAHeadAccountRepo, IGuidGenerator guidGenerator, IRepository<AccountStatementType, Guid> accountStatementTypeRepo, IRepository<COA_SubLedgerRequirement, Guid> subLedgerRequirements, IRepository<COA_AccountSubCategory, Guid> cOASubCategories, IRepository<Company, Guid> companyRepo, IRepository<Branch, Guid> brachRepo)
        {
            _CompanyRepo = companyRepo;

            _COAHeadAccountRepo = cOAHeadAccountRepo;
            _AccountStatementTypeRepo = accountStatementTypeRepo;
            //_CashFlowStatementTypeRepo = cashFlowStatementTypeRepo;
            _COASubCategoriesRepo = cOASubCategories;

            _SubLedgerRequirements = subLedgerRequirements;

            _guidGenerator = guidGenerator;
            _BrachRepo = brachRepo;
        }

        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            var curCompanies = await _CompanyRepo.GetListAsync();
            if (curCompanies == null || !curCompanies.Any(x => x.Name == "TestCorp"))
            {
                await _CompanyRepo.InsertAsync(new Company(_guidGenerator.Create())
                {
                    Name = "TestCorp",
                    NameLocalizationKey = "SERP:Company:Name:TestCorp",
                    Address = "Safari Villas Complex, Bahria Town Ph. 7, Islamabad, Pakistan",
                    AddressLocalizationKey = "SERP:Company:Address:TestCorp",
                    BankDetail = @"Bank: Test Commercial Bank
                                   Account Number: 12387104000103
                                   Name: TestCorp
                                   IBAN Number: SA53 1000 0012 3921 0450 0173
                                   Beneficiary: Hamza Abdullah",
                    BankDetailLocalizationKey = "SERP:Company:BankDetail:TestCorp",
                    Email = "monosoft54@gmail.com",
                    Phone = "+92-332-102-1701",
                    Website = "www.hamza-abdullah.tk",
                    FiscalYearStartMonth = 1,
                    FiscalYearBasis = "Conventional",
                    IsEnabled = true,
                    Language = "EN",
                    VATNumber = "1234567819912000031",
                    CRNumber = "1234567",
                });
            }

            var curBranches = await _BrachRepo.GetListAsync();
            if (curCompanies != null && curCompanies.Any(x => x.Name == "TestCorp"))
            {
                if (curBranches == null || !curBranches.Any(x => x.Name == "Head"))
                {
                    await _BrachRepo.InsertAsync(new Branch(_guidGenerator.Create())
                    {
                        Name = "Head",
                        Location = "Riyadh, KSA",
                        BranchCode = 01,
                        IsDeleted = false,
                        Company = curCompanies.First(x => x.Name == "TestCorp")
                    });
                }
            }

            var curCOAHAs = await _COAHeadAccountRepo.GetListAsync();
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Assets"))
            {
                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.Asset,
                    AccountName = "Assets",
                    LocalizationKey = "FM:COA:HeadAccount:Asset"

                });
            }
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Liabilities"))
            {
                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.Liability,
                    AccountName = "Liabilities",
                    LocalizationKey = "FM:COA:HeadAccount:Liabilities"

                });
            }
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Capital"))
            {
                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.Capital,
                    AccountName = "Capital",
                    LocalizationKey = "FM:COA:HeadAccount:Capital"

                });
            }
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Equity"))
            {
                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.Equity,
                    AccountName = "Equity",
                    LocalizationKey = "FM:COA:HeadAccount:Equity"

                });
            }
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Revenues"))
            {

                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.Revenue,
                    AccountName = "Revenues",
                    LocalizationKey = "FM:COA:HeadAccount:Revenues"

                });
            }
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Direct Costs"))
            {
                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.DirectCost,
                    AccountName = "Direct Costs",
                    LocalizationKey = "FM:COA:HeadAccount:Direct Costs"

                });
            }
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Expenses"))
            {
                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.Expenses,
                    AccountName = "Expenses",
                    LocalizationKey = "FM:COA:HeadAccount:Expenses"

                });
            }
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Other Income"))
            {
                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.OtherIncome,
                    AccountName = "Other Income",
                    LocalizationKey = "FM:COA:HeadAccount:OtherIncome"

                });
            }

            var curCOASubCats = await _COASubCategoriesRepo.GetListAsync();
            if (curBranches != null && curBranches.Any(x => x.Name == "Head") && _COAHeadAccountRepo != null && _COAHeadAccountRepo.Count() > 0)
            {
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Current Assets"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Current Assets",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Assets"),
                        CLI = 2,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.Name == "TestCorp"),
                        SubCategoryCode = "101",
                        LocalizationKey = "FM:COA:SubCategory:101"
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Fixed Assets"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Fixed Assets",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Assets"),
                        CLI = 2,
                        SubCategoryId = 02,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.Name == "TestCorp"),
                        SubCategoryCode = "102",
                        LocalizationKey = "FM:COA:SubCategory:102"
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Current Liabilities"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Current Liabilities",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Liabilities"),
                        CLI = 2,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.Name == "TestCorp"),
                        SubCategoryCode = "201",
                        LocalizationKey = "FM:COA:SubCategory:201"
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Liabilities"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Liabilities",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Liabilities"),
                        CLI = 2,
                        SubCategoryId = 02,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.Name == "TestCorp"),
                        SubCategoryCode = "202",
                        LocalizationKey = "FM:COA:SubCategory:202"
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Equity"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Equity",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Equity"),
                        CLI = 2,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.Name == "TestCorp"),
                        SubCategoryCode = "401",
                        LocalizationKey = "FM:COA:SubCategory:401"
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Revenue"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Revenue",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Revenues"),
                        CLI = 2,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.Name == "TestCorp"),
                        SubCategoryCode = "501",
                        LocalizationKey = "FM:COA:SubCategory:501"
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Direct Cost"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Direct Cost",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Direct Costs"),
                        CLI = 2,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.Name == "TestCorp"),
                        SubCategoryCode = "601",
                        LocalizationKey = "FM:COA:SubCategory:601"
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "G&A"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "G&A",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Expenses"),
                        CLI = 2,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.Name == "TestCorp"),
                        SubCategoryCode = "701",
                        LocalizationKey = "FM:COA:SubCategory:701"
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Other Income"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Other Income",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Other Income"),
                        CLI = 2,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.Name == "TestCorp"),
                        SubCategoryCode = "801",
                        LocalizationKey = "FM:COA:SubCategory:801"
                    });
                }
            }

            var curCOAASTs = await _AccountStatementTypeRepo.GetListAsync();
            if (curCOAASTs == null || !curCOAASTs.Any(x => x.Title == "Balance Sheet"))
            {
                await _AccountStatementTypeRepo.InsertAsync(new AccountStatementType(_guidGenerator.Create())
                {
                    AccountStatementTypeId = AccountStatementTypeEnum.BalanceSheet,
                    Title = "Balance Sheet",
                    TitleLocalizationKey = "FM:AccountStatementType:BalanceSheet"

                });
            }
            if (curCOAASTs == null || !curCOAASTs.Any(x => x.Title == "Profit & Loss"))
            {
                await _AccountStatementTypeRepo.InsertAsync(new AccountStatementType(_guidGenerator.Create())
                {
                    AccountStatementTypeId = AccountStatementTypeEnum.ProfitAndLoss,
                    Title = "Profit & Loss",
                    TitleLocalizationKey = "FM:AccountStatementType:ProfitAndLoss"

                });
            }
            if (curCOAASTs != null && curCOAASTs.Any(x => x.Title == "Profit & Loss") && curCOAASTs.Any(x => x.Title == "Balance Sheet"))
            {
                if (curCOAASTs == null || !curCOAASTs.Any(x => x.Title == "Current Assets"))
                {
                    await _AccountStatementTypeRepo.InsertAsync(new AccountStatementType(_guidGenerator.Create())
                    {
                        AccountStatementTypeId = AccountStatementTypeEnum.BalanceSheet,
                        AccountStatementDetailTypeId = AccountStatementDetailTypeEnum.CurrentAssets,
                        Title = "Current Assets",
                        TitleLocalizationKey = "FM:AccountStatementType:CurrentAssets",
                        ParentId = curCOAASTs.First(x => x.AccountStatementTypeId == AccountStatementTypeEnum.BalanceSheet).Id
                    });
                }
                if (curCOAASTs == null || !curCOAASTs.Any(x => x.Title == "Current Liabilities"))
                {
                    await _AccountStatementTypeRepo.InsertAsync(new AccountStatementType(_guidGenerator.Create())
                    {
                        AccountStatementTypeId = AccountStatementTypeEnum.BalanceSheet,
                        AccountStatementDetailTypeId = AccountStatementDetailTypeEnum.CurrentLiabilities,
                        Title = "Current Liabilities",
                        TitleLocalizationKey = "FM:AccountStatementType:CurrentLiabilities",
                        ParentId = curCOAASTs.First(x => x.AccountStatementTypeId == AccountStatementTypeEnum.BalanceSheet).Id
                    });
                }
                if (curCOAASTs == null || !curCOAASTs.Any(x => x.Title == "Direct Costs"))
                {
                    await _AccountStatementTypeRepo.InsertAsync(new AccountStatementType(_guidGenerator.Create())
                    {
                        AccountStatementTypeId = AccountStatementTypeEnum.ProfitAndLoss,
                        AccountStatementDetailTypeId = AccountStatementDetailTypeEnum.DirectCosts,
                        Title = "Direct Costs",
                        TitleLocalizationKey = "FM:AccountStatementType:DirectCosts",
                        ParentId = curCOAASTs.First(x => x.AccountStatementTypeId == AccountStatementTypeEnum.ProfitAndLoss).Id
                    });
                }
                if (curCOAASTs == null || !curCOAASTs.Any(x => x.Title == "Equity"))
                {
                    await _AccountStatementTypeRepo.InsertAsync(new AccountStatementType(_guidGenerator.Create())
                    {
                        AccountStatementTypeId = AccountStatementTypeEnum.BalanceSheet,
                        AccountStatementDetailTypeId = AccountStatementDetailTypeEnum.Equity,
                        Title = "Equity",
                        TitleLocalizationKey = "FM:AccountStatementType:Equity",
                        ParentId = curCOAASTs.First(x => x.AccountStatementTypeId == AccountStatementTypeEnum.BalanceSheet).Id
                    });
                }
                if (curCOAASTs == null || !curCOAASTs.Any(x => x.Title == "General & Administrative Expenses"))
                {
                    await _AccountStatementTypeRepo.InsertAsync(new AccountStatementType(_guidGenerator.Create())
                    {
                        AccountStatementTypeId = AccountStatementTypeEnum.ProfitAndLoss,
                        AccountStatementDetailTypeId = AccountStatementDetailTypeEnum.GAExpenses,
                        Title = "General & Administrative Expenses",
                        TitleLocalizationKey = "FM:AccountStatementType:GeneralAndAdministrativeExpenses",
                        ParentId = curCOAASTs.First(x => x.AccountStatementTypeId == AccountStatementTypeEnum.ProfitAndLoss).Id

                    });
                }
                if (curCOAASTs == null || !curCOAASTs.Any(x => x.Title == "Non-Current Assets"))
                {
                    await _AccountStatementTypeRepo.InsertAsync(new AccountStatementType(_guidGenerator.Create())
                    {
                        AccountStatementTypeId = AccountStatementTypeEnum.BalanceSheet,
                        AccountStatementDetailTypeId = AccountStatementDetailTypeEnum.NonCurrentAssets,
                        Title = "Non-Current Assets",
                        TitleLocalizationKey = "FM:AccountStatementType:NonCurrentAssets",
                        ParentId = curCOAASTs.First(x => x.AccountStatementTypeId == AccountStatementTypeEnum.BalanceSheet).Id

                    });
                }
                if (curCOAASTs == null || !curCOAASTs.Any(x => x.Title == "Non-Current Liabilities"))
                {
                    await _AccountStatementTypeRepo.InsertAsync(new AccountStatementType(_guidGenerator.Create())
                    {
                        AccountStatementTypeId = AccountStatementTypeEnum.BalanceSheet,
                        AccountStatementDetailTypeId = AccountStatementDetailTypeEnum.NonCurrentLiabilities,
                        Title = "Non-Current Liabilities",
                        TitleLocalizationKey = "FM:AccountStatementType:NonCurrentLiabilities",
                        ParentId = curCOAASTs.First(x => x.AccountStatementTypeId == AccountStatementTypeEnum.BalanceSheet).Id

                    });
                }
                if (curCOAASTs == null || !curCOAASTs.Any(x => x.Title == "Revenue"))
                {
                    await _AccountStatementTypeRepo.InsertAsync(new AccountStatementType(_guidGenerator.Create())
                    {
                        AccountStatementTypeId = AccountStatementTypeEnum.ProfitAndLoss,
                        AccountStatementDetailTypeId = AccountStatementDetailTypeEnum.Revenue,
                        Title = "Revenue",
                        TitleLocalizationKey = "FM:AccountStatementType:Revenue",
                        ParentId = curCOAASTs.First(x => x.AccountStatementTypeId == AccountStatementTypeEnum.ProfitAndLoss).Id

                    });
                }
                if (curCOAASTs == null || !curCOAASTs.Any(x => x.Title == "Tax Zakat"))
                {
                    await _AccountStatementTypeRepo.InsertAsync(new AccountStatementType(_guidGenerator.Create())
                    {
                        AccountStatementTypeId = AccountStatementTypeEnum.ProfitAndLoss,
                        AccountStatementDetailTypeId = AccountStatementDetailTypeEnum.Zakat,
                        Title = "Tax Zakat",
                        TitleLocalizationKey = "FM:AccountStatementType:TaxZakat",
                        ParentId = curCOAASTs.First(x => x.AccountStatementTypeId == AccountStatementTypeEnum.ProfitAndLoss).Id

                    });
                }
            }

            #region CFS
            //var curCFS = await _CashFlowStatementTypeRepo.GetListAsync();
            //if (curCFS == null || !curCFS.Any(x => x.Title == "Cash Generated From Operations"))
            //{
            //    await _CashFlowStatementTypeRepo.InsertAsync(new CashFlowStatementType(_guidGenerator.Create())
            //    {
            //        CashFlowStatementTypeId = CashFlowStatementTypeEnum.CashGeneratedFromOperations,
            //        Title = "Cash Generated From Operations",
            //        TitleLocalizationKey = "FM:CashFlowStatementType:CashGeneratedFromOperations"

            //    });
            //}
            //if (curCFS == null || !curCFS.Any(x => x.Title == "Cashflow From Operating Activites"))
            //{
            //    await _CashFlowStatementTypeRepo.InsertAsync(new CashFlowStatementType(_guidGenerator.Create())
            //    {
            //        CashFlowStatementTypeId = CashFlowStatementTypeEnum.CashFlowFromOperatingActivities,
            //        Title = "Cashflow From Operating Activites",
            //        TitleLocalizationKey = "FM:CashFlowStatementType:CashFlowFromOperatingActivities"

            //    });
            //}
            //if (curCFS == null || !curCFS.Any(x => x.Title == "Cashflow From Financing Activites"))
            //{
            //    await _CashFlowStatementTypeRepo.InsertAsync(new CashFlowStatementType(_guidGenerator.Create())
            //    {
            //        CashFlowStatementTypeId = CashFlowStatementTypeEnum.CashFlowFromFinancingActivites,
            //        Title = "Cashflow From Financing Activites",
            //        TitleLocalizationKey = "FM:CashFlowStatementType:CashFlowFromFinancingActivites"

            //    });
            //}
            //if (curCFS == null || !curCFS.Any(x => x.Title == "Net Profit Before Tax"))
            //{
            //    await _CashFlowStatementTypeRepo.InsertAsync(new CashFlowStatementType(_guidGenerator.Create())
            //    {
            //        CashFlowStatementTypeId = CashFlowStatementTypeEnum.NetProfitBeforeTax,
            //        Title = "Net Profit Before Tax",
            //        TitleLocalizationKey = "FM:CashFlowStatementType:NetProfitBeforeTax"

            //    }); 
            //}

            //if (curCFS == null || !curCFS.Any(x => x.Title == "Operating Profit Before Working Capital"))
            //{
            //    await _CashFlowStatementTypeRepo.InsertAsync(new CashFlowStatementType(_guidGenerator.Create())
            //    {
            //        CashFlowStatementTypeId = CashFlowStatementTypeEnum.OperatingProfitBeforeWorkingCapital,
            //        Title = "Operating Profit Before Working Capital",
            //        TitleLocalizationKey = "FM:CashFlowStatementType:OperatingProfitBeforeWorkingCapital"

            //    });
            //}
            //if (curCFS == null || !curCFS.Any(x => x.Title == "Cash And Cash Equivalents"))
            //{
            //    await _CashFlowStatementTypeRepo.InsertAsync(new CashFlowStatementType(_guidGenerator.Create())
            //    {
            //        CashFlowStatementTypeId = CashFlowStatementTypeEnum.CashAndCashEquivalents,
            //        Title = "Cash And Cash Equivalents",
            //        TitleLocalizationKey = "FM:CashFlowStatementType:CashAndCashEquivalents"

            //    });
            //}
            #endregion


            var curSLR = await _SubLedgerRequirements.GetListAsync();
            if (curSLR == null || !curSLR.Any(x => x.Title == "Employee"))
            {
                await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
                {
                    Title = "Employee",
                    TitleLocalizationKey = "FM:SubLedgerRequirements:Employee"

                });
            }
            if (curSLR == null || !curSLR.Any(x => x.Title == "Department"))
            {
                await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
                {
                    Title = "Department",
                    TitleLocalizationKey = "FM:SubLedgerRequirements:Department"

                });
            }
            if (curSLR == null || !curSLR.Any(x => x.Title == "Project"))
            {
                await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
                {
                    Title = "Project",
                    TitleLocalizationKey = "FM:SubLedgerRequirements:Project"

                });
            }
            if (curSLR == null || !curSLR.Any(x => x.Title == "Fixed Assets"))
            {
                await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
                {
                    Title = "Fixed Assets",
                    TitleLocalizationKey = "FM:SubLedgerRequirements:FixedAssets"

                });
            }
            if (curSLR == null || !curSLR.Any(x => x.Title == "Vendor"))
            {
                await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
                {
                    Title = "Vendor",
                    TitleLocalizationKey = "FM:SubLedgerRequirements:Vendor"

                });
            }
            if (curSLR == null || !curSLR.Any(x => x.Title == "Customer"))
            {
                await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
                {
                    Title = "Customer",
                    TitleLocalizationKey = "FM:SubLedgerRequirements:Customer"

                });
            }
            if (curSLR == null || !curSLR.Any(x => x.Title == "Item"))
            {
                await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
                {
                    Title = "Item",
                    TitleLocalizationKey = "FM:SubLedgerRequirements:Item"

                });
            }
            if (curSLR == null || !curSLR.Any(x => x.Title == "Location"))
            {
                await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
                {
                    Title = "Location",
                    TitleLocalizationKey = "FM:SubLedgerRequirements:Location"

                });
            }
        }
    }
}
