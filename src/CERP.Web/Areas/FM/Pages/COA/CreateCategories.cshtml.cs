using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CERP.App;
using CERP.AppServices.Setup.CompanySetup;
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
using Volo.Abp.Guids;

namespace CERP.Web.Areas.FM.Pages.COA
{
    public class CreateCategoryModel : CERPPageModel
    {
        [BindProperty]
        public COA_AccountSubCategory_UV_Dto COASubCatInput { get; set; }

        private readonly CompanyAppService _companyAppService;
        private readonly coaHeadAccountAppService _headAccountsAppService;
        private readonly coaAccountSubCategoryAppService _subCategoryAppService;

        public IRepository<DictionaryValue, Guid> _dictionaryValuesRepo;

        private IGuidGenerator _guidGenerator;


        public List<Company_Dto> Companies = new List<Company_Dto>();
        public List<Branch_Dto> Branches = new List<Branch_Dto>();
        public List<COA_HeadAccount_Dto> HeadAccounts = new List<COA_HeadAccount_Dto>();
        public List<COA_AccountSubCategory_Dto> SubCategories = new List<COA_AccountSubCategory_Dto>();
        public List<COA_Account_Dto> SubLedgerAccounts = new List<COA_Account_Dto>();

        public CreateCategoryModel(CompanyAppService CompanyAppService, coaHeadAccountAppService headAccountsAppService, coaAccountSubCategoryAppService subCategoryAppService, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IGuidGenerator guidGenerator)
        {
            _companyAppService = CompanyAppService;
            _headAccountsAppService = headAccountsAppService;
            _subCategoryAppService = subCategoryAppService;
            _dictionaryValuesRepo = dictionaryValuesRepo;
            _guidGenerator = guidGenerator;
        }

        public async Task OnGetAsync()
        {
            Companies = (await _companyAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 1000 })).Items.ToList();
            HeadAccounts = (await _headAccountsAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 1000 })).Items.ToList();
            SubCategories = (await _subCategoryAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 1000 })).Items.ToList();
        }

        public async Task<IActionResult> OnPost(COA_AccountSubCategory_UV_Dto dto)
        {
            dto.Id = _guidGenerator.Create();
            SubCategories = (await _subCategoryAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 1000 })).Items.ToList();
            try
            {
                var form = Request.Form;

                form.TryGetValue("headAccCode", out StringValues headAccCode);
                headAccCode = string.IsNullOrEmpty(headAccCode) ? (StringValues)"0" : headAccCode;

                if (dto.CLI == AccountCLI.SubHeader)
                {
                    int maxSubHeaderCode = 0;
                    try
                    {
                        maxSubHeaderCode = Convert.ToInt32(SubCategories.Count > 0 ? SubCategories.Where(c => c.HeadAccountId == dto.HeadAccountId && c.CLI == AccountCLI.SubHeader).Max(c => c.SubCategoryId) : 0);
                    }
                    catch { }
                    dto.SubCategoryId = maxSubHeaderCode + 1;
                }
                else
                {
                    form.TryGetValue("parentCatId", out StringValues parentCatId);
                    try
                    {
                        int _parentCatId = Convert.ToInt32(parentCatId);
                        dto.SubCategoryId = int.Parse(parentCatId);
                        dto.SubCategoryId = int.Parse(parentCatId);
                    }
                    catch {
                        dto.SubCategoryId = 0;
                    }

                    int maxGroupCode = 0;
                    try
                    {
                        maxGroupCode = Convert.ToInt32(SubCategories.Count > 0 ? SubCategories.Where(c => c.ParentId == dto.ParentId && c.CLI == AccountCLI.Group).Max(c => c.GroupCategoryId) : 0);
                    }
                    catch { }

                    dto.GroupCategoryId = maxGroupCode + 1;
                }
                dto.SubCategoryCode = $"{headAccCode}{dto.SubCategoryId}{dto.GroupCategoryId}";

                COA_AccountSubCategory_Dto result = null;
                try
                {
                    result = await _subCategoryAppService.CreateCategory(dto);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (result != null)
                {
                    return Redirect(Url.Content("~") + "/COA/Categories");
                }
                else
                    return Page();
            }
            catch (Exception ex)
            {
                return Page();
            }
        }

        public JsonResult OnGetSubCategories(Guid headAccount, Guid parentId, int CLI)
        {
            List<COA_AccountSubCategory_Dto> result = new List<COA_AccountSubCategory_Dto>(); 
            result = _subCategoryAppService.GetSubCategories(headAccount, CLI, parentId);

            return new JsonResult(result);
        }
    }
}
