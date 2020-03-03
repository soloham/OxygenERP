using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CERP.App;
using CERP.FM;
using CERP.FM.COA.DTOs;
using CERP.FM.COA.UV_DTOs;
using CERP.FM.DTOs;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace CERP.Web.Areas.FM.Pages.COA
{
    public class EditModel : CERPPageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid AccountGuid { get; set; }

        [BindProperty]
        public COA_Account_UV_Dto COAInput { get; set; }

        private readonly coaAppService _coaAppService;
        private readonly companyAppService _companyAppService;
        private readonly branchAppService _branchAppService;
        private readonly coaHeadAccountAppService _headAccountsAppService;
        private readonly coaAccountSubCategoryAppService _subCategoryAppService;

        public coaSubLedgerRequirementsAppService _subLedgerRequirementsAppService;
        public IRepository<AccountStatementType, Guid> _accStatementTypeRepo;

        public IRepository<DictionaryValue, Guid> _dictionaryValuesRepo;

        private IGuidGenerator _guidGenerator;

        public EditModel(coaAppService coaAppService, companyAppService companyAppService, branchAppService branchAppService, coaHeadAccountAppService headAccountsAppService, coaAccountSubCategoryAppService subCategoryAppService, coaSubLedgerRequirementsAppService subLedgerRequirementsAppService, IRepository<AccountStatementType, Guid> accStatementTypeRepo, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IGuidGenerator guidGenerator)
        {
            _coaAppService = coaAppService;
            _companyAppService = companyAppService;
            _branchAppService = branchAppService;
            _headAccountsAppService = headAccountsAppService;
            _subCategoryAppService = subCategoryAppService;
            _subLedgerRequirementsAppService = subLedgerRequirementsAppService;
            _accStatementTypeRepo = accStatementTypeRepo;
            _dictionaryValuesRepo = dictionaryValuesRepo;
            _guidGenerator = guidGenerator;

        }
        public List<Company_Dto> Companies = new List<Company_Dto>();
        public List<Branch_Dto> Branches = new List<Branch_Dto>();
        public List<COA_HeadAccount_Dto> HeadAccounts = new List<COA_HeadAccount_Dto>();
        public List<COA_AccountSubCategory_Dto> SubCategories = new List<COA_AccountSubCategory_Dto>();
        public List<COA_Account_Dto> SubLedgerAccounts = new List<COA_Account_Dto>();

        public List<COA_SubLedgerRequirement_Dto> SubLedgerRequirements = new List<COA_SubLedgerRequirement_Dto>();

        public async Task<IActionResult> OnGetAsync()
        {
            Companies = (await _companyAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 100 })).Items.ToList();
            Branches = (await _branchAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 100 })).Items.ToList();
            HeadAccounts = (await _headAccountsAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 100 })).Items.ToList();
            SubCategories = (await _subCategoryAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 100 })).Items.ToList();
            SubLedgerAccounts = _coaAppService.GetNonSubLedgerAccounts();
            SubLedgerRequirements = (await _subLedgerRequirementsAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 100 })).Items.ToList();

            COAInput = ObjectMapper.Map<COA_Account_Dto, COA_Account_UV_Dto>(await _coaAppService.GetAsync(AccountGuid));

            return Page();
        }

        public async Task<IActionResult> OnPostUpdate(COA_Account_UV_Dto dto)
        {
            try
            {
                var _COAsList = (await _coaAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 1000 })).Items.ToList();
                SubLedgerRequirements = (await _subLedgerRequirementsAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 1000 })).Items.ToList();

                var form = Request.Form;
                dto.SubLedgerRequirementAccounts = new List<COA_SubLedgerRequirement_Account_Dto>();
                for (int i = 0; i < SubLedgerRequirements.Count; i++)
                {
                    if (form.TryGetValue("requirement:" + i, out StringValues isChecked))
                    {
                        if (isChecked == "on")
                            dto.SubLedgerRequirementAccounts.Add(new COA_SubLedgerRequirement_Account_Dto(_guidGenerator.Create()) { SubLedgerRequirementId = SubLedgerRequirements[i].Id, AccountId = dto.Id });
                    }
                }

                if (form.TryGetValue("allowPosting", out StringValues isAPostingChecked))
                {
                    if (isAPostingChecked == "on")
                        dto.AllowPosting = true;
                    else
                        dto.AllowPosting = false;
                }
                if (dto.AllowPosting && form.TryGetValue("allowPayment", out StringValues isAPChecked))
                {
                    if (isAPChecked == "on")
                        dto.AllowPayment = true;
                    else
                        dto.AllowPayment = false;
                }
                else
                    dto.AllowReceipt = false;
                if (dto.AllowPosting && form.TryGetValue("allowReceipt", out StringValues isARChecked))
                {
                    if (isARChecked == "on")
                        dto.AllowReceipt = true;
                    else
                        dto.AllowReceipt = false;
                }
                else
                    dto.AllowReceipt = false;

                form.TryGetValue("companyCode", out StringValues companyCode);
                companyCode = string.IsNullOrEmpty(companyCode) ? (StringValues)"00" : companyCode;
                form.TryGetValue("headAccCode", out StringValues headAccCode);
                headAccCode = string.IsNullOrEmpty(headAccCode) ? (StringValues)"00" : headAccCode;
                form.TryGetValue("subCat1Code", out StringValues subCat1Code);
                subCat1Code = string.IsNullOrEmpty(subCat1Code) ? (StringValues)"00" : subCat1Code;
                form.TryGetValue("subCat2Code", out StringValues subCat2Code);
                subCat2Code = string.IsNullOrEmpty(subCat2Code) ? (StringValues)"00" : subCat2Code;
                form.TryGetValue("subCat3Code", out StringValues subCat3Code);
                subCat3Code = string.IsNullOrEmpty(subCat3Code) ? (StringValues)"00" : subCat3Code;
                form.TryGetValue("subCat4Code", out StringValues subCat4Code);
                subCat4Code = string.IsNullOrEmpty(subCat4Code) ? (StringValues)"00" : subCat4Code;

                StringValues subLedgerAccountCode = "";
                form.TryGetValue("subLedgerAccountCode", out subLedgerAccountCode);
                subLedgerAccountCode = !string.IsNullOrEmpty(subLedgerAccountCode) ? "." + subLedgerAccountCode : "";

                dto.AccountCode = $"{companyCode}-{headAccCode}{subCat1Code}{subCat2Code}{subCat3Code}{subCat4Code}{subLedgerAccountCode}";

                int maxCode = 0;
                try
                {
                    Convert.ToInt32(_COAsList.Count > 0 ? _COAsList.Where(c => c.HeadAccountId == dto.HeadAccountId && c.AccountSubCatId == dto.AccountSubCatId).Max(c => c.AccountId) : 0);
                }
                catch { }
                dto.AccountId = maxCode + 1;

                //dto.HeadAccount = await _headAccountsAppService.GetAsync(dto.HeadAccountId);
                //dto.AccountSubCategory_1 = await _subCategoryAppService.GetAsync(dto.AccountSubCat1Id);
                //dto.Company = await _companyAppService.GetAsync(dto.CompanyId);
                //if(dto.BranchId.HasValue)
                //    dto.Branch = await _branchAppService.GetAsync(dto.BranchId.Value);

                COA_Account_Dto result = null;
                try
                {
                    result = await _coaAppService.CreateAccount(dto);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (result != null)
                {
                    return RedirectToPage("./COA");
                }
                else
                    return Page();
            }
            catch (Exception ex)
            {
                return Page();
            }
        }

        public JsonResult OnGetStatementDetails(Guid statementType)
        {
            List<AccountStatementType> result = new List<AccountStatementType>();

            result = _accStatementTypeRepo.Where(x => x.ParentId == statementType).ToList();

            return new JsonResult(result);
        }
        public JsonResult OnGetSubCategoriesAndStatementType(Guid headAccount, string headAccountName, Guid parentId, int CLR)
        {
            (List<COA_AccountSubCategory_Dto> result, Guid statementTypeId) result = (new List<COA_AccountSubCategory_Dto>(), Guid.Empty);
            result.result = _subCategoryAppService.GetSubCategories(headAccount, CLR, parentId);

            if (headAccountName == "Assets" || headAccountName == "Liabilities" || headAccountName == "Capital")
            {
                result.statementTypeId = _accStatementTypeRepo.First(x => x.Title == "Balance Sheet").Id;
            }
            else
                result.statementTypeId = _accStatementTypeRepo.First(x => x.Title == "Profit & Loss").Id;

            return new JsonResult(result);
        }
    }
}
