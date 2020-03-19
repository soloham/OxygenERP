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

        public IRepository<DictionaryValue, Guid> DicValuesRepo { get; set; }
        public List<DictionaryValue> Allowances { get; set; }

        public Grid SecondaryDetailsGrid { get; set; }

        public ListModel(IJsonSerializer jsonSerializer, PayrunAppService payrunAppService, IRepository<DictionaryValue, Guid> dicValuesRepo)
        {
            JsonSerializer = jsonSerializer;
            PayrunAppService = payrunAppService;
            DicValuesRepo = dicValuesRepo;
        }

        public void OnGet()
        {
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
                //Toolbar = new List<object>() { "ExcelExport", "PdfExport", "CsvExport", "Print", "Search", "Delete", new { text = "Copy", tooltipText = "Copy", prefixIcon = "e-copy", id = "copy" }, new { text = "Copy With Header", tooltipText = "Copy With Header", prefixIcon = "e-copy", id = "copyHeader" } },
                ContextMenuItems = new List<object>() { "AutoFit", "AutoFitAll", "SortAscending", "SortDescending", "Copy", "Edit", "Delete", "Save", "Cancel", "PdfExport", "ExcelExport", "CsvExport", "FirstPage", "PrevPage", "LastPage", "NextPage" },
                Columns = GetSecondaryGridColumns()
            };
        }
        public IActionResult OnGetPaymentsSheet(int payrunId)
        {
            Payrun payrun = PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Id == payrunId);
            if (payrun != null && payrun.IsPosted)
            {
                List<PayrunDetail> payrunDetails = payrun.PayrunDetails.ToList();
                List<dynamic> dynamicDS = new List<dynamic>();

                for (int i = 0; i < payrunDetails.Count; i++)
                {
                    PayrunDetail curDetail = payrunDetails[i];
                    List<PayrunAllowanceSummary> payrunAllowances = curDetail.PayrunAllowancesSummaries.ToList();
                    PayrunAllowanceSummary housingAllowance = payrunAllowances.SingleOrDefault(x => x.AllowanceType.Value == "Housing");
                    string otherAllowancesSum = "SAR " + (payrunAllowances.Sum(x => x.Value) - (housingAllowance == null ? 0 : housingAllowance.Value)).ToString("N2");
                    DateTime curPeriod = new DateTime(curDetail.Year, curDetail.Month, 1);

                    dynamic paymentSlipDSRow = new ExpandoObject();
                    paymentSlipDSRow.sNo = i + 1;
                    paymentSlipDSRow.getEmpRefCode = curDetail.Employee.GetReferenceId;
                    paymentSlipDSRow.getEmpName = curDetail.Employee.Name;

                    FinancialDetails financialDetails = JsonSerializer.Deserialize<FinancialDetails>(curDetail.Employee.ExtraProperties["financialDetails"].ToString());
                    BanksRDTO curBank = financialDetails.Banks.Last();//financialDetails.Banks.SingleOrDefault(x => DateTime.Parse(x.FromDate).Month >= curPeriod.Month && DateTime.Parse(x.ToDate).Month <= curPeriod.Month);
                    paymentSlipDSRow.getBankName = curBank.GetBankName;
                    paymentSlipDSRow.getBankIBAN = curBank.BankIBAN;

                    paymentSlipDSRow.getBasicSalary = curDetail.BasicSalary;
                    paymentSlipDSRow.getAllowanceHousing = housingAllowance == null ? "—" : "SAR " + housingAllowance.Value.ToString("N2");
                    paymentSlipDSRow.getOtherIncome = otherAllowancesSum;
                    paymentSlipDSRow.getDeductions = curDetail.GrossDeductions;
                    paymentSlipDSRow.getPayment = curDetail.NetAmount;

                    dynamicDS.Add(paymentSlipDSRow);
                }

                return new JsonResult(dynamicDS);
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

                return NoContent();
            }
            else
                return StatusCode(500);
        }

        public List<GridColumn> GetCommandsColumns()
        {
            List<object> commands = new List<object>();
            commands.Add(new { type = "View", buttonOption = new { iconCss = "zmdi zmdi-search", cssClass = "e-flat e-ViewButton" } });
            commands.Add(new { type = "View Reconciliation", buttonOption = new { iconCss = "zmdi zmdi-assignment-alert", cssClass = "e-flat e-ViewButton" } });
            commands.Add(new { type = "View Payments Sheet", buttonOption = new { iconCss = "zmdi zmdi-receipt", cssClass = "e-flat e-ViewButton" } });
            commands.Add(new { type = "View Attachment", buttonOption = new { iconCss = "zmdi zmdi-attachment-alt", cssClass = "e-flat e-ViewButton" } });
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
                new GridColumn { Field = "company.name", Width = "100", HeaderText = "Company", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "year", Width = "100", HeaderText = "Year", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "getMonth", HeaderText = "Month", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "totalEarnings", HeaderText = "Earnings", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "totalDeductions", HeaderText = "Deductions", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "netTotal", HeaderText = "Net Total", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "note", HeaderText = "Note", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "isPosted", Width = "65", DisplayAsCheckBox = true, HeaderText = "Is Posted", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "postedDate", HeaderText = "Posted Date", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "postedByTemp", HeaderText = "Posted By", TextAlign=TextAlign.Center,  MinWidth="10"  },
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
