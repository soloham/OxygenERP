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
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Json;

namespace CERP.Web.Areas.Payroll.Pages.PayrunPage
{
    public class ListModel : CERPPageModel
    {
        public IJsonSerializer JsonSerializer { get; set; }
        public PayrunAppService PayrunAppService { get; set; }
        public SocialInsuranceAppService SocialInsuranceAppService { get; set; }

        public IRepository<DictionaryValue, Guid> DicValuesRepo { get; set; }
        public List<DictionaryValue> Allowances { get; set; }

        public Grid SecondaryDetailsGrid { get; set; }

        public ListModel(IJsonSerializer jsonSerializer, PayrunAppService payrunAppService, IRepository<DictionaryValue, Guid> dicValuesRepo, SocialInsuranceAppService socialInsuranceAppService)
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
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> OnPostIndemnity(string indemnitiesDS, int payrunId)
        {
            try
            {
                var indemnitiesToPost =  JsonSerializer.Deserialize<List<PayrunDetailIndemnity>>(indemnitiesDS);
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
                    catch(Exception ex)
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
            catch(Exception ex)
            {
                return StatusCode(500);
            }
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
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        public void OnGet()
        {
            Allowances = DicValuesRepo.Where(x => x.ValueType.ValueTypeFor == ValueTypeModules.AllowanceType).ToList();
            List<Payrun_Dto> payruns = ObjectMapper.Map<List<Payrun>, List<Payrun_Dto>>(PayrunAppService.Repository.WithDetails().ToList());
            ViewData["Payruns_DS"] = JsonSerializer.Serialize(payruns);

            List<dynamic> payrunSummaryDynamicDS = new List<dynamic>();

            for (int i = 0; i < payruns.Count; i++)
            {
                dynamic payrunSummaryDDSRow = new ExpandoObject();
                payrunSummaryDDSRow.id = payruns[i].Id;

                List<PayrunDetail_Dto> payrunDetails = payruns[i].PayrunDetails.ToList();

                payrunSummaryDDSRow.totalEmployees = payrunDetails.Count;

                payrunSummaryDDSRow.getBasicSalaries = payrunDetails.Sum(x => x.BasicSalary);
                foreach (PayrunAllowanceSummary_Dto allowanceSummary in payrunDetails[0].PayrunAllowancesSummaries)
                {
                    DictionaryValue_Dto allowance = allowanceSummary.AllowanceType;
                    string camelCaseName = allowance.Value;
                    camelCaseName = camelCaseName.Replace(" ", "");
                    camelCaseName = char.ToLowerInvariant(camelCaseName[0]) + camelCaseName.Substring(1);

                    DynamicHelper.AddProperty(payrunSummaryDDSRow, $"{camelCaseName}_Value", payrunDetails.Sum(x => x.PayrunAllowancesSummaries.Sum(x1 => x1.Value)));
                }

                payrunSummaryDDSRow.gosiValue = payrunDetails.Sum(x => x.GOSIAmount);
                payrunSummaryDDSRow.loansValue = payrunDetails.Sum(x => x.Loan);
                payrunSummaryDDSRow.leavesValue = payrunDetails.Sum(x => x.Leaves);
                payrunSummaryDDSRow.grossDeductions = payrunDetails.Sum(x => x.GrossDeductions);

                payrunSummaryDynamicDS.Add(payrunSummaryDDSRow);
            }
            SecondaryDetailsGrid = new Grid()
            {
                DataSource = payrunSummaryDynamicDS,
                QueryCellInfo = "QueryCellInfo",
                QueryString = "id",
                EditSettings = new Syncfusion.EJ2.Grids.GridEditSettings() { },
                AllowExcelExport = true,
                //AllowGrouping = true,
                AllowPdfExport = true,
                HierarchyPrintMode = HierarchyGridPrintMode.All,
                AllowSelection = true,
                AllowFiltering = false,
                AllowSorting = true,
                AllowMultiSorting = true,
                AllowResizing = true,
                GridLines = GridLine.Both,
                SearchSettings = new GridSearchSettings() { },
                //Toolbar = new List<object>() { "ExcelExport", "CsvExport", "Print", "Search",new { text = "Copy", tooltipText = "Copy", prefixIcon = "e-copy", id = "copy" }, new { text = "Copy With Header", tooltipText = "Copy With Header", prefixIcon = "e-copy", id = "copyHeader" } },
                Columns = GetSecondaryGridColumns()
            };
        }
        public IActionResult OnGetPaymentsSheet(int payrunId)
        {
            Payrun payrun = PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Id == payrunId);
            if (payrun != null)
            {
                List<PayrunDetail> payrunDetails = payrun.PayrunDetails.ToList();
                List<dynamic> dynamicDS = new List<dynamic>();

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
                }

                return new JsonResult(dynamicDS);
            }
            return StatusCode(500);
        }

        public dynamic GetIndemnityModel()
        {
            dynamic Model = new ExpandoObject();
            Model.EOSBAllowances = Allowances.Where(x => x.Dimension_1_Value.ToUpper() == "TRUE").ToList();
            Model.EOSBDS = null;
            return Model;
        }
        public IActionResult OnGetIndemnitySheet(int payrunId)
        {
            Payrun_Dto payrun = ObjectMapper.Map<Payrun, Payrun_Dto>(PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Id == payrunId));
            Payrun_Dto payrunLast = ObjectMapper.Map<Payrun, Payrun_Dto>(PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Month == payrun.Month-1 && x.Year == payrun.Year));
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

                    PayrunDetail_Dto curDetailLast = payrunLast == null? null : payrunLast.PayrunDetails.FirstOrDefault(x => x.EmployeeId == curDetail.EmployeeId);
                    PayrunDetailIndemnity_Dto employeeIndemnityLast = curDetailLast != null? curDetailLast.GetIndemnity() : null;
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

                dynamic Model = new ExpandoObject();
                Model.EOSBDS = dynamicDS;
                Model.month = payrun.Month;
                Model.year = payrun.Year;
                Model.isPosted = payrun.IsIndemnityPosted;
                return new JsonResult(Model);
            }
            return StatusCode(500);
        }

        public dynamic GetSIReportModel()
        {
            dynamic Model = new ExpandoObject();

            List<SIContributionCategory_Dto> SIContributionCategories = Model.SIContributionCategories; Model.SIContributionCategories = SIContributionCategories;
            Model.SIAllowances = Allowances.Where(x => x.Dimension_2_Value.ToUpper() == "TRUE").ToList();
            Model.SIDS = null;
            return Model;
        }
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

        public IActionResult OnGetSIReport(int payrunId)
        {
            Payrun_Dto payrun = ObjectMapper.Map<Payrun, Payrun_Dto>(PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Id == payrunId));
            List<SIContributionCategory_Dto> SIContributionCategories = ObjectMapper.Map<List<SIContributionCategory>, List<SIContributionCategory_Dto>>(SocialInsuranceAppService.Repository.WithDetails().First().ContributionCategories.ToList());
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

                dynamic Model = new ExpandoObject();
                Model.SIDS = dynamicDS;
                Model.month = payrun.Month;
                Model.year = payrun.Year;
                Model.isPosted = payrun.IsSIPosted;
                return new JsonResult(Model);
            }
            return StatusCode(500);
        }
        public async Task<IActionResult> OnDeletePayrun(int month, int year)
        {
            Payrun payrun = PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Month == month && x.Year == year);
            if (payrun != null && payrun.IsPosted == false)
            {
                List<PayrunDetail> details = payrun.PayrunDetails.ToList();
                for (int i = 0; i < details.Count; i++)
                {
                    List<PayrunAllowanceSummary> allowanceSummaries = details[i].PayrunAllowancesSummaries.ToList();
                    for (int j = 0; j < allowanceSummaries.Count; j++)
                    {
                        await PayrunAppService.PayrunAllowanceSummaryRepo.DeleteAsync(allowanceSummaries[j].Id);
                    }
                    await PayrunAppService.PayrunDetailsRepo.DeleteAsync(details[i].Id);
                }
                await PayrunAppService.Repository.DeleteAsync(payrun.Id);

                return new OkResult();
            }
            else
                return StatusCode(500);
        }

        public List<GridColumn> GetCommandsColumns()
        {
            List<object> commands = new List<object>();
            commands.Add(new { type = "View", buttonOption = new { iconCss = "zmdi zmdi-search", cssClass = "e-flat e-ViewButton" } });
            commands.Add(new { type = "View Reconciliation", buttonOption = new { iconCss = "zmdi zmdi-assignment-alert", cssClass = "e-flat e-View-Reconciliation-Button" } });
            commands.Add(new { type = "View Payments Sheet", buttonOption = new { iconCss = "zmdi zmdi-receipt", cssClass = "e-flat e-View-Payments-Sheet-Button" } });
            commands.Add(new { type = "View Indemnity", buttonOption = new { iconCss = "zmdi zmdi-case", cssClass = "e-flat e-Gen-Indemnity-Button" } });
            commands.Add(new { type = "View GOSI Report", buttonOption = new { iconCss = "e-icons e-gosi-report", cssClass = "e-flat e-View-GOSI-Button" } });
            commands.Add(new { type = "View Attachment", buttonOption = new { iconCss = "zmdi zmdi-attachment-alt", cssClass = "e-flat e-View-Attach-Button" } });
            commands.Add(new { type = "Edit", buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat e-EditButton" } });
            commands.Add(new { type = "Delete", buttonOption = new { iconCss = "e-icons e-delete", cssClass = "e-flat e-DeleteButton" } });
            //commands.Add(new { type = "Save", buttonOption = new { iconCss = "e-icons e-update", cssClass = "e-flat" } });
            //commands.Add(new { type = "Cancel", buttonOption = new { iconCss = "e-icons e-cancel-icon", cssClass = "e-flat" } });

            return new List<GridColumn>()
            {
                new GridColumn { Width = "200", HeaderText = "Actions", TextAlign=TextAlign.Center, MinWidth="10", Commands = commands }
            };
        }
        public List<GridColumn> GetPrimaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>() {
                new GridColumn { Field = "company.name", Width = "100", HeaderText = "Company", TextAlign=TextAlign.Center,  MinWidth="10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "year", Width = "100", HeaderText = "Year", TextAlign=TextAlign.Center,  MinWidth="10",  CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "getMonth", HeaderText = "Month", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "totalEarnings", HeaderText = "Earnings", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "totalDeductions", HeaderText = "Deductions", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "netTotal", HeaderText = "Net Total", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "note", HeaderText = "Note", TextAlign=TextAlign.Center,  MinWidth="10",  CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "isPosted", Width = "65", DisplayAsCheckBox = true, HeaderText = "Is Posted", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "postedDate", HeaderText = "Posted Date", Type="Date", Format="E, MMMM d, y", TextAlign=TextAlign.Center,  MinWidth="10",  CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "postedByTemp", HeaderText = "Posted By", TextAlign=TextAlign.Center,  MinWidth="10",  CustomAttributes=new {id="detailed"}  },
            };

            gridColumns.AddRange(GetCommandsColumns());

            return gridColumns;
        }
        public List<GridColumn> GetSecondaryGridColumns()
        {
            Allowances = DicValuesRepo.WithDetails(x => x.ValueType).Where(x => x.ValueType.ValueTypeFor == ValueTypeModules.AllowanceType).ToList();

            List<GridColumn> earningsColumns = new List<GridColumn>();

            earningsColumns.Add(new GridColumn { Field = "getBasicSalaries", HeaderText = "Basic Salary", TextAlign = TextAlign.Center, MinWidth = "40" });
            for (int i = 0; i < Allowances.Count; i++)
            {
                DictionaryValue allowance = Allowances[i];
                string camelCaseName = allowance.Value;
                camelCaseName = camelCaseName.Replace(" ", "");
                camelCaseName = char.ToLowerInvariant(camelCaseName[0]) + camelCaseName.Substring(1);

                earningsColumns.Add(new GridColumn() { Field = $"{camelCaseName}_Value", HeaderText = $"{Allowances[i].Value}", TextAlign = TextAlign.Center, MinWidth = "50" });
            }

            List<GridColumn> deductionsColumns = new List<GridColumn>()
            {
                new GridColumn() { Field = "gosiValue", HeaderText = "GOSI", TextAlign = TextAlign.Center, MinWidth = "50" },
                new GridColumn() { Field = "loansValue", HeaderText = "Loans", TextAlign = TextAlign.Center, MinWidth = "50" },
                new GridColumn() { Field = "leavesValue", HeaderText = "Leaves", TextAlign = TextAlign.Center, MinWidth = "50" },
            };

            List<GridColumn> gridColumns = new List<GridColumn>() {
                new GridColumn() { Field = "totalEmployees", HeaderText = "Total Employees", TextAlign = TextAlign.Center, MinWidth = "50" },
                new GridColumn { Field = "", HeaderText = "Earnings", TextAlign=TextAlign.Center,  MinWidth="40",
                                 Columns = earningsColumns
                },
                new GridColumn { Field = "", HeaderText = "Deductions", TextAlign=TextAlign.Center,  MinWidth="40",
                                 Columns = deductionsColumns
                }
            };

            return gridColumns;
        }
    }
}
