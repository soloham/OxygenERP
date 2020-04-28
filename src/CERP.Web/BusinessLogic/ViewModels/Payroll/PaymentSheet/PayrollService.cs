using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using CERP.Payroll.Payrun;
using CERP.Payroll.DTOs;
using Volo.Abp.Json;
using CERP.HR.EMPLOYEE.RougeDTOs;
using System.Text.Json;

namespace CERP.Web.BusinessLogic.ViewModels.Payroll.PaymentSheet
{
    public class PayrollService 
    {
        public static dynamic GetPaymentSheet(PayrunDetail_Dto curDetail, IJsonSerializer jsonSerializer)
        {
            List<PayrunAllowanceSummary_Dto> payrunAllowances = curDetail.PayrunAllowancesSummaries.ToList();
            PayrunAllowanceSummary_Dto housingAllowance = payrunAllowances.LastOrDefault(x => x.AllowanceType.Value == "Housing");
            string otherAllowancesSum = "" + (payrunAllowances.Sum(x => x.Value) - (housingAllowance == null ? 0 : housingAllowance.Value)).ToString("N2");
            DateTime curPeriod = new DateTime(curDetail.Year, curDetail.Month, 1);

            dynamic paymentSlipDSRow = new ExpandoObject();
            paymentSlipDSRow.payrunId = curDetail.PayrunId;
            paymentSlipDSRow.getEmpRefCode = curDetail.Employee.GetReferenceId;
            paymentSlipDSRow.getEmpName = curDetail.Employee.Name;

            FinancialDetails financialDetails = jsonSerializer.Deserialize<FinancialDetails>(curDetail.Employee.ExtraProperties["financialDetails"].ToString());
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

            return paymentSlipDSRow;
        }
    }
}