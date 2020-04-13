


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
    public class PaymentSheetModel : CERPPageModel
    {
        [BindProperty(SupportsGet = true)]
        public int? payrunId { get; set; }

        public IJsonSerializer JsonSerializer { get; set; }
        public PayrunAppService PayrunAppService { get; set; }

        public IRepository<DictionaryValue, Guid> DicValuesRepo { get; set; }


        public PaymentSheetModel(IJsonSerializer jsonSerializer, PayrunAppService payrunAppService, IRepository<DictionaryValue, Guid> dicValuesRepo)
        {
            JsonSerializer = jsonSerializer;
            PayrunAppService = payrunAppService;
            DicValuesRepo = dicValuesRepo;
        }

        public async Task<IActionResult> OnPostPaymentSheet(int id)
        {
            try
            {
                Payrun payrun = PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Id == id);
                if (payrun != null && payrun.IsPosted)
                {
                    payrun.IsPSPosted = true;
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

        public Payrun payrun { get; set; }
        public List<dynamic> dynamicDS = new List<dynamic>();
        public string dynamicDSS;
        public IActionResult OnGet()
        {
            payrun = PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Id == payrunId);
            if (payrun != null)
            {
                List<PayrunDetail> payrunDetails = payrun.PayrunDetails.ToList();

                for (int i = 0; i < payrunDetails.Count; i++)
                {
                    PayrunDetail curDetail = payrunDetails[i];
                    List<PayrunAllowanceSummary> payrunAllowances = curDetail.PayrunAllowancesSummaries.ToList();
                    PayrunAllowanceSummary housingAllowance = payrunAllowances.LastOrDefault(x => x.AllowanceType.Value == "Housing");
                    string otherAllowancesSum = "" + (payrunAllowances.Sum(x => x.Value) - (housingAllowance == null ? 0 : housingAllowance.Value)).ToString("N2");
                    DateTime curPeriod = new DateTime(curDetail.Year, curDetail.Month, 1);

                    dynamic paymentSlipDSRow = new ExpandoObject();
                    paymentSlipDSRow.payrunId = payrunId;
                    paymentSlipDSRow.sNo = i + 1;
                    paymentSlipDSRow.getEmpRefCode = curDetail.Employee.GetReferenceId;
                    paymentSlipDSRow.getEmpName = curDetail.Employee.Name;

                    FinancialDetails financialDetails = JsonSerializer.Deserialize<FinancialDetails>(curDetail.Employee.ExtraProperties["financialDetails"].ToString());
                    BanksRDTO curBank = financialDetails.Banks.Last();//financialDetails.Banks.SingleOrDefault(x => DateTime.Parse(x.FromDate).Month >= curPeriod.Month && DateTime.Parse(x.ToDate).Month <= curPeriod.Month);
                    paymentSlipDSRow.getBankName = curBank.GetBankName;
                    paymentSlipDSRow.getBankIBAN = curBank.BankIBAN;

                    paymentSlipDSRow.getBasicSalary = "" + curDetail.BasicSalary.ToString("N2");
                    paymentSlipDSRow.getAllowanceHousing = housingAllowance == null ? "—" : "" + housingAllowance.Value.ToString("N2");
                    paymentSlipDSRow.getOtherIncome = otherAllowancesSum;
                    paymentSlipDSRow.getDeductions = "" + curDetail.GrossDeductions.ToString("N2");
                    paymentSlipDSRow.getPayment = "" + curDetail.NetAmount.ToString("N2");

                    paymentSlipDSRow.month = curDetail.Month;
                    paymentSlipDSRow.year = curDetail.Year;
                    paymentSlipDSRow.isPosted = payrun.IsPSPosted;
                    dynamicDS.Add(paymentSlipDSRow);
                    dynamicDSS = JsonSerializer.Serialize(dynamicDS);
                }
            }
            return Page();
        }
    }
}
