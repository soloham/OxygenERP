using CERP.App;
using CERP.FM.COA;
using CERP.Setup;
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
        private readonly IRepository<COA_Account, Guid> _COAsRepo;
        private readonly IRepository<COA_HeadAccount, Guid> _COAHeadAccountRepo;
        private readonly IRepository<AccountStatementType, Guid> _AccountStatementTypeRepo;
        //private readonly IRepository<CashFlowStatementType, Guid> _CashFlowStatementTypeRepo;
        private readonly IRepository<COA_AccountSubCategory, Guid> _COASubCategoriesRepo;

        private readonly IRepository<COA_SubLedgerRequirement, Guid> _SubLedgerRequirements;
        private readonly IRepository<DictionaryValue, Guid> _DicValueRepo;

        private readonly IGuidGenerator _guidGenerator;

        public CERP_FM_DataSeedContributor(IRepository<COA_HeadAccount, Guid> cOAHeadAccountRepo, IGuidGenerator guidGenerator, IRepository<AccountStatementType, Guid> accountStatementTypeRepo, IRepository<COA_SubLedgerRequirement, Guid> subLedgerRequirements, IRepository<COA_AccountSubCategory, Guid> cOASubCategories, IRepository<Company, Guid> companyRepo, IRepository<Branch, Guid> brachRepo, IRepository<COA_Account, Guid> cOAsRepo, IRepository<DictionaryValue, Guid> dicValueRepo)
        {
            _CompanyRepo = companyRepo;

            _COAHeadAccountRepo = cOAHeadAccountRepo;
            _AccountStatementTypeRepo = accountStatementTypeRepo;
            //_CashFlowStatementTypeRepo = cashFlowStatementTypeRepo;
            _COASubCategoriesRepo = cOASubCategories;

            _SubLedgerRequirements = subLedgerRequirements;

            _guidGenerator = guidGenerator;
            _BrachRepo = brachRepo;
            _COAsRepo = cOAsRepo;
            _DicValueRepo = dicValueRepo;
        }

        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            bool deleteDuplicates = true;
            
            var curCompanies = await _CompanyRepo.GetListAsync();
            if(deleteDuplicates)  curCompanies.ForEach(async (Company c) => { if (curCompanies.Count(x => x.CompanyName == c.CompanyName) > 1) { await _CompanyRepo.DeleteAsync(c.Id); } });
            
            if (curCompanies == null || !curCompanies.Any(x => x.CompanyName == "TestCorp"))
            {
                await _CompanyRepo.InsertAsync(new Company(_guidGenerator.Create())
                {
                    CompanyName = "TestCorp",
                    CompanyNameLocalized = "تعست کہرپ",
                    Status = CompanyStatus.Active,
                    RegistrationID = "12345679813245679",
                    VATID = "123456789",
                    TaxID = "4564566456",
                    SocialInsuranceID = "465445",
                    //Language = Language.English,
                    TenantId = context.TenantId
                });
            }

            var curBranches = await _BrachRepo.GetListAsync();
            if (curCompanies != null && curCompanies.Any(x => x.CompanyName == "TestCorp"))
            {
                if (curBranches == null || !curBranches.Any(x => x.Name == "Head"))
                {
                    await _BrachRepo.InsertAsync(new Branch(_guidGenerator.Create())
                    {
                        Name = "Head",
                        Location = "Riyadh, KSA",
                        BranchCode = 01,
                        IsDeleted = false,
                        Company = curCompanies.First(x => x.CompanyName == "TestCorp"),
                        TenantId = context.TenantId
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
                    LocalizationKey = "FM:COA:HeadAccount:Asset",
                      TenantId =context.TenantId
                });
            }
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Liabilities"))
            {
                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.Liability,
                    AccountName = "Liabilities",
                    LocalizationKey = "FM:COA:HeadAccount:Liabilities",
                      TenantId =context.TenantId
                });
            }
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Capital"))
            {
                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.Capital,
                    AccountName = "Capital",
                    LocalizationKey = "FM:COA:HeadAccount:Capital",
                      TenantId =context.TenantId
                });
            }
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Equity"))
            {
                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.Equity,
                    AccountName = "Equity",
                    LocalizationKey = "FM:COA:HeadAccount:Equity",
                      TenantId =context.TenantId
                });
            }
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Revenues"))
            {

                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.Revenue,
                    AccountName = "Revenues",
                    LocalizationKey = "FM:COA:HeadAccount:Revenues",
                      TenantId =context.TenantId
                });
            }
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Direct Costs"))
            {
                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.DirectCost,
                    AccountName = "Direct Costs",
                    LocalizationKey = "FM:COA:HeadAccount:Direct Costs",
                      TenantId =context.TenantId
                });
            }
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Expenses"))
            {
                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.Expenses,
                    AccountName = "Expenses",
                    LocalizationKey = "FM:COA:HeadAccount:Expenses",
                      TenantId =context.TenantId
                });
            }
            if (curCOAHAs == null || !curCOAHAs.Any(x => x.AccountName == "Other Income"))
            {
                await _COAHeadAccountRepo.InsertAsync(new COA_HeadAccount(_guidGenerator.Create())
                {
                    HeadCode = HeadAccountType.OtherIncome,
                    AccountName = "Other Income",
                    LocalizationKey = "FM:COA:HeadAccount:OtherIncome",
                      TenantId =context.TenantId
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
                        CLI = AccountCLI.SubHeader,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.CompanyName == "TestCorp"),
                        SubCategoryCode = "101",
                        LocalizationKey = "FM:COA:SubCategory:101",
                        IsDeleted = false,
             TenantId = context.TenantId
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Fixed Assets"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Fixed Assets",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Assets"),
                        CLI = AccountCLI.SubHeader,
                        SubCategoryId = 02,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.CompanyName == "TestCorp"),
                        SubCategoryCode = "102",
                        LocalizationKey = "FM:COA:SubCategory:102",
                        IsDeleted = false,
             TenantId = context.TenantId
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Current Liabilities"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Current Liabilities",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Liabilities"),
                        CLI = AccountCLI.SubHeader,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.CompanyName == "TestCorp"),
                        SubCategoryCode = "201",
                        LocalizationKey = "FM:COA:SubCategory:201",
                        IsDeleted = false,
             TenantId = context.TenantId
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Long Term Liabilities"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Long Term Liabilities",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Liabilities"),
                        CLI = AccountCLI.SubHeader,
                        SubCategoryId = 02,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.CompanyName == "TestCorp"),
                        SubCategoryCode = "202",
                        LocalizationKey = "FM:COA:SubCategory:202",
                        IsDeleted = false,
             TenantId = context.TenantId
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Share Capital"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Share Capital",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Capital"),
                        CLI = AccountCLI.SubHeader,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.CompanyName == "TestCorp"),
                        SubCategoryCode = "301",
                        LocalizationKey = "FM:COA:SubCategory:301",
                        IsDeleted = false,
             TenantId = context.TenantId
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Partner's Current Account"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Partner's Current Account",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Capital"),
                        CLI = AccountCLI.SubHeader,
                        SubCategoryId = 02,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.CompanyName == "TestCorp"),
                        SubCategoryCode = "302",
                        LocalizationKey = "FM:COA:SubCategory:302",
                        IsDeleted = false,
             TenantId = context.TenantId
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Retained Earning"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Retained Earning",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Capital"),
                        CLI = AccountCLI.SubHeader,
                        SubCategoryId = 03,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.CompanyName == "TestCorp"),
                        SubCategoryCode = "303",
                        LocalizationKey = "FM:COA:SubCategory:303",
                        IsDeleted = false,
             TenantId = context.TenantId
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Equity"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Equity",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Equity"),
                        CLI = AccountCLI.SubHeader,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.CompanyName == "TestCorp"),
                        SubCategoryCode = "401",
                        LocalizationKey = "FM:COA:SubCategory:401",
                        IsDeleted = false,
             TenantId = context.TenantId
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Revenue"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Revenue",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Revenues"),
                        CLI = AccountCLI.SubHeader,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.CompanyName == "TestCorp"),
                        SubCategoryCode = "501",
                        LocalizationKey = "FM:COA:SubCategory:501",
                        IsDeleted = false,
             TenantId = context.TenantId
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Direct Cost Items"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Direct Cost Items",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Direct Costs"),
                        CLI = AccountCLI.SubHeader,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.CompanyName == "TestCorp"),
                        SubCategoryCode = "601",
                        LocalizationKey = "FM:COA:SubCategory:601",
                        IsDeleted = false,
             TenantId = context.TenantId
                    });
                }

                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Direct Cost Others"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Direct Cost Others",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Direct Costs"),
                        CLI = AccountCLI.SubHeader,
                        SubCategoryId = 02,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.CompanyName == "TestCorp"),
                        SubCategoryCode = "602",
                        LocalizationKey = "FM:COA:SubCategory:602",
                        IsDeleted = false,
             TenantId = context.TenantId
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "G&A"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "G&A",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Expenses"),
                        CLI = AccountCLI.SubHeader,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.CompanyName == "TestCorp"),
                        SubCategoryCode = "701",
                        LocalizationKey = "FM:COA:SubCategory:701",
                        IsDeleted = false,
             TenantId = context.TenantId
                    });
                }
                if (curCOASubCats == null || !curCOASubCats.Any(x => x.Title == "Other Income"))
                {
                    await _COASubCategoriesRepo.InsertAsync(new COA_AccountSubCategory(_guidGenerator.Create())
                    {
                        Title = "Other Income",
                        HeadAccount = curCOAHAs.First(x => x.AccountName == "Other Income"),
                        CLI = AccountCLI.SubHeader,
                        SubCategoryId = 01,
                        Branch = curBranches.First(x => x.Name == "Head"),
                        Company = curCompanies.First(x => x.CompanyName == "TestCorp"),
                        SubCategoryCode = "801",
                        LocalizationKey = "FM:COA:SubCategory:801",
                        IsDeleted = false,
             TenantId = context.TenantId
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
                    TitleLocalizationKey = "FM:AccountStatementType:BalanceSheet",
                      TenantId =context.TenantId
                });
            }
            if (curCOAASTs == null || !curCOAASTs.Any(x => x.Title == "Profit & Loss"))
            {
                await _AccountStatementTypeRepo.InsertAsync(new AccountStatementType(_guidGenerator.Create())
                {
                    AccountStatementTypeId = AccountStatementTypeEnum.ProfitAndLoss,
                    Title = "Profit & Loss",
                    TitleLocalizationKey = "FM:AccountStatementType:ProfitAndLoss",
                      TenantId =context.TenantId
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

            //if (curSLR == null || !curSLR.Any(x => x.Title == "Employee"))
            //{
            //    await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
            //    {
            //        Title = "Employee",
            //        TitleLocalizationKey = "FM:SubLedgerRequirements:Employee"

            //    });
            //}
            if (curSLR == null || !curSLR.Any(x => x.Title == "Address Book"))
            {
                await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
                {
                    Title = "Address Book",
                    TitleLocalizationKey = "FM:SubLedgerRequirements:AddressBook",
                      TenantId =context.TenantId
                });
            }
            //if (curSLR == null || !curSLR.Any(x => x.Title == "Project"))
            //{
            //    await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
            //    {
            //        Title = "Project",
            //        TitleLocalizationKey = "FM:SubLedgerRequirements:Project"

            //    });
            //}
            if (curSLR == null || !curSLR.Any(x => x.Title == "Fixed Assets"))
            {
                await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
                {
                    Title = "Fixed Assets",
                    TitleLocalizationKey = "FM:SubLedgerRequirements:FixedAssets",
                      TenantId =context.TenantId
                });
            }
            //if (curSLR == null || !curSLR.Any(x => x.Title == "Vendor"))
            //{
            //    await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
            //    {
            //        Title = "Vendor",
            //        TitleLocalizationKey = "FM:SubLedgerRequirements:Vendor"

            //    });
            //}
            if (curSLR == null || !curSLR.Any(x => x.Title == "Customer"))
            {
                await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
                {
                    Title = "Customer",
                    TitleLocalizationKey = "FM:SubLedgerRequirements:Customer",
                      TenantId =context.TenantId
                });
            }
            //if (curSLR == null || !curSLR.Any(x => x.Title == "Item"))
            //{
            //    await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
            //    {
            //        Title = "Item",
            //        TitleLocalizationKey = "FM:SubLedgerRequirements:Item"

            //    });
            //}
            //if (curSLR == null || !curSLR.Any(x => x.Title == "Location"))
            //{
            //    await _SubLedgerRequirements.InsertAsync(new COA_SubLedgerRequirement(_guidGenerator.Create())
            //    {
            //        Title = "Location",
            //        TitleLocalizationKey = "FM:SubLedgerRequirements:Location"

            //    });
            //}

            //var coas = await _COAsRepo.GetListAsync();

            //if (!coas.Any(x => x.AccountName == "TestAccount"))
            //{
            //    await _COAsRepo.InsertAsync(new COA_Account(_guidGenerator.Create())
            //    {
            //        AccountName = "TestAccount",
            //        AccountCode = "1-1100000",

            //        //int maxCode = Convert.ToInt32(_COAsList.Count > 0 ? _COAsList.Where(c => c.HeadAccountId == dto.HeadAccountId && c.AccountSubCat1Id == dto.AccountSubCat1Id).Max(c => c.AccountId) : 0);
            //        AccountId = 1,

            //        HeadAccount = curCOAHAs[0],
            //        HeadAccountId = curCOAHAs[0].Id,
            //        AccountStatementType = curCOAASTs[0],
            //        AccountStatementDetailTypeId = curCOAASTs[0].Id,
            //        AccountSubCategory_1 = curCOASubCats[0],
            //        AccountSubCat1Id = curCOASubCats[0].Id,
            //        Company = curCompanies[0],
            //        CompanyId = curCompanies[0].Id,
            //        Branch = curBranches[0],
            //        BranchId = curBranches[0].Id,
            //        CashFlowStatementTypeId = _DicValueRepo.Where(x => x.Key == "01").First().Id
            //    });;
            //}
        }
    }
}