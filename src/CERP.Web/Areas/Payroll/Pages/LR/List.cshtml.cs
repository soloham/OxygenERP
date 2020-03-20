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

namespace CERP.Web.Areas.Payroll.Pages.LR
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
