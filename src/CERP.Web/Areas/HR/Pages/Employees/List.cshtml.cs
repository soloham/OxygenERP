using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CERP.AppServices.HR.EmployeeService;
using CERP.HR.Employees.DTOs;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Grids;

namespace CERP.Web.Areas.HR.Pages.Employees
{
    public class ListModel : CERPPageModel
    {
        private readonly EmployeeAppService employeeAppService;
        public Grid SecondaryDetailsGrid = new Grid();
        public ListModel(EmployeeAppService _employeeAppService)
        {
            employeeAppService = _employeeAppService;
        }

        public void OnGet()
        {
            List<Employee_Dto> Employees = employeeAppService.GetAllEmployees();

            SecondaryDetailsGrid = new Grid()
            {
                DataSource = null,
                QueryString = "Id",
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
            //List<COA_Account_Dto> COAs = (await _coaAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto())).Items.ToList();

            ViewData["Employees_DS"] = Employees;
            ViewData["alertbutton"] = new
            {
                content = "OK",
                isPrimary = true
            };
        }

        public List<GridColumn> GetCommandsColumns()
        {
            List<object> commands = new List<object>();
            commands.Add(new { type = "Copy", buttonOption = new { iconCss = "e-icons e-copy", cssClass = "e-flat" } });
            commands.Add(new { type = "Edit", buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat" } });
            commands.Add(new { type = "Delete", buttonOption = new { iconCss = "e-icons e-delete", cssClass = "e-flat" } });
            commands.Add(new { type = "Save", buttonOption = new { iconCss = "e-icons e-update", cssClass = "e-flat" } });
            commands.Add(new { type = "Cancel", buttonOption = new { iconCss = "e-icons e-cancel-icon", cssClass = "e-flat" } });

            return new List<GridColumn>()
            {
                new GridColumn { Width = "200", HeaderText = "Commands", TextAlign=TextAlign.Center, MinWidth="10", Commands = commands }
            };
        }

        public List<GridColumn> GetPrimaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>() {
                new GridColumn { Field = "EmployeeId", Width = "110", HeaderText = "Id", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "Name", Width = "230", HeaderText = "Name", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "Department.Name", AutoFit = true, HeaderText = "Department", TextAlign=TextAlign.Center, },
                new GridColumn { Field = "Position.Title", AutoFit = true, HeaderText = "Position", TextAlign=TextAlign.Center,  },
                new GridColumn { Field = "IqamaNo", AutoFit = true, HeaderText = "Iqama No", TextAlign=TextAlign.Center  },
                new GridColumn { Field = "Email", AutoFit = true, HeaderText = "Email", TextAlign=TextAlign.Center},
            };

            gridColumns.AddRange(GetCommandsColumns());

            return gridColumns;
        }
        public List<GridColumn> GetSecondaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>();



            return gridColumns;
        }

    }
}
