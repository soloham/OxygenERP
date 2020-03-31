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
        public SISetup SISetup;
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
            SISetup = SIAppService.GetEntitySetupWDAsync();
        }

        public async Task<IActionResult> OnPostUpperLimit(double limit)
        {
            try
            {
                var sISetup = SIAppService.Repository.First();
                sISetup.SI_UpperLimit = limit;
                sISetup.TenantId = CurrentTenant.Id;
                var result = await SIAppService.Repository.UpdateAsync(sISetup);

                return new JsonResult(result.SI_UpperLimit.ToString("N2"));
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
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
        public JsonResult GetContributionCatsDS()
        {
            List<dynamic> res = new List<dynamic>();

            var setup = SISetup;
            var contribCats = setup.ContributionCategories.ToList();

            for (int i = 0; i < contribCats.Count; i++)
            {
                dynamic contribCatVM = new ExpandoObject();
                contribCatVM.Id = contribCats[i].Id;
                contribCatVM.Title = contribCats[i].Title;
                contribCatVM.IsExpense = contribCats[i].IsExpense;
                res.Add(contribCatVM);
            }

            return new JsonResult(res.ToArray());
        }
        public JsonResult OnGetContributionCatsDS()
        {
            JsonResult result = GetContributionCatsDS();
            return result;
        }
        
        public JsonResult GetContributionsDS()
        {
            List<dynamic> res = new List<dynamic>();

            var setup = SISetup;
            var contribs = setup.ContributionCategories.SelectMany(x => x.SIContributions).ToList();

            for (int i = 0; i < contribs.Count; i++)
            {
                dynamic contribVM = new ExpandoObject();
                contribVM.Id = contribs[i].Id;
                contribVM.Title = contribs[i].Title;
                contribVM.Value = contribs[i].Value;
                contribVM.IsPercentage = contribs[i].IsPercentage;
                contribVM.CategoryTitle = contribs[i].SICategory.Title;
                res.Add(contribVM);
            }

            return new JsonResult(res.ToArray());
        }
        public JsonResult OnGetContributions()
        {
            JsonResult result = GetContributionsDS();
            return result;
        }

        public async Task<IActionResult> OnDeleteCategories(List<SIContributionCategory_Dto> categories)
        {
            try
            {
                for (int i = 0; i < categories.Count; i++)
                {
                    SIContributionCategory toDelete = ContribCatRepo.WithDetails().First(x => x.Id == categories[i].Id);
                    List<SIContribution> contribs = toDelete.SIContributions.ToList();
                    for (int j = 0; j < toDelete.SIContributions.Count; j++)
                    {
                        await ContribsRepo.DeleteAsync(contribs[j]);
                    }
                    await ContribCatRepo.DeleteAsync(toDelete);
                }
                
                return new JsonResult(GetCategoriesDS());
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> OnDeleteContributions(List<SIContribution_Dto> contribs)
        {
            try
            {
                for (int i = 0; i < contribs.Count; i++)
                {
                    await ContribsRepo.DeleteAsync(x => x.Id == contribs[i].Id);
                }
                return new OkResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> OnDeleteAllowances(List<DictionaryValue_Dto> allowances)
        {
            try
            {
                for (int i = 0; i < allowances.Count; i++)
                {
                    await DictionaryValuesRepo.DeleteAsync(x => x.Id == allowances[i].Id);
                }
                return new OkResult();
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

        public async Task<IActionResult> OnPostNewContribution(SIContribution_Dto contrib, string categoryName)
        {
            try
            {
                contrib.TenantId = CurrentUser.TenantId;
                contrib.SICategoryId = ContribCatRepo.First(x => x.Title == categoryName).Id;
                var added = await ContribsRepo.InsertAsync(ObjectMapper.Map<SIContribution_Dto, SIContribution>(contrib));
                return new JsonResult(added);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> OnPostContribution(SIContribution_Dto contrib, string categoryName)
        {
            try
            {
                var toUpdate = await ContribsRepo.FindAsync(x => x.Id == contrib.Id);
                toUpdate.Title = contrib.Title;
                toUpdate.IsPercentage = contrib.IsPercentage;
                toUpdate.Value = contrib.Value;
                toUpdate.SICategoryId = ContribCatRepo.First(x => x.Title == categoryName).Id;
                toUpdate.SICategory = null;
                var updated = await ContribsRepo.UpdateAsync(toUpdate);
                return new JsonResult(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> OnPostNewAllowance(DictionaryValue_Dto allowance)
        {
            try
            {
                allowance.TenantId = CurrentUser.TenantId;
                var added = await DictionaryValuesRepo.InsertAsync(ObjectMapper.Map<DictionaryValue_Dto, DictionaryValue>(allowance));
                return new JsonResult(added);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> OnPostAllowance(DictionaryValue_Dto allowance)
        {
            try
            {
                var toUpdate = await DictionaryValuesRepo.FindAsync(x => x.Id == allowance.Id);
                toUpdate.Value = allowance.Value;
                toUpdate.Dimension_1_Value = allowance.Dimension_1_Value;
                toUpdate.Dimension_2_Value = allowance.Dimension_2_Value;
                var updated = await DictionaryValuesRepo.UpdateAsync(toUpdate);
                return new JsonResult(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
