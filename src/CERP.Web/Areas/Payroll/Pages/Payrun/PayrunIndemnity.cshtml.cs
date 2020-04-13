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
    public class PayrunIndemnityModel : CERPPageModel
    {
        [BindProperty(SupportsGet = true)]
        public int? payrunId { get; set; }

        public IJsonSerializer JsonSerializer { get; set; }
        public PayrunAppService PayrunAppService { get; set; }

        public IRepository<DictionaryValue, Guid> DicValuesRepo { get; set; }


        public PayrunIndemnityModel(IJsonSerializer jsonSerializer, PayrunAppService payrunAppService, IRepository<DictionaryValue, Guid> dicValuesRepo)
        {
            JsonSerializer = jsonSerializer;
            PayrunAppService = payrunAppService;
            DicValuesRepo = dicValuesRepo;
        }
        public async Task<IActionResult> OnPostIndemnity(string indemnitiesDS, int payrunId)
        {
            try
            {
                var indemnitiesToPost = JsonSerializer.Deserialize<List<PayrunDetailIndemnity>>(indemnitiesDS);
                Payrun payrun = PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Id == payrunId);
                PayrunDetail[] payrunDetails = payrun.PayrunDetails.ToArray();
                for (int i = 0; i < payrunDetails.Length; i++)
                {
                    try
                    {
                        PayrunDetail detail = payrunDetails[i];
                        PayrunDetailIndemnity detailIndemnity = indemnitiesToPost.First(x => x.PayrunDetailId == detail.Id);
                        detailIndemnity.TenantId = CurrentTenant.Id;
                        detail.Indemnity = detailIndemnity;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                if (payrun != null && payrun.IsPosted)
                {
                    payrun.IsIndemnityPosted = true;
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

        public List<DictionaryValue> EOSBAllowances;
        public IActionResult OnGet()
        {
            EOSBAllowances = DicValuesRepo.Where(x => x.ValueType.ValueTypeFor == ValueTypeModules.AllowanceType && x.Dimension_1_Value.ToUpper() == "TRUE").ToList();

            payrun = ObjectMapper.Map<Payrun, Payrun_Dto>(PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Id == payrunId));
            Payrun_Dto payrunLast = ObjectMapper.Map<Payrun, Payrun_Dto>(PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Month == payrun.Month - 1 && x.Year == payrun.Year));
            if (payrun != null)
            {
                List<PayrunDetail_Dto> payrunDetails = payrun.PayrunDetails.ToList();
                List<dynamic> dynamicDS = new List<dynamic>();

                for (int i = 0; i < payrunDetails.Count; i++)
                {
                    PayrunDetail_Dto curDetail = payrunDetails[i];
                    if (curDetail.Employee.IndemnityType == null || curDetail.Employee.IndemnityType.Value != "Eligible") continue;
                    PayrunDetailIndemnity_Dto employeeIndemnity = null;
                    if (curDetail.Indemnity != null)
                        employeeIndemnity = curDetail.Indemnity;
                    else
                        employeeIndemnity = curDetail.GetIndemnity();

                    PayrunDetail_Dto curDetailLast = payrunLast == null ? null : payrunLast.PayrunDetails.FirstOrDefault(x => x.EmployeeId == curDetail.EmployeeId);
                    PayrunDetailIndemnity_Dto employeeIndemnityLast = curDetailLast != null ? curDetailLast.GetIndemnity() : null;
                    if (employeeIndemnityLast != null)
                    {
                        employeeIndemnity.LastMonthEOSB = employeeIndemnityLast.TotalEOSB;
                        employeeIndemnity.Difference = employeeIndemnity.LastMonthEOSB - employeeIndemnity.TotalEOSB;
                    }

                    dynamic indemnityDSRow = new ExpandoObject();
                    indemnityDSRow.payrunId = payrunId;
                    indemnityDSRow.sNo = i + 1;
                    indemnityDSRow.Id = employeeIndemnity.Id;
                    indemnityDSRow.EmployeeId = employeeIndemnity.EmployeeId;
                    indemnityDSRow.getEmpRefCode = employeeIndemnity.Employee.GetReferenceId;
                    indemnityDSRow.getEmpName = employeeIndemnity.Employee.Name;
                    indemnityDSRow.getEmpDepartment = employeeIndemnity.Employee.Department.Name;
                    indemnityDSRow.getEmpDOJ = employeeIndemnity.Employee.JoiningDate;
                    indemnityDSRow.BasicSalary = "" + employeeIndemnity.BasicSalary.ToString("N2");

                    foreach (PayrunAllowanceSummary_Dto eosbAllowance in employeeIndemnity.PayrunEOSBAllowancesSummaries)
                    {
                        DynamicHelper.AddProperty(indemnityDSRow, $"{eosbAllowance.AllowanceType.Value}_Value", "" + eosbAllowance.Value.ToString("N2"));
                    }

                    indemnityDSRow.GrossSalary = "" + employeeIndemnity.GrossSalary.ToString("N2");
                    indemnityDSRow.TotalEmploymentDays = employeeIndemnity.TotalEmploymentDays;
                    indemnityDSRow.TotalPre5EmploymentDays = employeeIndemnity.TotalPre5EmploymentDays;
                    indemnityDSRow.TotalPost5EmploymentDays = employeeIndemnity.TotalPost5EmploymentDays;
                    indemnityDSRow.TotalEOSB = "" + employeeIndemnity.TotalEOSB.ToString("N2");
                    indemnityDSRow.LastMonthEOSB = "" + employeeIndemnity.LastMonthEOSB.ToString("N2");
                    indemnityDSRow.ActuarialEvaluation = "" + employeeIndemnity.ActuarialEvaluation.ToString("N2");
                    indemnityDSRow.Difference = "" + employeeIndemnity.Difference.ToString("N2");
                    indemnityDSRow.PayrunDetailId = curDetail.Id;

                    indemnityDSRow.month = curDetail.Month;
                    indemnityDSRow.year = curDetail.Year;

                    dynamicDS.Add(indemnityDSRow);
                }

                //JsonResult eosbDSJson = new JsonResult(dynamicDS);

                _dynamicDS = new ExpandoObject();
                _dynamicDS.EOSBDS = JsonSerializer.Serialize(dynamicDS);
                _dynamicDS.month = payrun.Month;
                _dynamicDS.year = payrun.Year;
                _dynamicDS.isPosted = payrun.IsIndemnityPosted;
            }
            return Page();
        }
    }
}
