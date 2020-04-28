using CERP.App;
using CERP.App.Helpers;
using CERP.AppServices.Payroll.PayrunService;
using CERP.HR.EMPLOYEE.RougeDTOs;
using CERP.Payroll.DTOs;
using CERP.Payroll.Payrun;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Json;

namespace CERP.Web.Areas.Payroll.Pages.PayrunPage
{
    public class PayrunSIModel : CERPPageModel
    {
        [BindProperty(SupportsGet = true)]
        public int? payrunId { get; set; }

        public IJsonSerializer JsonSerializer { get; set; }
        public PayrunAppService PayrunAppService { get; set; }
        public SocialInsuranceSetupAppService SocialInsuranceAppService { get; set; }

        public IRepository<DictionaryValue, Guid> DicValuesRepo { get; set; }

        public List<DictionaryValue> SIAllowances { get; set; }

        public List<SIContributionCategory_Dto> SIContributionCategories;

        public PayrunSIModel(IJsonSerializer jsonSerializer, PayrunAppService payrunAppService, IRepository<DictionaryValue, Guid> dicValuesRepo, SocialInsuranceSetupAppService socialInsuranceAppService)
        {
            JsonSerializer = jsonSerializer;
            PayrunAppService = payrunAppService;
            DicValuesRepo = dicValuesRepo;
            SocialInsuranceAppService = socialInsuranceAppService;
        }

        public async Task<IActionResult> OnPostSocialInsurance(int id)
        {
            try
            {
                Payrun payrun = PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Id == id);
                if (payrun != null && payrun.IsPosted)
                {
                    payrun.IsSIPosted = true;
                    await PayrunAppService.Repository.UpdateAsync(payrun);
                }
                else
                    return StatusCode(500);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        public Payrun_Dto payrun { get; set; }
        public dynamic _dynamicDS;

        public SocialInsuranceReport_Dto GetSIReport(PayrunDetail_Dto detail)
        {
            double upperLimit = SocialInsuranceAppService.GetCurrentSetup().SI_UpperLimit;
            List<PayrunAllowanceSummary_Dto> payrunAllowances = detail.PayrunAllowancesSummaries.Where(x => x.AllowanceType.Dimension_1_Value.ToUpper() == "TRUE").ToList();

            GeneralInfo generalInfo = JsonSerializer.Deserialize<GeneralInfo>(detail.Employee.ExtraProperties["generalInfo"].ToString());
            PhysicalId<Guid> currentPhysicalId = generalInfo.PhysicalIds.Last(x => x.GetIDTypeValue == "Iqama" && x.EndDate <= DateTime.Now);
            string empPhysicalIdNumber = currentPhysicalId.IDNumber;

            SocialInsuranceReport_Dto siDSRow = new SocialInsuranceReport_Dto();
            siDSRow.Payrun = detail.Payrun;
            siDSRow.PayrunId = detail.PayrunId;
            siDSRow.Employee = detail.Employee;
            siDSRow.EmployeeId = detail.EmployeeId;
            siDSRow.EmpID = empPhysicalIdNumber;
            siDSRow.EmpSIId = detail.Employee.SocialInsuranceId;
            double curBasicSalary = (double)detail.BasicSalary;
            siDSRow.BasicSalary = curBasicSalary;

            siDSRow.PayrunDate = new DateTime(detail.Year, detail.Month, detail.CreationTime.Day);
            siDSRow.PayrunSIAllowancesSummaries = payrunAllowances;//payrunAllowances.Select(x => x.a);
            siDSRow.TotalSISalary = (double)siDSRow.PayrunSIAllowancesSummaries.Sum(x => x.Value);
            siDSRow.TotalSISalary += curBasicSalary;
            siDSRow.TotalSISalary = Math.Min(upperLimit, siDSRow.TotalSISalary);

            return siDSRow;
        }

        public IActionResult OnGet()
        {
            SIAllowances = DicValuesRepo.Where(x => x.ValueType.ValueTypeFor == ValueTypeModules.AllowanceType && x.Dimension_2_Value.ToUpper() == "TRUE").ToList();

            payrun = ObjectMapper.Map<Payrun, Payrun_Dto>(PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Id == payrunId));
            SIContributionCategories = ObjectMapper.Map<List<SIContributionCategory>, List<SIContributionCategory_Dto>>(SocialInsuranceAppService.Repository.WithDetails().First().ContributionCategories.ToList());
            if (payrun != null)
            {
                List<PayrunDetail_Dto> payrunDetails = payrun.PayrunDetails.ToList();
                List<dynamic> dynamicDS = new List<dynamic>();

                for (int i = 0; i < payrunDetails.Count; i++)
                {
                    PayrunDetail_Dto curDetail = payrunDetails[i];

                    if (curDetail.Employee.SIType == null || curDetail.Employee.SIType.Value != "Eligible") continue;
                    SocialInsuranceReport_Dto employeeSIReport = GetSIReport(curDetail);

                    dynamic siDSRow = new ExpandoObject();
                    siDSRow.payrunId = employeeSIReport.PayrunId;
                    siDSRow.sNo = i + 1;
                    siDSRow.getEmpName = employeeSIReport.Employee.Name;
                    siDSRow.getEmpIdentityNumber = employeeSIReport.EmpID;
                    siDSRow.getEmpNationality = employeeSIReport.Employee.Nationality.Value;
                    siDSRow.getEmpSIID = employeeSIReport.EmpSIId;
                    siDSRow.getBasicSalary = "" + employeeSIReport.BasicSalary.ToString("N2");

                    foreach (PayrunAllowanceSummary_Dto siAllowance in employeeSIReport.PayrunSIAllowancesSummaries)
                    {
                        DynamicHelper.AddProperty(siDSRow, $"{siAllowance.AllowanceType.Value}_Value", "" + siAllowance.Value.ToString("N2"));
                    }

                    double totalSISalary = employeeSIReport.TotalSISalary;
                    siDSRow.getEmpTotalSalaryForSI = "" + totalSISalary.ToString("N2");

                    List<(string title, double value)> Contributions = new List<(string title, double value)>();
                    foreach (SIContributionCategory_Dto SIC in SIContributionCategories)
                    {
                        foreach (SIContribution_Dto SICC in SIC.SIContributions)
                        {
                            double SICCCV = SICC.IsPercentage ? totalSISalary * (SICC.Value / 100) : SICC.Value;
                            int contribIndex = Contributions.FindIndex(x => x.title == SICC.Title);
                            if (contribIndex != -1) Contributions[contribIndex] = (SICC.Title, Contributions[contribIndex].value + SICCCV); else Contributions.Add((SICC.Title, SICCCV));
                            DynamicHelper.AddProperty(siDSRow, $"{SIC.Title}_{SICC.Title}_Value", $"{SICCCV.ToString("N2")}");
                        }
                    }

                    foreach ((string title, double value) SICC in Contributions)
                    {
                        List<SIContribution_Dto> sIContributions = SIContributionCategories.SelectMany(x => x.SIContributions).ToList();
                        DynamicHelper.AddProperty(siDSRow, $"Overall_{SICC.title}_Value", $"{SICC.value.ToString("N2")}");
                    }

                    siDSRow.month = curDetail.Month;
                    siDSRow.year = curDetail.Year;

                    dynamicDS.Add(siDSRow);
                }

                //JsonResult eosbDSJson = new JsonResult(dynamicDS);

                _dynamicDS = new ExpandoObject();
                _dynamicDS.SIDS = JsonSerializer.Serialize(dynamicDS);
                _dynamicDS.month = payrun.Month;
                _dynamicDS.year = payrun.Year;
                _dynamicDS.isPosted = payrun.IsSIPosted;
            }
            return Page();
        }
    }
}
