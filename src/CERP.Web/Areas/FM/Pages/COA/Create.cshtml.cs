using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CERP.App;
using CERP.FM;
using CERP.FM.COA;
using CERP.FM.COA.DTOs;
using CERP.FM.COA.UV_DTOs;
using CERP.FM.DTOs;
using CERP.FM.UV_DTOs;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using Syncfusion.EJ2.Navigations;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.Web.Areas.FM.Pages.COA
{
    public class CreateModel : CERPPageModel
    {
        [BindProperty]
        public COAInputModel COAInput { get; set; }

        private readonly coaAppService _coaAppService;
        private readonly companyAppService _companyAppService;
        private readonly coaHeadAccountAppService _headAccountsAppService;
        private readonly coaAccountSubCategoryAppService _subCategoryAppService;

        public coaSubLedgerRequirementsAppService _subLedgerRequirementsAppService;
        public IRepository<AccountStatementType, Guid> _accStatementTypeRepo;

        public IRepository<DictionaryValue, Guid> _dictionaryValuesRepo;

        public CreateModel(coaAppService coaAppService, companyAppService companyAppService, coaHeadAccountAppService headAccountsAppService, coaAccountSubCategoryAppService subCategoryAppService, IRepository<COA_SubLedgerRequirement, Guid> subLedgerRequirementsRepo, IRepository<AccountStatementType, Guid> accStatementTypeRepo, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, coaSubLedgerRequirementsAppService subLedgerRequirementsAppService)
        {
            _coaAppService = coaAppService;
            _subCategoryAppService = subCategoryAppService;
            _companyAppService = companyAppService;
            _headAccountsAppService = headAccountsAppService;

            _accStatementTypeRepo = accStatementTypeRepo;
            _dictionaryValuesRepo = dictionaryValuesRepo;
            _subLedgerRequirementsAppService = subLedgerRequirementsAppService;
        }

        public List<Company_Dto> Companies = new List<Company_Dto>();
        public List<Company> Companies_ = new List<Company>();
        public List<COA_HeadAccount_Dto> HeadAccounts = new List<COA_HeadAccount_Dto>();
        public List<COA_AccountSubCategory> SubCategories_ = new List<COA_AccountSubCategory>();
        public List<COA_AccountSubCategory_Dto> SubCategories = new List<COA_AccountSubCategory_Dto>();
        public List<COA_Account_Dto> SubLedgerAccounts = new List<COA_Account_Dto>();

        public List<COA_SubLedgerRequirement_Dto> SubLedgerRequirements = new List<COA_SubLedgerRequirement_Dto>();
        public async Task OnGetAsync()
        {
            Companies = (await _companyAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto())).Items.ToList();
            HeadAccounts = (await _headAccountsAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto())).Items.ToList();
            SubCategories = (await _subCategoryAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto())).Items.ToList();
            SubLedgerAccounts = _coaAppService.GetNonSubLedgerAccounts();
            SubLedgerRequirements = (await _subLedgerRequirementsAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto())).Items.ToList();
        }

        public async Task<IActionResult> OnPost(COA_Account_UV_Dto dto)
        {
            SubLedgerRequirements = (await _subLedgerRequirementsAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto())).Items.ToList();

            var form = Request.Form;
            dto.SubLedgerRequirements = new List<COA_SubLedgerRequirement_Dto>();
            for (int i = 0; i < SubLedgerRequirements.Count; i++)
            {
                if(form.TryGetValue("requirement:" + i, out StringValues isChecked))
                {
                    if(isChecked == "on")
                        dto.SubLedgerRequirements.Add(SubLedgerRequirements[i]);
                    else
                        dto.SubLedgerRequirements.Add(SubLedgerRequirements[i]);
                }
            }

            var result = await _coaAppService.CreateAsync(dto);
            if (result != null)
            {
                return RedirectToPage("/COA");
            }
            else
                return Page();
        }

        public JsonResult OnGetStatementDetails(Guid statementType)
        {
            List<AccountStatementType> result = new List<AccountStatementType>();

            result = _accStatementTypeRepo.Where(x => x.ParentId == statementType).ToList();

            return new JsonResult(result);
        }
        public JsonResult OnGetSubCategories(Guid headAccount)
        {
            List<COA_AccountSubCategory> result = new List<COA_AccountSubCategory>();

            result = _subCategoryAppService.Repository.Where(x => x.HeadAccountId == headAccount).ToList();

            return new JsonResult(result);
        }
    }

    public class COAInputModel
    {
        public string AccountName { get; set; }
        public string AccountNameSL { get; set; }
        public Guid CompanyGuid { get; set; }
        public Guid HeadAccountGuid { get; set; }
        public Guid SubAccountGuid { get; set; }
        public Guid SubLedgerAccountGuid { get; set; }

        public List<(Guid requirementId, bool IsChecked)> SubLedgerRequirements { get; set; }

        public string allowGLPosting { get; set; }
        public string allowAutomatedPosting { get; set; }
        public string allowPayment { get; set; }
        public string allowReceipt { get; set; }

        public Guid StatementTypeId { get; set; }
        public Guid StatementDetailsId { get; set; }
        public Guid CashflowStatementTypeId { get; set; }
    }
}
