using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CERP.App;
using CERP.AppServices.HR.DepartmentService;
using CERP.AppServices.HR.WorkShiftService;
using CERP.AppServices.Setup.DepartmentSetup;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Workshifts;
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

namespace CERP.Web.Areas.HR.Pages.TimeSheets
{
    public class ListModel : CERPPageModel
    {
        public IGuidGenerator guidGenerator { get; set; }
        public IJsonSerializer JsonSerializer { get; set; }

        public TimesheetAppService TimesheetAppService { get; set; }
        public Grid GetSecondaryGrid { get; set; }
        public ListModel(IGuidGenerator guidGenerator, IJsonSerializer jsonSerializer, TimesheetAppService timesheetAppService)
        {
            this.guidGenerator = guidGenerator;
            JsonSerializer = jsonSerializer;
            TimesheetAppService = timesheetAppService;
        }

        public void OnGet()
        {
            List<Timesheet_Dto> timesheets = TimesheetAppService.GetTimesheetsSummary();
            ViewData["Timesheets_DS"] = JsonSerializer.Serialize(timesheets);
            ViewData["Timesheets_ChildDS"] = JsonSerializer.Serialize(timesheets.SelectMany(x => x.WeeklySummaries).ToList());

            GetSecondaryGrid = new Grid()
            {
                DataSource = ViewData["Timesheets_ChildDS"],
                QueryString = "employeeId",
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

        public List<GridColumn> GetCommandsColumns()
        {
            List<object> commands = new List<object>();
            commands.Add(new { type = "Edit", buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat" } });

            return new List<GridColumn>()
            {
                new GridColumn { Width = "65", HeaderText = "", TextAlign=TextAlign.Center, MinWidth="10", Commands = commands }
            };
        }
        public List<GridColumn> GetSecondaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>() {
                new GridColumn { Field = "week", HeaderText = "Week", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "description", DefaultValue="—", HeaderText = "Description", TextAlign=TextAlign.Center,  MinWidth="20"  },
                new GridColumn { Field = "", HeaderText = "Daily Hours", TextAlign=TextAlign.Center,  MinWidth="10", 
                    Columns = new List<GridColumn>(){
                        new GridColumn { Field = "sumSun", HeaderText = "Sunday", TextAlign=TextAlign.Center,  MinWidth="40"  },
                        new GridColumn { Field = "sumMon", HeaderText = "Monday", TextAlign=TextAlign.Center,  MinWidth="40"  },
                        new GridColumn { Field = "sumTue", HeaderText = "Tuesday", TextAlign=TextAlign.Center,  MinWidth="40"  },
                        new GridColumn { Field = "sumWed", HeaderText = "Wednesday", TextAlign=TextAlign.Center,  MinWidth="40"  },
                        new GridColumn { Field = "sumThu", HeaderText = "Thursday", TextAlign=TextAlign.Center,  MinWidth="40"  },
                        new GridColumn { Field = "sumFri", HeaderText = "Friday", TextAlign=TextAlign.Center,  MinWidth="40"  },
                        new GridColumn { Field = "sumSat", HeaderText = "Satday", TextAlign=TextAlign.Center,  MinWidth="40"  },
                    } 
                },
                new GridColumn { Field = "totalWeekHours", HeaderText = "Total Hours", TextAlign=TextAlign.Center,  MinWidth="30" },
                new GridColumn { Field = "isSubmitted", DisplayAsCheckBox=true, HeaderText = "Submitted", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "getProgress", DefaultValue="—", Template = "#progressColTemplate", HeaderText = "Progress", TextAlign=TextAlign.Center,  MinWidth="10"  }
            };

            return gridColumns;
        }
        public List<GridColumn> GetPrimaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>() {
                new GridColumn { Field = "employee.getReferenceId", HeaderText = "Emp Id", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "employee.name", HeaderText = "Employee", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "employee.department.name", HeaderText = "Department", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "getMonth", HeaderText = "Month", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "year", HeaderText = "Year", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "description", DefaultValue="—", HeaderText = "Description", TextAlign=TextAlign.Center,  MinWidth="20"  },
                new GridColumn { Field = "", HeaderText = "Weekly Hours", TextAlign=TextAlign.Center,  MinWidth="10", 
                    Columns = new List<GridColumn>(){
                        new GridColumn { Field = "week1Hours", Template = "#week1ColTemplate", HeaderText = "1st Week", TextAlign=TextAlign.Center,  MinWidth="40"  },
                        new GridColumn { Field = "week2Hours", Template = "#week2ColTemplate", HeaderText = "2nd Week", TextAlign=TextAlign.Center,  MinWidth="40"  },
                        new GridColumn { Field = "week3Hours", Template = "#week3ColTemplate", HeaderText = "3rd Week", TextAlign=TextAlign.Center,  MinWidth="40"  },
                        new GridColumn { Field = "week4Hours", Template = "#week4ColTemplate", HeaderText = "4th Week", TextAlign=TextAlign.Center,  MinWidth="40"  },
                        new GridColumn { Field = "week5Hours", Template = "#week5ColTemplate", HeaderText = "5th Week", TextAlign=TextAlign.Center,  MinWidth="40"  },
                    } 
                },
                new GridColumn { Field = "totalMonthHours", DefaultValue="—", HeaderText = "Total Hours", TextAlign=TextAlign.Center,  MinWidth="30" },
                new GridColumn { Field = "isPosted", DisplayAsCheckBox=true, HeaderText = "Posted", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "getProgress", DefaultValue="—", Template = "#progressColTemplate", HeaderText = "Progress", TextAlign=TextAlign.Center,  MinWidth="10"  }
            };

            gridColumns.AddRange(GetCommandsColumns());

            return gridColumns;
        }
    }
}
