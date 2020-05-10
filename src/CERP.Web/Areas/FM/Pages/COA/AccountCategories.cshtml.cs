using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CERP.AppServices.Setup.CompanySetup;
using CERP.FM.COA;
using CERP.FM.COA.DTOs;
using CERP.FM.DTOs;
using CERP.Web.Pages;
using Syncfusion.EJ2.Grids;
using Volo.Abp.Guids;

namespace CERP.Web.Areas.FM.Pages.COA.Categories
{
    public class AccountCategoriesModel : CERPPageModel
    {
        private readonly IGuidGenerator _guidGenerator;
        private coaAccountSubCategoryAppService _subCategoryAppService;
        private readonly CompanyAppService _companyAppService;
        private readonly coaHeadAccountAppService _headAccountsAppService;
        public AccountCategoriesModel(coaAccountSubCategoryAppService coaAccountSubCategoryAppService, IGuidGenerator guidGenerator, CompanyAppService CompanyAppService, coaHeadAccountAppService headAccountsAppService)
        {
            _subCategoryAppService = coaAccountSubCategoryAppService;
            _guidGenerator = guidGenerator;
            _companyAppService = CompanyAppService;
            _headAccountsAppService = headAccountsAppService;
        }

        public List<Company_Dto> Companies = new List<Company_Dto>();
        public List<COA_HeadAccount_Dto> HeadAccounts = new List<COA_HeadAccount_Dto>();
        public List<COA_AccountSubCategory_Dto> SubCategories = new List<COA_AccountSubCategory_Dto>();

        public async Task OnGetAsync()
        {
            Companies = (await _companyAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 1000 })).Items.ToList();
            HeadAccounts = (await _headAccountsAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 1000 })).Items.ToList();
            SubCategories = (await _subCategoryAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 1000 })).Items.ToList();

            List<COA_AccountSubCategory_Dto> subCats = _subCategoryAppService.GetDetailedList();

            foreach (COA_AccountSubCategory_Dto subCategory_Dto in subCats)
            {
                if (subCategory_Dto.ParentId.HasValue)
                {
                    Guid pId = subCategory_Dto.ParentId.Value;
                    subCategory_Dto.ParentCategory = await _subCategoryAppService.GetAsync(pId);
                    subCategory_Dto.ParentCategoryTitle = subCategory_Dto.ParentCategory.Title;
                }
                else
                    subCategory_Dto.ParentCategoryTitle = "—";
            }

            ViewData["Categories_DS"] = subCats;
        }

        public List<GridColumn> GetGridColumns()
        {
            List<GridColumn> result = new List<GridColumn>()
            {
                new GridColumn { Field = "Company.Name", Width = "130", HeaderText = "Company",  TextAlign= TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "HeadAccount.AccountName", Width = "130", HeaderText = "Header Account",  TextAlign= TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "Title", Width = "150", HeaderText = "Title",  TextAlign= TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "LocalizationKey", Width = "150", HeaderText = "Title in AR",  TextAlign= TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "CLI_Name", Width = "100", HeaderText = "Category Type",  TextAlign= TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "SubCategoryCode", Width = "100", HeaderText = "Category Code",  TextAlign= TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "ParentCategoryTitle", Width = "100", DefaultValue = "—", HeaderText = "Parent Category",  TextAlign= TextAlign.Center,  MinWidth="10"  },
            };

            return result;
        }
    }
}
