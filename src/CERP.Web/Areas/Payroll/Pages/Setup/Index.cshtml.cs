using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CERP.App;
using CERP.AppServices.HR.DepartmentService;
using CERP.AppServices.HR.WorkShiftService;
using CERP.AppServices.Payroll.PayrunService;
using CERP.AppServices.Setup.DepartmentSetup;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Workshifts;
using CERP.Payroll.DTOs;
using CERP.Setup.DTOs;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Grids;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Json;
using CERP.Payroll;
using CERP.Payroll.Payrun;
using CERP.App.Helpers;
using System.Dynamic;
using CERP.HR.Employees.DTOs;
using Newtonsoft.Json;

namespace CERP.Web.Areas.Payroll.Pages.Setup
{
    public class IndexModel : CERPPageModel
    {
        private IRepository<DictionaryValue, Guid> DictionaryValuesRepo;
        private IRepository<SIContributionCategory> ContribCatRepo;
        private IRepository<SIContribution> ContribsRepo;
        private SocialInsuranceAppService SIAppService;

        public List<DictionaryValue_Dto> AllowancesDS = new List<DictionaryValue_Dto>();
        public SISetup_Dto SISetup;
        public IndexModel(IRepository<DictionaryValue, Guid> dictionaryValuesRepo, SocialInsuranceAppService sIAppService, IRepository<SIContribution> sIContributionRepo, IRepository<SIContributionCategory> sIContributionCatRepo)
        {
            DictionaryValuesRepo = dictionaryValuesRepo;
            SIAppService = sIAppService;

            ContribCatRepo = sIContributionCatRepo;
            ContribsRepo = sIContributionRepo;
        }

        public void OnGet()
        {
            AllowancesDS = ObjectMapper.Map<List<DictionaryValue>, List<DictionaryValue_Dto>>(DictionaryValuesRepo.WithDetails().Where(x => x.TenantId == CurrentTenant.Id && x.ValueType.ValueTypeFor == ValueTypeModules.AllowanceType).ToList());
            SISetup = SIAppService.GetSetupWDAsync();
        }

        public string[] GetCategoriesDS()
        {
            List<string> res = new List<string>();

            var setup = SISetup;
            var cats = setup.ContributionCategories.ToList();

            for (int i = 0; i < cats.Count; i++)
            {
                res.Add(cats[i].Title);
            }

            return res.ToArray();
        }
        public JsonResult OnGetCategories()
        {
            JsonResult result = new JsonResult(GetCategoriesDS());
            return result;
        }

        public async Task<IActionResult> OnDeleteCategories(List<SIContributionCategory_Dto> contributions)
        {
            try
            {
                SISetup curSetup = SIAppService.Repository.WithDetails().First();
                for (int i = 0; i < contributions.Count; i++)
                {
                    SIContributionCategory toDelete = await ContribCatRepo.GetAsync(x => x.Id == contributions[i].Id);
                    List<SIContribution> contribs = toDelete.SIContributions.ToList();
                    for (int j = 0; j < toDelete.SIContributions.Count; j++)
                    {
                        await ContribsRepo.DeleteAsync(contribs[j]);
                    }
                    await ContribCatRepo.DeleteAsync(toDelete);
                }
                return new JsonResult(null);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        public IActionResult OnDeletetContributions(SIContributionCategory_Dto contribCat)
        {
            try
            {
                return new JsonResult(null);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> OnPostNewCategory(SIContributionCategory_Dto contribCat)
        {
            try
            {
                contribCat.TenantId = CurrentUser.TenantId;
                contribCat.SetupId = SIAppService.Repository.First().Id;
                var added = await ContribCatRepo.InsertAsync(ObjectMapper.Map<SIContributionCategory_Dto, SIContributionCategory>(contribCat));
                return new JsonResult(added);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> OnPostCategory(SIContributionCategory_Dto contribCat)
        {
            try
            {
                var toUpdate = await ContribCatRepo.FindAsync(x => x.Id == contribCat.Id);
                toUpdate.Title = contribCat.Title;
                toUpdate.IsExpense = contribCat.IsExpense;
                var updated = await ContribCatRepo.UpdateAsync(toUpdate);
                return new JsonResult(updated);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        public IActionResult OnPostNewContribution(SIContribution_Dto contrib, int categoryType)
        {
            try
            {
                return new JsonResult(null);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        public IActionResult OnPostContribution(SIContribution_Dto contrib)
        {
            try
            {
                return new JsonResult(null);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
