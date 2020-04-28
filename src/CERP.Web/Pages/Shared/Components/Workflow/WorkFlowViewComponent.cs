using CERP.App;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace CERP.Web.Pages.Shared.Components
{
    public class WorkFlowViewComponent : AbpViewComponent
    {
        public WorkFlowViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(WorkflowModule WorkflowModule, string Id, string ParentTitle)
        {
            WorkFlowVCModel model = new WorkFlowVCModel(Id, WorkflowModule, ParentTitle);

            return View(model);
        }
    }

    public class WorkFlowVCModel
    {
        public WorkFlowVCModel(string id, WorkflowModule workflowModule, string parentTitle)
        {
            Id = id;
            WorkflowModule = workflowModule;

            List<object> ApprovalRouteCommands = new List<object>();
            ApprovalRouteCommands.Add(new { type = "Delete", buttonOption = new { iconCss = "e-icons e-delete", cssClass = "e-flat e-DeleteButton" } });
            ApprovalRouteCommands.Add(new { type = "Cancel", buttonOption = new { iconCss = "e-icons e-cancel-icon", cssClass = "e-flat" } });
            ApprovalRouteCommands.Add(new { type = "Save", buttonOption = new { iconCss = "e-icons e-update", cssClass = "e-flat" } });
            ApprovalRouteCommands.Add(new { type = "MoveUp", buttonOption = new { iconCss = "e-icons e-c-moveup", cssClass = "e-flat" } });
            ApprovalRouteCommands.Add(new { type = "MoveDown", buttonOption = new { iconCss = "e-icons e-c-movedown", cssClass = "e-flat" } });
            ApprovalRouteCommands.Add(new { type = "Edit", buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat" } });

            ApprovalRouteGridColumns = new List<GridColumn>()
            {
                new GridColumn { Field = "id", Visible=false, ShowInColumnChooser=false, IsPrimaryKey=true  },
                new GridColumn { Field = "apId", Visible=false, ShowInColumnChooser=false },
                new GridColumn { Field = "routeIndex", Visible = false, HeaderText = "Route Index", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "active", AllowSorting = false, AutoFit=true, HeaderText = "Active", EditType="booleanEdit", DisplayAsCheckBox=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "notifyEmployee", AllowSorting = false, AutoFit=true, HeaderText = "Notify", EditType="booleanEdit", DisplayAsCheckBox=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "isPoster", AllowSorting = false, AutoFit=true, HeaderText = "Allow Posting", EditType="booleanEdit", DisplayAsCheckBox=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "getAllDepartmentNames", AllowSorting = false, AutoFit=true, HeaderText = "Department", AllowEditing=false, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "getAllPositionTitles", AllowSorting = false, AutoFit=true, HeaderText = "Position", AllowEditing=false, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "getAllEmployeeNames", AllowSorting = false,AutoFit=true, HeaderText = "Employee", AllowEditing=false, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Width = "50", HeaderText = "Actions", TextAlign=TextAlign.Center, MinWidth="10", Commands = ApprovalRouteCommands }
            };

            List<object> TasksCommands = new List<object>();
            TasksCommands.Add(new { type = "Delete", buttonOption = new { iconCss = "e-icons e-delete", cssClass = "e-flat e-DeleteButton" } });
            TasksCommands.Add(new { type = "Cancel", buttonOption = new { iconCss = "e-icons e-cancel-icon", cssClass = "e-flat" } });
            TasksCommands.Add(new { type = "Save", buttonOption = new { iconCss = "e-icons e-update", cssClass = "e-flat" } });
            TasksCommands.Add(new { type = "MoveUp", buttonOption = new { iconCss = "e-icons e-c-moveup", cssClass = "e-flat" } });
            TasksCommands.Add(new { type = "MoveDown", buttonOption = new { iconCss = "e-icons e-c-movedown", cssClass = "e-flat" } });
            TasksCommands.Add(new { type = "Edit", buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat" } });

            TasksGridColumns = new List<GridColumn>()
            {
                new GridColumn { Field = "id", Visible=false, ShowInColumnChooser=false, IsPrimaryKey=true  },
                new GridColumn { Field = "routeIndex", Visible = false, HeaderText = "Route Index", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "active", AllowSorting = false, AutoFit=true, HeaderText = "Active", EditType="booleanEdit", DisplayAsCheckBox=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "notifyEmployee", AllowSorting = false, AutoFit=true, HeaderText = "Notify", EditType="booleanEdit", DisplayAsCheckBox=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "getAllDepartmentNames", AllowSorting = false, AutoFit=true, HeaderText = "Department", AllowEditing=false, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "getAllPositionTitles", AllowSorting = false, AutoFit=true, HeaderText = "Position", AllowEditing=false, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "getAllEmployeeNames", AllowSorting = false,AutoFit=true, HeaderText = "Employee", AllowEditing=false, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "taskDescription", AllowSorting = false, AutoFit=true, HeaderText = "Description", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Width = "50", HeaderText = "Actions", TextAlign=TextAlign.Center, MinWidth="10", Commands = TasksCommands }
            };

            APTasksGridColumns = new List<GridColumn>()
            {
                new GridColumn { Field = "id", Visible=false, ShowInColumnChooser=false, IsPrimaryKey=true  },
                new GridColumn { Field = "apId", Visible=false, ShowInColumnChooser=false },
                new GridColumn { Field = "routeIndex", Visible = false, HeaderText = "Route Index", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "active", AllowSorting = false, AutoFit=true, HeaderText = "Active", EditType="booleanEdit", DisplayAsCheckBox=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "notifyEmployee", AllowSorting = false, AutoFit=true, HeaderText = "Notify", EditType="booleanEdit", DisplayAsCheckBox=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "getAllDepartmentNames", AllowSorting = false, AutoFit=true, HeaderText = "Department", AllowEditing=false, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "getAllPositionTitles", AllowSorting = false, AutoFit=true, HeaderText = "Position", AllowEditing=false, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "getAllEmployeeNames", AllowSorting = false,AutoFit=true, HeaderText = "Employee", AllowEditing=false, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "taskDescription", AllowSorting = false, AutoFit=true, HeaderText = "Description", TextAlign=TextAlign.Center,  MinWidth="10"  },
            };

            APSecondaryDetailsGrid = new Grid()
            {
                DataSource = new List<dynamic>(),
                QueryString = "apId",
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
                Columns = APTasksGridColumns
            };
            ParentTitle = parentTitle;
        }

        public string Id { get; set; }
        public WorkflowModule WorkflowModule { get; set; }
        public string ParentTitle { get; set; }

        public List<GridColumn> ApprovalRouteGridColumns { get; set; } = new List<GridColumn>();
        public List<GridColumn> TasksGridColumns { get; set; } = new List<GridColumn>();
        public List<GridColumn> APTasksGridColumns { get; set; } = new List<GridColumn>();
        public Grid APSecondaryDetailsGrid { get; set; } = new Grid();
    }
}
