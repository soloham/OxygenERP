using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CERP.AppServices.HR.EmployeeService;
using CERP.HR.EMPLOYEE.RougeDTOs;
using CERP.HR.Employees.DTOs;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.OpenApi.Extensions;
using Syncfusion.EJ2.Grids;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Json;

namespace CERP.Web.Areas.HR.Pages.Employees
{
    public class ListModel : CERPPageModel
    {
        public IAuditLogRepository AuditLogsRepo { get; set; }
        private readonly EmployeeAppService employeeAppService;


        public Grid SecondaryDetailsGrid = new Grid();

        public IJsonSerializer JsonSerializer { get; set; }

        public ListModel(EmployeeAppService _employeeAppService, IJsonSerializer jsonSerializer, IAuditLogRepository auditLogsRepo)
        {
            employeeAppService = _employeeAppService;
            JsonSerializer = jsonSerializer;
            AuditLogsRepo = auditLogsRepo;
        }

        public void OnGet()
        {
            List<Employee_Dto> Employees = employeeAppService.GetAllEmployees();
            Employees.ForEach(x => x.ProfilePic = x.ProfilePic == "" ? x.ProfilePic = "noimage.jpg" : x.ProfilePic);
            List<PhysicalId<Guid>> physicalIDs = (Employees.Count > 0) ? (List<PhysicalId<Guid>>)Employees.SelectMany(x => (JsonSerializer.Deserialize<GeneralInfo>(x.ExtraProperties["generalInfo"].ToString()).PhysicalIds)).ToList() : new List<PhysicalId<Guid>>();

            SecondaryDetailsGrid = new Grid()
            {
                DataSource = physicalIDs,
                Load = "onLoad",
                QueryString = "EmployeeId",
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
        public dynamic GetDataAuditTrailModel()
        {
            dynamic result = new ExpandoObject();

            List<GridColumn> primaryGridColumns = new List<GridColumn>()
            {
                new GridColumn { Field = "AuditLogId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "EntityChangeId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Id", HeaderText = "Id", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "EmpName", HeaderText = "Employee", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Date", HeaderText = "Date", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Time", HeaderText = "Time", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "User", HeaderText = "User", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Status", HeaderText = "Status", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
            };

            result.primaryGridColumns = primaryGridColumns;

            List<GridColumn> secondaryGridColumns = new List<GridColumn>()
            {
                new GridColumn { Field = "EntityChangeId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "TypeId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Type", HeaderText = "Type", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Status", HeaderText = "New Value", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },

            };
            List<GridColumn> tertiaryGridColumns = new List<GridColumn>()
            {
                new GridColumn { Field = "EntityChangeId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "TypeId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Field", HeaderText = "Field", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "NewValue", HeaderText = "New Value", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "OriginalValue", HeaderText = "Original Value", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
            };

            Grid SecondaryAGTGrid = new Grid()
            {
                DataSource = new List<dynamic>(),
                QueryString = "EntityChangeId",
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
                ContextMenuItems = new List<object>() { "AutoFit", "AutoFitAll", "SortAscending", "SortDescending", "Copy", "Edit", "Delete", "Save", "Cancel", "PdfExport", "ExcelExport", "CsvExport", "FirstPage", "PrevPage", "LastPage", "NextPage" },
                Columns = secondaryGridColumns
            };
            Grid TertiaryAGTGrid = new Grid()
            {
                DataSource = new List<dynamic>(),
                QueryString = "TypeId",
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
                ContextMenuItems = new List<object>() { "AutoFit", "AutoFitAll", "SortAscending", "SortDescending", "Copy", "Edit", "Delete", "Save", "Cancel", "PdfExport", "ExcelExport", "CsvExport", "FirstPage", "PrevPage", "LastPage", "NextPage" },
                Columns = tertiaryGridColumns
            };
            SecondaryAGTGrid.ChildGrid = TertiaryAGTGrid;

            result.secondaryGrid = SecondaryAGTGrid;
            result.dataSource = null;

            return result;
        }

        public async Task<JsonResult> OnGetDataAuditTrail()
        {
            dynamic result = new ExpandoObject();
            List<dynamic> DS = new List<dynamic>();
            List<dynamic> secondaryDS = new List<dynamic>();
            List<dynamic> tertiaryDS = new List<dynamic>();
            var employeeLogs = AuditLogsRepo.WithDetails().Where(x => x.Url == "/HR/Employee" && x.EntityChanges != null && x.EntityChanges.Count > 0).ToList();

            List<Employee_Dto> Employees = employeeAppService.GetAllEmployees();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            for (int i = 0; i < employeeLogs.Count; i++)
            {
                AuditLog auditLog = employeeLogs[i];
                if (auditLog.EntityChanges == null || auditLog.EntityChanges.Count == 0) continue;
                var entityChanges = auditLog.EntityChanges.ToList();
                for (int j = 0; j < entityChanges.Count; j++)
                {
                    EntityChange entityChange = entityChanges[j];

                    dynamic changeRow = new ExpandoObject();
                    changeRow.AuditLogId = entityChange.Id;
                    changeRow.EntityChangeId = entityChange.Id;

                    Employee_Dto emp = Employees.First(x => x.Id.ToString() == entityChange.EntityId);
                    changeRow.Id = emp.GetReferenceId;
                    changeRow.EmpName = emp.Name;
                    changeRow.Date = entityChange.ChangeTime.ToShortDateString();
                    changeRow.Time = entityChange.ChangeTime.ToShortTimeString();
                    changeRow.User = auditLog.UserName;
                    changeRow.Status = entityChange.ChangeType.GetDisplayName();

                    DS.Add(changeRow);

                    dynamic generalTypeRow = new ExpandoObject();
                    generalTypeRow.EntityChangeId = entityChange.Id;
                    generalTypeRow.TypeId = 1;
                    generalTypeRow.Type = "General";
                    generalTypeRow.Name = "";
                    generalTypeRow.Status = "Updated";

                    secondaryDS.Add(generalTypeRow);

                    var generalPropertyChanges = entityChange.PropertyChanges.ToList();

                    for (int k = 0; k < generalPropertyChanges.Count; k++)
                    {
                        EntityPropertyChange propertyChange = generalPropertyChanges[k];
                        dynamic propertyChangeRow = new ExpandoObject();
                        propertyChangeRow.TypeId = 1;
                        propertyChangeRow.EntityChangeId = propertyChange.EntityChangeId;
                        propertyChangeRow.Field = textInfo.ToTitleCase(propertyChange.PropertyName.ToSentenceCase());
                        propertyChangeRow.NewValue = propertyChange.NewValue != "null" && propertyChange.NewValue != "\"\""? propertyChange.NewValue.TrimStart('"').TrimEnd('"') : "—";
                        propertyChangeRow.OriginalValue = propertyChange.OriginalValue != "null" && propertyChange.OriginalValue != "\"\"" ? propertyChange.OriginalValue.TrimStart('"').TrimEnd('"') : "—"; ;

                        tertiaryDS.Add(propertyChangeRow);
                    }

                    List<EmployeeExtraPropertyHistory> extraPropertyHistories = entityChange.GetProperty<List<EmployeeExtraPropertyHistory>>("extraPropertiesHistory");
                    if (extraPropertyHistories != null && extraPropertyHistories.Count > 0)
                    {
                        foreach (EmployeeExtraPropertyHistory extraPropertyHistory in extraPropertyHistories)
                        {
                            dynamic typeRow = new ExpandoObject();
                            typeRow.EntityChangeId = entityChange.Id;
                            typeRow.TypeId = extraPropertyHistory.TypeId;
                            typeRow.Type = extraPropertyHistory.Type;
                            typeRow.Name = extraPropertyHistory.Name;
                            typeRow.Status = extraPropertyHistory.Status;

                            secondaryDS.Add(typeRow);

                            var propertyChanges = extraPropertyHistory.PropertyChanges.ToList();

                            for (int k = 0; k < propertyChanges.Count; k++)
                            {
                                EmployeeTypePropertyChange propertyChange = propertyChanges[k];
                                dynamic propertyChangeRow = new ExpandoObject();
                                propertyChangeRow.TypeId = extraPropertyHistory.TypeId;
                                propertyChangeRow.EntityChangeId = typeRow.EntityChangeId;
                                propertyChangeRow.Field = textInfo.ToTitleCase(propertyChange.PropertyName.ToSentenceCase());
                                propertyChangeRow.NewValue = propertyChange.NewValue != "null" && propertyChange.NewValue != "\"\"" ? propertyChange.NewValue.TrimStart('"').TrimEnd('"') : "—";
                                propertyChangeRow.OriginalValue = propertyChange.OriginalValue != "null" && propertyChange.OriginalValue != "\"\"" ? propertyChange.OriginalValue.TrimStart('"').TrimEnd('"') : "—"; ;

                                tertiaryDS.Add(propertyChangeRow);
                            }
                        }
                    }
                }
            }
            result.ds = DS;
            result.secondaryDS = secondaryDS;
            result.tertiaryDS = tertiaryDS;

            var secondaryGrid = new JsonResult(result);
            return secondaryGrid;
        }

        public List<GridColumn> GetCommandsColumns()
        {
            List<object> commands = new List<object>();
            //commands.Add(new { type = "Copy", buttonOption = new { iconCss = "e-icons e-copy", cssClass = "e-flat" } });
            commands.Add(new { type = "Edit", buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat" } });
            //commands.Add(new { type = "Delete", buttonOption = new { iconCss = "e-icons e-delete", cssClass = "e-flat" } });
            //commands.Add(new { type = "Save", buttonOption = new { iconCss = "e-icons e-update", cssClass = "e-flat" } });
            //commands.Add(new { type = "Cancel", buttonOption = new { iconCss = "e-icons e-cancel-icon", cssClass = "e-flat" } });

            return new List<GridColumn>()
            {
                new GridColumn {HeaderText = "Actions", TextAlign=TextAlign.Center, MinWidth="90", Commands = commands }
            };
        }

        public List<GridColumn> GetPrimaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>() {
                new GridColumn { Field = "GetReferenceId", MaxWidth="100", Width="100", HeaderText = "Id", TextAlign=TextAlign.Center,  MinWidth="90"  },
                new GridColumn { Field = "Name", Width="150", HeaderText = "Name", TextAlign=TextAlign.Center,  MinWidth="90"  },
                new GridColumn { Field = "Position.Department.Name", HeaderText = "Department", TextAlign=TextAlign.Center, },
                new GridColumn { Field = "Position.Title", HeaderText = "Position", TextAlign=TextAlign.Center,  },
                new GridColumn { Field = "Nationality.Value", HeaderText = "Nationality", Template="#coltemplate", Filter="@(new { type=\"CheckBox\"})",  TextAlign=TextAlign.Center  },
                new GridColumn { Field = "EmployeeStatus.Value", MinWidth="90", HeaderText = "Employee Status", Template="#statusTemplate", Filter="@(new { type='CheckBox', itemTemplate='#StatusItemTemp' })", TextAlign=TextAlign.Center  },
                new GridColumn { Field = "ReportingTo.Name", MinWidth="90", HeaderText = "Reporting To", Visible=false, TextAlign=TextAlign.Center  },
                new GridColumn { Field = "ContractStatus.Value", MinWidth="90", HeaderText = "Contract Status", Template="#contractStatusTemplate", Filter="@(new { type='CheckBox', itemTemplate='#ContractStatusItemTemp' })", Visible=false, TextAlign=TextAlign.Center  },
                new GridColumn { Field = "WorkShift.Title", MinWidth="90", HeaderText = "Workshift", Visible=false, TextAlign=TextAlign.Center  },
                new GridColumn { Field = "Religion.Value", MinWidth="90", HeaderText = "Religion", Visible=false, TextAlign=TextAlign.Center  },
                new GridColumn { Field = "MaritalStatus.Value", MinWidth="90", HeaderText = "Marital Status", Visible=false, TextAlign=TextAlign.Center  },
                new GridColumn { Field = "Gender.Value", MinWidth="90", HeaderText = "Gender", Visible=false, TextAlign=TextAlign.Center  },
                new GridColumn { Field = "POB.Value",MinWidth="90",  HeaderText = "Birth Place", Visible=false, TextAlign=TextAlign.Center  },
                new GridColumn { Field = "DOB", Format="", MinWidth="90", HeaderText = "Birth Date", Visible=false, TextAlign=TextAlign.Center  },
                new GridColumn { Field = "JoiningDate", Format="", MinWidth="90", HeaderText = "Joining Date", Visible=false, TextAlign=TextAlign.Center  },
                new GridColumn { Field = "EmployeeType.Value", Format="", MinWidth="90", HeaderText = "Type", Visible=false, TextAlign=TextAlign.Center  },
                new GridColumn { Field = "NoOfDependents", Format="", MinWidth="90", HeaderText = "Total Dependants", Visible=false, TextAlign=TextAlign.Center  },
                //new GridColumn { Field = "Creator.UserName", Format="", HeaderText = "Created By", Visible=false, TextAlign=TextAlign.Center  },
            };

            gridColumns.AddRange(GetCommandsColumns());

            return gridColumns;
        }
        public List<GridColumn> GetSecondaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>()
            {
                new GridColumn { Field = "IDType.Value", HeaderText = "Type", TextAlign=TextAlign.Center,  MinWidth="90"  },
                new GridColumn { Field = "IDNumber", HeaderText = "ID Number", TextAlign=TextAlign.Center,  MinWidth="90"  },
                new GridColumn { Field = "IssuedFrom.Value", HeaderText = "Issued From", TextAlign=TextAlign.Center,  MinWidth="90"  },
                new GridColumn { Field = "IssuedDate", Type = "date", Format = "dd/MM/yyyy", HeaderText = "Issue Date", TextAlign=TextAlign.Center,  MinWidth="90"  },
                new GridColumn { Field = "EndDate", Type = "date", Format = "dd/MM/yyyy", HeaderText = "End Date", TextAlign=TextAlign.Center,  MinWidth="90"  }
            }; 

            return gridColumns;
        }

    }
}
