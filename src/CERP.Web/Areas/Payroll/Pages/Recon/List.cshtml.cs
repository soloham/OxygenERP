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

namespace CERP.Web.Areas.Payroll.Pages.ReconcilliationPage
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

        public IActionResult OnGet(int P1Year, int P1Month, int P2Year, int P2Month, bool isAjax)
        {
            bool isOnGet = P1Year != 0 && P2Year != 0;
            if (!isOnGet)
                return Page();

            try
            {
                bool isPeriodValid = true;

                Payrun_Dto fromPayrun = null;
                Payrun_Dto toPayrun = null;

                fromPayrun = ObjectMapper.Map<Payrun, Payrun_Dto>(PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Year == P1Year && x.Month == P1Month));
                toPayrun = ObjectMapper.Map<Payrun, Payrun_Dto>(PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Year == P2Year && x.Month == P2Month));

                if (fromPayrun == null || toPayrun == null)
                    isPeriodValid = false;

                if (!isPeriodValid)
                    return BadRequest(new { type = "period" });


                List<dynamic> payrunReconSummaryDynamicDS = new List<dynamic>();

                if (fromPayrun != null && toPayrun != null)
                {
                    Allowances = DicValuesRepo.WithDetails(x => x.ValueType).Where(x => x.ValueType.ValueTypeFor == ValueTypeModules.AllowanceType).ToList();

                    List<PayrunDetail_Dto> fromPDetails = fromPayrun.PayrunDetails.ToList();
                    List<PayrunDetail_Dto> toPDetails = toPayrun.PayrunDetails.ToList();

                    List<(PayrunDetail_Dto fromPDetail, PayrunDetail_Dto toPDetail)> payrunReconDetails = new List<(PayrunDetail_Dto fromPDetail, PayrunDetail_Dto toPDetail)>();

                    var toExplicits = toPDetails.Where(x => !fromPDetails.Any(x1 => x1.EmployeeId == x.EmployeeId))
                                           .Select(x => { return ((PayrunDetail_Dto)null, x); });

                    payrunReconDetails.AddRange(toExplicits);
                    payrunReconDetails.AddRange(fromPDetails.Select(x =>
                    {
                        if (toPDetails.Exists(x1 => x1.EmployeeId == x.EmployeeId))
                        {
                            return (x, toPDetails.Single(x1 => x1.EmployeeId == x.EmployeeId));
                        }
                        else
                        {
                            return (x, null);
                        }
                    }));

                    for (int i = 0; i < payrunReconDetails.Count; i++)
                    {
                        var reconDetail = payrunReconDetails[i];

                        PayrunDetail_Dto fromD = reconDetail.fromPDetail;
                        PayrunDetail_Dto toD = reconDetail.toPDetail;

                        dynamic payrunReconEmpDDSRow = new ExpandoObject();

                        if (fromD != null || toD != null)
                        {
                            bool isFromD = fromD != null;
                            bool isToD = toD != null;
                            bool both = isToD && isFromD;

                            Employee_Dto emp = isFromD ? fromD.Employee : toD.Employee;

                            payrunReconEmpDDSRow.getCompanyName = emp.Department.Company.Name;
                            payrunReconEmpDDSRow.getCompanyAddress = emp.Department.Company.Address;
                            payrunReconEmpDDSRow.getEmployeeReferenceId = emp.GetReferenceId;
                            payrunReconEmpDDSRow.getEmployeeName = emp.Name;
                            payrunReconEmpDDSRow.getEmployeeDepartmentName = emp.Department.Name;
                            payrunReconEmpDDSRow.getEmployeePositionTitle = emp.Position.Title;

                            if (both)
                            {
                                List<(PayrunAllowanceSummary_Dto fromAllowance, PayrunAllowanceSummary_Dto toAllowance)> allowancesReconDetails = new List<(PayrunAllowanceSummary_Dto fromAllowance, PayrunAllowanceSummary_Dto toAllowance)>();

                                var toAllowancesExplicits = toD.PayrunAllowancesSummaries.Where(x => !fromD.PayrunAllowancesSummaries.Any(x1 => x1.AllowanceTypeId == x.AllowanceTypeId))
                                                                                        .Select(x => { return ((PayrunAllowanceSummary_Dto)null, x); });

                                allowancesReconDetails.AddRange(toAllowancesExplicits);
                                allowancesReconDetails.AddRange(fromD.PayrunAllowancesSummaries.Select(x =>
                                {
                                    if (toD.PayrunAllowancesSummaries.Any(x1 => x1.AllowanceTypeId == x.AllowanceTypeId))
                                    {
                                        return (x, toD.PayrunAllowancesSummaries.First(x1 => x1.AllowanceTypeId == x.AllowanceTypeId));
                                    }
                                    else
                                    {
                                        return (x, null);
                                    }
                                }));

                                decimal bsDiffValue = (toD.BasicSalary - fromD.BasicSalary);
                                string bsDiff = bsDiffValue < 0? $"({Math.Abs(bsDiffValue).ToString("N2")})" : bsDiffValue.ToString("N2");
                                DynamicHelper.AddProperty(payrunReconEmpDDSRow, $"basicSalary", bsDiff);

                                if(bsDiffValue > 0)
                                {
                                    payrunReconEmpDDSRow.category = "Increment";
                                    var cloned = JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(payrunReconEmpDDSRow));
                                    payrunReconSummaryDynamicDS.Add(cloned); ;
                                    payrunReconEmpDDSRow.category = "⁠";
                                }
                                else if(bsDiffValue < 0)
                                {
                                    payrunReconEmpDDSRow.category = "Deduction";
                                    var cloned = JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(payrunReconEmpDDSRow));
                                    payrunReconSummaryDynamicDS.Add(cloned);
                                    payrunReconEmpDDSRow.category = "⁠";
                                }
                                payrunReconEmpDDSRow.basicSalary = "⁠—";

                                for (int j = 0; j < allowancesReconDetails.Count; j++)
                                {
                                    PayrunAllowanceSummary_Dto fromAllowance = allowancesReconDetails[j].fromAllowance;
                                    PayrunAllowanceSummary_Dto toAllowance = allowancesReconDetails[j].toAllowance;

                                    bool isFromDAllowance = fromAllowance != null;
                                    bool isToDAllowance = toAllowance != null;
                                    bool bothAllowance = isFromDAllowance && isToDAllowance;

                                    if (bothAllowance)
                                    {
                                        DictionaryValue_Dto allowance = fromAllowance.AllowanceType;
                                        string camelCaseName = allowance.Value;
                                        camelCaseName = camelCaseName.Replace(" ", "");
                                        camelCaseName = char.ToLowerInvariant(camelCaseName[0]) + camelCaseName.Substring(1);

                                        double difference = (double)(toAllowance.Value - fromAllowance.Value);
                                        string difValue = difference >= 0 ? difference.ToString("N2") : $"({Math.Abs(difference).ToString("N2")})";

                                        DynamicHelper.AddProperty(payrunReconEmpDDSRow, $"{camelCaseName}_Value", difValue);

                                        if (difference > 0)
                                        {
                                            payrunReconEmpDDSRow.category = $"{allowance.Value} Increased";
                                            var cloned = JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(payrunReconEmpDDSRow));
                                            payrunReconSummaryDynamicDS.Add(cloned);
                                            DynamicHelper.RemoveProperty(payrunReconEmpDDSRow, $"{camelCaseName}_Value");
                                            payrunReconEmpDDSRow.category = "⁠";
                                        }
                                        else if(difference < 0)
                                        {
                                            payrunReconEmpDDSRow.category = $"{allowance.Value} Decreased";
                                            var cloned = JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(payrunReconEmpDDSRow));
                                            payrunReconSummaryDynamicDS.Add(cloned);
                                            DynamicHelper.RemoveProperty(payrunReconEmpDDSRow, $"{camelCaseName}_Value");
                                            payrunReconEmpDDSRow.category = "⁠";
                                        }
                                    }
                                    else
                                    {
                                        if (isFromDAllowance)
                                        {
                                            DictionaryValue_Dto allowance = fromAllowance.AllowanceType;
                                            string camelCaseName = allowance.Value;
                                            camelCaseName = camelCaseName.Replace(" ", "");
                                            camelCaseName = char.ToLowerInvariant(camelCaseName[0]) + camelCaseName.Substring(1);

                                            double allowanceValue = (double)fromAllowance.Value;
                                            string value = $"({allowanceValue.ToString("N2")})";

                                            DynamicHelper.AddProperty(payrunReconEmpDDSRow, $"{camelCaseName}_Value", value);
                                            payrunReconEmpDDSRow.category = $"{allowance.Value} Removed";
                                            var cloned = JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(payrunReconEmpDDSRow));
                                            payrunReconSummaryDynamicDS.Add(cloned);
                                            DynamicHelper.RemoveProperty(payrunReconEmpDDSRow, $"{camelCaseName}_Value");
                                            payrunReconEmpDDSRow.category = "⁠";
                                        }
                                        else if (isToDAllowance)
                                        {
                                            DictionaryValue_Dto allowance = toAllowance.AllowanceType;
                                            string camelCaseName = allowance.Value;
                                            camelCaseName = camelCaseName.Replace(" ", "");
                                            camelCaseName = char.ToLowerInvariant(camelCaseName[0]) + camelCaseName.Substring(1);

                                            double allowanceValue = (double)toAllowance.Value;
                                            string value = allowanceValue >= 0 ? allowanceValue.ToString("N2") : $"({allowanceValue.ToString("N2")})";

                                            DynamicHelper.AddProperty(payrunReconEmpDDSRow, $"{camelCaseName}_Value", value);
                                            payrunReconEmpDDSRow.category = $"{allowance.Value} Added";
                                            var cloned = JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(payrunReconEmpDDSRow));
                                            payrunReconSummaryDynamicDS.Add(cloned);
                                            DynamicHelper.RemoveProperty(payrunReconEmpDDSRow, $"{camelCaseName}_Value");
                                            payrunReconEmpDDSRow.category = "⁠";
                                        }
                                    }
                                }
                                payrunReconEmpDDSRow.grossEarnings = toD.GrossEarnings - fromD.GrossEarnings;

                                decimal gosiDiffValue = (toD.GOSIAmount - fromD.GOSIAmount);
                                payrunReconEmpDDSRow.gosiValue = gosiDiffValue > 0? gosiDiffValue.ToString("N2") : $"({Math.Abs(gosiDiffValue).ToString("N2")})";
                                if (gosiDiffValue != 0)
                                {
                                    payrunReconEmpDDSRow.category = gosiDiffValue > 0? "GOSI Increased" : "GOSI Decreased";
                                    var cloned = JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(payrunReconEmpDDSRow));
                                    payrunReconSummaryDynamicDS.Add(cloned);
                                    payrunReconEmpDDSRow.gosiValue = "—";
                                    payrunReconEmpDDSRow.category = "⁠";
                                }

                                decimal loansDiffValue = (toD.Loan - fromD.Loan);
                                payrunReconEmpDDSRow.loansValue = loansDiffValue > 0? loansDiffValue.ToString("N2") : $"({Math.Abs(loansDiffValue).ToString("N2")})";
                                if (loansDiffValue != 0)
                                {
                                    payrunReconEmpDDSRow.category = loansDiffValue > 0? "Loans Increased" : "Loans Decreased";
                                    var cloned = JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(payrunReconEmpDDSRow));
                                    payrunReconSummaryDynamicDS.Add(cloned);
                                    payrunReconEmpDDSRow.gosiValue = "—";
                                    payrunReconEmpDDSRow.category = "⁠";
                                }
                                decimal leavesDiffValue = (toD.Leaves - fromD.Leaves);
                                payrunReconEmpDDSRow.leavesValue = leavesDiffValue > 0? leavesDiffValue.ToString("N2") : $"({Math.Abs(leavesDiffValue).ToString("N2")})";
                                if (loansDiffValue != 0)
                                {
                                    payrunReconEmpDDSRow.category = leavesDiffValue > 0? "Leaves Increased" : "Leaves Decreased";
                                    var cloned = JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(payrunReconEmpDDSRow));
                                    payrunReconSummaryDynamicDS.Add(cloned);
                                    payrunReconEmpDDSRow.gosiValue = "—";
                                    payrunReconEmpDDSRow.category = "⁠";
                                }

                                payrunReconEmpDDSRow.grossDeduction = toD.GrossDeductions - fromD.GrossDeductions;

                                payrunReconEmpDDSRow.netAmount = (payrunReconEmpDDSRow.grossEarnings - payrunReconEmpDDSRow.grossDeduction).ToString("N2");
                            }
                            else
                            {
                                if (isFromD)
                                {

                                    string bs = fromD.BasicSalary.ToString("N2");
                                    DynamicHelper.AddProperty(payrunReconEmpDDSRow, $"basicSalary", bs);
                                    var fromAllowances = fromD.PayrunAllowancesSummaries.ToList();
                                    for (int j = 0; j < fromAllowances.Count; j++)
                                    {
                                        PayrunAllowanceSummary_Dto fromAllowance = fromAllowances[i];

                                        DictionaryValue_Dto allowance = fromAllowance.AllowanceType;
                                        string camelCaseName = allowance.Value;
                                        camelCaseName = camelCaseName.Replace(" ", "");
                                        camelCaseName = char.ToLowerInvariant(camelCaseName[0]) + camelCaseName.Substring(1);

                                        double allowanceValue = (double)fromAllowance.Value;
                                        string value = allowanceValue > 0 ? allowanceValue.ToString("N2") : $"({allowanceValue.ToString("N2")})";

                                        DynamicHelper.AddProperty(payrunReconEmpDDSRow, $"{camelCaseName}_Value", value);
                                    }
                                    payrunReconEmpDDSRow.grossEarnings = fromD.GrossEarnings;

                                    payrunReconEmpDDSRow.gosiValue = fromD.GOSIAmount;
                                    payrunReconEmpDDSRow.loansValue = fromD.Loan;
                                    payrunReconEmpDDSRow.leavesValue = fromD.Leaves;

                                    payrunReconEmpDDSRow.grossDeduction = fromD.GrossDeductions;

                                    payrunReconEmpDDSRow.netAmount = (payrunReconEmpDDSRow.grossEarnings - payrunReconEmpDDSRow.grossDeduction).ToString("N2");

                                    payrunReconEmpDDSRow.category = "Left";
                                    payrunReconSummaryDynamicDS.Add(payrunReconEmpDDSRow);
                                    payrunReconEmpDDSRow.category = "⁠";
                                }
                                else if (isToD)
                                {

                                    string bs = toD.BasicSalary.ToString("N2");
                                    DynamicHelper.AddProperty(payrunReconEmpDDSRow, $"basicSalary", bs);
                                    var toAllowances = toD.PayrunAllowancesSummaries.ToList();
                                    for (int j = 0; j < toAllowances.Count; j++)
                                    {
                                        PayrunAllowanceSummary_Dto toAllowance = toAllowances[i];

                                        DictionaryValue_Dto allowance = toAllowance.AllowanceType;
                                        string camelCaseName = allowance.Value;
                                        camelCaseName = camelCaseName.Replace(" ", "");
                                        camelCaseName = char.ToLowerInvariant(camelCaseName[0]) + camelCaseName.Substring(1);

                                        double allowanceValue = (double)toAllowance.Value;
                                        string value = allowanceValue > 0 ? allowanceValue.ToString("N2") : $"({allowanceValue.ToString("N2")})";

                                        DynamicHelper.AddProperty(payrunReconEmpDDSRow, $"{camelCaseName}_Value", value);
                                    }
                                    payrunReconEmpDDSRow.grossEarnings = toD.GrossEarnings;

                                    payrunReconEmpDDSRow.gosiValue = toD.GOSIAmount;
                                    payrunReconEmpDDSRow.loansValue = toD.Loan;
                                    payrunReconEmpDDSRow.leavesValue = toD.Leaves;

                                    payrunReconEmpDDSRow.grossDeduction = toD.GrossDeductions;

                                    payrunReconEmpDDSRow.netAmount = (payrunReconEmpDDSRow.grossEarnings - payrunReconEmpDDSRow.grossDeduction).ToString("N2");

                                    payrunReconEmpDDSRow.category = "New Employee";
                                    payrunReconSummaryDynamicDS.Add(payrunReconEmpDDSRow);
                                    payrunReconEmpDDSRow.category = "⁠";
                                }
                            }
                        }

                        //if(payrunReconEmpDDSRow.netAmount != "0.00")
                        //    payrunReconSummaryDynamicDS.Add(payrunReconEmpDDSRow);
                    }

                    if (!isAjax)
                    {
                        ViewData["Payruns_DS"] = JsonSerializer.Serialize(payrunReconSummaryDynamicDS);
                        return Page();
                    }
                    else
                        return new JsonResult(payrunReconSummaryDynamicDS);
                }
                else
                {
                    return BadRequest(new { type = "payrun" });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new { type = "exception" });
            }
        }

        public async Task<IActionResult> OnDeletePayrun(int year, int month)
        {
            Payrun payrun = PayrunAppService.Repository.SingleOrDefault(x => x.Month == month && x.Year == year);
            if (payrun != null && payrun.IsPosted == false)
            {
                await PayrunAppService.Repository.DeleteAsync(payrun);

                return NoContent();
            }
            else
                return StatusCode(500);
        }

        public List<GridColumn> GetCommandsColumns()
        {
            List<object> commands = new List<object>();
            commands.Add(new { type = "View", buttonOption = new { iconCss = "zmdi zmdi-search", cssClass = "e-flat e-ViewButton" } });
            commands.Add(new { type = "Edit", buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat e-EditButton" } });
            commands.Add(new { type = "Delete", buttonOption = new { iconCss = "e-icons e-delete", cssClass = "e-flat e-DeleteButton" } });
            //commands.Add(new { type = "Save", buttonOption = new { iconCss = "e-icons e-update", cssClass = "e-flat" } });
            //commands.Add(new { type = "Cancel", buttonOption = new { iconCss = "e-icons e-cancel-icon", cssClass = "e-flat" } });

            return new List<GridColumn>()
            { 
                new GridColumn { Width = "95", HeaderText = "", TextAlign=TextAlign.Center, MinWidth="10", Commands = commands }
            };
        }
        public List<GridColumn> GetPrimaryGridColumns()
        {
            Allowances = DicValuesRepo.WithDetails(x => x.ValueType).Where(x => x.ValueType.ValueTypeFor == ValueTypeModules.AllowanceType).ToList();

            List<GridColumn> earningsColumns = new List<GridColumn>();

            earningsColumns.Add(new GridColumn() { Field = $"basicSalary", HeaderText = "Basic Salary", TextAlign = TextAlign.Center, MinWidth = "50" });
            for (int i = 0; i < Allowances.Count; i++)
            {
                DictionaryValue allowance = Allowances[i];
                string camelCaseName = allowance.Value;
                camelCaseName = camelCaseName.Replace(" ", "");
                camelCaseName = char.ToLowerInvariant(camelCaseName[0]) + camelCaseName.Substring(1);

                earningsColumns.Add(new GridColumn() { Field = $"{camelCaseName}_Value", HeaderText = $"{Allowances[i].Value}", TextAlign = TextAlign.Center, MinWidth = "50" });
            }
            //earningsColumns.Add(new GridColumn() { Field = $"grossEarnings", HeaderText = "Total", TextAlign = TextAlign.Center, MinWidth = "50" });

            List<GridColumn> gridColumns = new List<GridColumn>() {
                new GridColumn { Field = "getEmployeeReferenceId", HeaderText = "Emp Id", TextAlign=TextAlign.Center,  MinWidth="40"  },
                new GridColumn { Field = "getEmployeeName", HeaderText = "Employee", TextAlign=TextAlign.Center,  MinWidth="40"  },
                new GridColumn { Field = "getEmployeeDepartmentName", HeaderText = "Department", TextAlign=TextAlign.Center,  MinWidth="50"  },
                new GridColumn { Field = "getEmployeePositionTitle", HeaderText = "Position", TextAlign=TextAlign.Center,  MinWidth="50"  }
            };

            gridColumns.Add(new GridColumn
            {
                Field = "",
                HeaderText = "Earnings",
                TextAlign = TextAlign.Center,
                MinWidth = "50",
                Columns = earningsColumns
            });
            gridColumns.Add(new GridColumn
            {
                Field = "",
                HeaderText = "Deductions",
                TextAlign = TextAlign.Center,
                MinWidth = "50",
                Columns = new List<GridColumn>()
                {
                    new GridColumn() { Field = "gosiValue", HeaderText = "GOSI", TextAlign = TextAlign.Center, MinWidth = "50" },
                    new GridColumn() { Field = "loansValue", HeaderText = "Loans", TextAlign = TextAlign.Center, MinWidth = "50" },
                    new GridColumn() { Field = "leavesValue", HeaderText = "Leaves", TextAlign = TextAlign.Center, MinWidth = "50" },
                    //new GridColumn() { Field = "grossDeductions", HeaderText = "Total", TextAlign = TextAlign.Center, MinWidth = "50" },
                }
            });

            //gridColumns.Add(new GridColumn { Field = "netAmount", HeaderText = "Net Amount", TextAlign = TextAlign.Center, MinWidth = "50" });
            gridColumns.Add(new GridColumn { Field = "category", HeaderText = "Category", TextAlign = TextAlign.Center, MinWidth = "50" });

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
