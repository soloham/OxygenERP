using CERP.App;
using CERP.App.Helpers;
using CERP.AppServices.HR.DepartmentService;
using CERP.AppServices.HR.EmployeeService;
using CERP.AppServices.HR.WorkShiftService;
using CERP.AppServices.Payroll.PayrunService;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.EMPLOYEE.RougeDTOs;
using CERP.HR.Employees.DTOs;
using CERP.Payroll.DTOs;
using CERP.Payroll.Payrun;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Json;

namespace CERP.Web.Areas.Payroll.Pages.Run
{
    public class ListModel : CERPPageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ForYear { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ForMonth { get; set; }

        public IJsonSerializer JsonSerializer { get; set; }
        public PayrunAppService PayrunAppService { get; set; }
        public companyAppService CompanyAppService { get; set; }
        public EmployeeAppService EmployeeAppService { get; set; }
        public documentAppService documentAppService { get; set; }
        public TimesheetAppService timesheetAppService { get; set; }

        public IRepository<PayrunDetail, int> PayrunDetailsRepo { get; set; }
        public IRepository<DictionaryValue, Guid> DicValuesRepo { get; set; }

        public List<DictionaryValue> Allowances { get; set; }

        public IWebHostEnvironment webHostEnvironment { get; set; }

        public ListModel(IJsonSerializer jsonSerializer, PayrunAppService payrunAppService, IRepository<PayrunDetail, int> payrunDetailsRepo, companyAppService companyAppService, EmployeeAppService employeeAppService, IRepository<DictionaryValue, Guid> dicValuesRepo, documentAppService documentAppService, TimesheetAppService timesheetAppService, IWebHostEnvironment webHostEnvironment)
        {
            JsonSerializer = jsonSerializer;
            PayrunAppService = payrunAppService;
            PayrunDetailsRepo = payrunDetailsRepo;
            CompanyAppService = companyAppService;
            EmployeeAppService = employeeAppService;
            DicValuesRepo = dicValuesRepo;
            this.documentAppService = documentAppService;
            this.timesheetAppService = timesheetAppService;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet(int month, int year, Guid employeeId)
        {
            if (employeeId == Guid.Empty)
            {
                ViewData["PayrunsDetails_DS"] = GetPayrun(ForMonth, ForYear);
                return Page();
            }
            else
            {
                return OnGetPayslip(month, year, employeeId);
            }
        }

        public IActionResult OnGetPayrun(int month, int year)
        {
            return GetPayrun(month, year);
        }

        private IActionResult GetPayrun(int month, int year)
        {
            Payrun_Dto payrun = null;
            if (year != 0 && month != 0) payrun = ObjectMapper.Map<Payrun, Payrun_Dto>(PayrunAppService.Repository.WithDetails().SingleOrDefault(x => x.Year == year && x.Month == month));
            List<PayrunDetail_Dto> payrunDetails = payrun == null ? new List<PayrunDetail_Dto>() : payrun.PayrunDetails.ToList();

            List<dynamic> dynamicDS = new List<dynamic>();

            for (int i = 0; i < payrunDetails.Count; i++)
            {
                PayrunDetail_Dto payrunDetail = payrunDetails[i];
                dynamic dynamicDSRow = new ExpandoObject();

                dynamic employeeDynamic = new ExpandoObject();

                dynamicDSRow.employeeId = payrunDetail.EmployeeId;
                dynamicDSRow.getEmployeeReferenceId = payrunDetail.Employee.GetReferenceId;
                dynamicDSRow.getEmployeeName = payrunDetail.Employee.Name;
                dynamicDSRow.getEmployeeDepartmentName = payrunDetail.Employee.Department.Name;
                dynamicDSRow.getEmployeePositionTitle = payrunDetail.Employee.Position.Title;

                dynamicDSRow.basicSalary = payrunDetail.BasicSalary;
                foreach (PayrunAllowanceSummary_Dto allowanceSummary in payrunDetail.PayrunAllowancesSummaries)
                {
                    DictionaryValue_Dto allowance = allowanceSummary.AllowanceType;
                    string camelCaseName = allowance.Value;
                    camelCaseName = camelCaseName.Replace(" ", "");
                    camelCaseName = char.ToLowerInvariant(camelCaseName[0]) + camelCaseName.Substring(1);
                    DynamicHelper.AddProperty(dynamicDSRow, $"{camelCaseName}_Value", allowanceSummary.Value);
                }
                dynamicDSRow.grossEarnings = payrunDetail.GrossEarnings;

                dynamicDSRow.gosiValue = payrunDetail.GOSIAmount;
                dynamicDSRow.loansValue = payrunDetail.Loan;
                dynamicDSRow.leavesValue = payrunDetail.Leaves;
                dynamicDSRow.grossDeductions = payrunDetail.GrossDeductions;

                dynamicDSRow.netAmount = payrunDetail.NetAmount;

                dynamicDS.Add(dynamicDSRow);
            }

            if (payrunDetails == null || payrunDetails.Count == 0) return StatusCode(500); else return new JsonResult(new { dataSource = dynamicDS, isPosted = payrun.IsPosted });
        }
        private IActionResult OnGetPayslip(int month, int year, Guid employeeId)
        {
            PayrunDetail payrunDetail = new PayrunDetail();
            if (year != 0 && month != 0 && employeeId != Guid.Empty) payrunDetail = PayrunDetailsRepo.WithDetails().SingleOrDefault(x => x.Year == year && x.Month == month && x.EmployeeId == employeeId);

            List<dynamic> dynamicDS = new List<dynamic>();

            dynamic dynamicDSRow = new ExpandoObject();

            dynamic employeeDynamic = new ExpandoObject();

            dynamicDSRow.basicSalary = payrunDetail.BasicSalary;
            dynamicDSRow.getCompanyName = payrunDetail.Employee.Department.Company.Name;
            dynamicDSRow.getCompanyAddress = payrunDetail.Employee.Department.Company.Address;
            dynamicDSRow.getEmployeeReferenceId = payrunDetail.Employee.GetReferenceId;
            dynamicDSRow.getEmployeeName = payrunDetail.Employee.Name;
            dynamicDSRow.getEmployeeDepartmentName = payrunDetail.Employee.Department.Name;
            dynamicDSRow.getEmployeePositionTitle = payrunDetail.Employee.Position.Title;

            dynamicDSRow.getPeriod = $"{payrunDetail.Month.ToString().PadLeft(2, '0')}/{payrunDetail.Year.ToString().PadLeft(2, '0')}";

            dynamicDSRow.Earnings = new List<KeyValuePair<string, string>>();
            foreach (PayrunAllowanceSummary allowanceSummary in payrunDetail.PayrunAllowancesSummaries)
            {
                DictionaryValue allowance = allowanceSummary.AllowanceType;
                string camelCaseName = allowance.Value;
                camelCaseName = camelCaseName.Replace(" ", "");
                camelCaseName = char.ToLowerInvariant(camelCaseName[0]) + camelCaseName.Substring(1);
                KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>(allowance.Value, "SAR " + allowanceSummary.Value.ToString("N2"));
                dynamicDSRow.Earnings.Add(keyValuePair);
                //DynamicHelper.AddProperty(dynamicDSRow, $"{camelCaseName}_Value", allowanceSummary.Value);
            }
            dynamicDSRow.grossEarnings = payrunDetail.GrossEarnings;
            dynamicDSRow.Deductions = new List<KeyValuePair<string, string>>();

            dynamicDSRow.gosiValue = payrunDetail.GOSIAmount;
            dynamicDSRow.Deductions.Add(new KeyValuePair<string, string>("GOSI", "SAR " + dynamicDSRow.gosiValue.ToString("N2")));
            dynamicDSRow.loansValue = payrunDetail.Loan;
            dynamicDSRow.Deductions.Add(new KeyValuePair<string, string>("Loans", "SAR " + dynamicDSRow.loansValue.ToString("N2")));
            dynamicDSRow.leavesValue = payrunDetail.Leaves;
            dynamicDSRow.Deductions.Add(new KeyValuePair<string, string>("Leaves", "SAR " + dynamicDSRow.leavesValue.ToString("N2")));
            dynamicDSRow.grossDeductions = payrunDetail.GrossDeductions;

            dynamicDSRow.netAmount = payrunDetail.NetAmount;

            dynamicDS.Add(dynamicDSRow);

            dynamicDSRow.Payments = new List<PayslipVM>();
            double bs = (double)payrunDetail.BasicSalary;
            double rate = double.Parse((bs / (45 * 5)).ToString("N2"));
            double totalHours = payrunDetail.EmployeeTimesheet.TotalMonthHours;

            dynamicDSRow.Payments.Add(new PayslipVM("Basic Salary", "Salary", rate, totalHours, rate * totalHours));
            dynamicDSRow.TotalPayments = (dynamicDSRow.Payments as List<PayslipVM>).Sum(x => x.Amount);
            dynamicDSRow.TotalHours = (dynamicDSRow.Payments as List<PayslipVM>).Sum(x => x.Hours);

            if (payrunDetail == null) return StatusCode(500); else return PartialView("_Payslip", dynamicDSRow);
        }

        public class PayslipVM
        {
            public PayslipVM(string title, string type, double rate, double hours, double amount)
            {
                Title = title;
                Type = type;
                Rate = rate;
                Hours = hours;
                Amount = amount;
            }

            public string Title { get; set; }
            public string Type { get; set; }
            public double Rate { get; set; }
            public double Hours { get; set; }
            public double Amount { get; set; }
        }

        public async Task<IActionResult> OnPostGenerate(int month, int year)
        {
            try
            {
                Guid CompanyId = CompanyAppService.Repository.First().Id;
                Payrun_Dto payrunPrevious = PayrunAppService.GetPayrun(month - 1, year, CompanyId);
                Payrun_Dto payrun = PayrunAppService.GetPayrun(month, year, CompanyId);
                bool exists = payrun != null;

                List<Employee_Dto> employees = EmployeeAppService.GetAllEmployees().Where(x => x.EmployeeStatus.Key != AppSettings.TerminatedEmployeeStatusKey).ToList();

                List<PayrunDetail_Dto> payrunDetails = new List<PayrunDetail_Dto>();

                for (int i = 0; i < employees.Count; i++)
                {
                    bool isNewEmployee = false;

                    Employee_Dto curEmployee = employees[i];
                    PayrunDetail_Dto empPayrunDetailPrevious = payrunPrevious == null ? null : payrunPrevious.PayrunDetails.SingleOrDefault(x => x.EmployeeId == curEmployee.Id);
                    Timesheet_Dto empTimesheet = null;
                    try
                    {
                        empTimesheet = timesheetAppService.GetTimesheet(year, month, curEmployee.Id);
                    }
                    catch (Exception ex)
                    {
                        return new NotFoundObjectResult(new { message = $"Timesheet of the employee {curEmployee.Name} for the period {month.ToString().PadLeft(2, '0')}/{year.ToString().PadLeft(2, '0')}<br/>doesn't exist." });
                    }
                    if (empTimesheet == null)
                    {
                        return new BadRequestObjectResult(new { message = $"Timesheet of the employee {curEmployee.Name}<br/>for the period {month.ToString().PadLeft(2, '0')}/{year.ToString().PadLeft(2, '0')}<br/>doesn't exist." });
                    }
                    isNewEmployee = payrunPrevious != null && empPayrunDetailPrevious == null;

                    PayrunDetail_Dto empPayrunDetail = new PayrunDetail_Dto();
                    empPayrunDetail.PayrunAllowancesSummaries = new List<PayrunAllowanceSummary_Dto>();

                    empPayrunDetail.Year = year;
                    empPayrunDetail.Month = month;
                    empPayrunDetail.EmployeeId = curEmployee.Id;
                    empPayrunDetail.EmployeeTimesheetId = empTimesheet.Id;

                    //Gross Variables
                    decimal grossEarnings = 0;
                    decimal grossDeductions = 0;

                    FinancialDetails financialDetails = JsonSerializer.Deserialize<FinancialDetails>(curEmployee.ExtraProperties["financialDetails"].ToString());
                    financialDetails.Initialize(DicValuesRepo);

                    //Calculate Basic Salary
                    double curBasicSalary = financialDetails.BasicSalaries.Last().Salary;
                    empPayrunDetail.BasicSalary = (decimal)curBasicSalary;
                    grossEarnings += empPayrunDetail.BasicSalary;

                    //Calculate Allowances
                    DateTime curDateTime = DateTime.Now;
                    List<AllowanceRDTO> allowances = financialDetails.AllowancesDetails.Count == 0 ? new List<AllowanceRDTO>() : financialDetails.AllowancesDetails.Where(x => curDateTime.Date >= DateTime.Parse(x.FromDate).Date && curDateTime.Date <= DateTime.Parse(x.EndDate).Date).ToList();
                    for (int j = 0; j < allowances.Count; j++)
                    {
                        PayrunAllowanceSummary_Dto payrunAllowanceSummaryPrevious = empPayrunDetailPrevious == null ? null : empPayrunDetailPrevious.PayrunAllowancesSummaries.SingleOrDefault(x => x.AllowanceTypeId == allowances[i].AllowanceTypeId);

                        PayrunAllowanceSummary_Dto payrunAllowanceSummary = new PayrunAllowanceSummary_Dto();

                        payrunAllowanceSummary.Value = (decimal)allowances[j].Amount;
                        payrunAllowanceSummary.AllowanceTypeId = allowances[j].AllowanceTypeId;
                        payrunAllowanceSummary.EmployeeId = curEmployee.Id;

                        if (payrunAllowanceSummaryPrevious != null)
                        {
                            if (payrunAllowanceSummary.Value > payrunAllowanceSummaryPrevious.Value)
                            {
                                decimal allowanceDiff = payrunAllowanceSummary.Value - payrunAllowanceSummaryPrevious.Value;
                                payrunAllowanceSummary.Value = allowanceDiff;

                                grossEarnings += payrunAllowanceSummary.Value;
                            }
                            else
                            {
                                decimal allowanceDiff = payrunAllowanceSummaryPrevious.Value - payrunAllowanceSummary.Value;
                                payrunAllowanceSummary.Value = allowanceDiff;

                                grossDeductions += payrunAllowanceSummary.Value;
                            }
                        }
                        else
                        {
                            grossEarnings += payrunAllowanceSummary.Value;
                        }

                        empPayrunDetail.PayrunAllowancesSummaries.Add(payrunAllowanceSummary);
                    }

                    //Calculate GOSI
                    decimal gosiAmount = 0;
                    DictionaryValue_Dto employeeType = curEmployee.EmployeeType;
                    if (employeeType.Key == AppSettings.PermanantEmployeeTypeKey.ToString())
                    {
                        if (curEmployee.Nationality.Value.Contains("Saudi") || curEmployee.Nationality.Value.Contains("KSA"))
                        {
                            double gosi10Perc = curBasicSalary / 100 * 10;
                            double gosi11Perc = curBasicSalary / 100 * 11;
                            //empPayrunDetail.BasicSalary -= (decimal)gosi10Perc;

                            gosiAmount = (decimal)(gosi11Perc - gosi10Perc);
                        }
                        else
                        {
                            double gosi2Perc = curBasicSalary / 100 * 2;
                            //double gosi11Perc = curBasicSalary / 100 * 11;
                            //empPayrunDetail.BasicSalary -= (decimal)gosi2Perc;

                            gosiAmount = (decimal)gosi2Perc;
                        }
                    }
                    empPayrunDetail.GOSIAmount = gosiAmount;
                    grossDeductions += gosiAmount;

                    empPayrunDetail.GrossEarnings = grossEarnings;
                    empPayrunDetail.GrossDeductions = grossDeductions;
                    empPayrunDetail.NetAmount = grossEarnings - grossDeductions;

                    empPayrunDetail.DifferAmount = empPayrunDetail.NetAmount;

                    payrunDetails.Add(empPayrunDetail);
                }

                if (payrun == null) payrun = new Payrun_Dto();

                payrun.PayrunDetails = payrunDetails;
                payrun.Year = year;
                payrun.Month = month;
                payrun.CompanyId = CompanyId;

                payrun.TotalEarnings = payrunDetails.Sum(x => x.GrossEarnings);
                payrun.TotalDeductions = payrunDetails.Sum(x => x.GrossDeductions);
                payrun.NetTotal = payrun.TotalEarnings - payrun.TotalDeductions;

                Payrun_Dto payrunGenerated = null;
                if (!exists)
                    payrunGenerated = await PayrunAppService.CreateAsync(payrun);
                //else
                //    payrunGenerated = await PayrunAppService.UpdateAsync(payrun.Id, payrun);

                return new JsonResult(payrunGenerated);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
        public async Task<IActionResult> OnPostPayrun(int month, int year, string note)
        {
            var formData = Request.Form;

            Payrun payrun = PayrunAppService.Repository.SingleOrDefault(x => x.Month == month && x.Year == year);
            IFormFile attachment = formData.Files[0];
            if (attachment != null)
            {
                string uploadedFileName = UploadedFile(attachment);
                payrun.AttachmentFile = uploadedFileName;
            }

            if (payrun != null)
            {
                payrun.IsPosted = true;
                payrun.Note = note;
                payrun.PostedByTemp = CurrentUser.UserName;
                payrun.PostedDate = DateTime.Now;

                var result = await PayrunAppService.Repository.UpdateAsync(payrun);

                return NoContent();
            }
            else
                return StatusCode(500);
        }

        private string UploadedFile(IFormFile file)
        {
            string uniqueFileName = null;

            if (file != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                uniqueFileName = ((new Random()).Next(1, 9) * 564654).ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public List<GridColumn> GetCommandsColumns()
        {
            List<object> commands = new List<object>();
            commands.Add(new { type = "ViewPayslip", buttonOption = new { iconCss = "zmdi zmdi-file-text", cssClass = "e-flat" } });
            //commands.Add(new { type = "Delete", buttonOption = new { iconCss = "e-icons e-delete", cssClass = "e-flat" } });
            //commands.Add(new { type = "Save", buttonOption = new { iconCss = "e-icons e-update", cssClass = "e-flat" } });
            //commands.Add(new { type = "Cancel", buttonOption = new { iconCss = "e-icons e-cancel-icon", cssClass = "e-flat" } });

            return new List<GridColumn>()
            {
                new GridColumn { Width = "75", HeaderText = "", TextAlign=TextAlign.Center, MinWidth="10", Commands = commands }
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
            earningsColumns.Add(new GridColumn() { Field = $"grossEarnings", HeaderText = "Total", TextAlign = TextAlign.Center, MinWidth = "50" });

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
                                                 new GridColumn() { Field = "grossDeductions", HeaderText = "Total", TextAlign = TextAlign.Center, MinWidth = "50" },
                                             }
            });

            gridColumns.Add(new GridColumn { Field = "netAmount", HeaderText = "Net Amount", TextAlign = TextAlign.Center, MinWidth = "50" });

            gridColumns.AddRange(GetCommandsColumns());

            return gridColumns;
        }
        public List<GridColumn> GetSecondaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>() {
                new GridColumn { Field = "allowanceType.value", HeaderText = "Description", TextAlign=TextAlign.Center,  MinWidth="40"  },
                new GridColumn { Field = "value", HeaderText = "Amount", TextAlign=TextAlign.Center,  MinWidth="50"  }
            };

            return gridColumns;
        }
    }
}
