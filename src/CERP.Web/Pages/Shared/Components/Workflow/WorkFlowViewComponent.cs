using CERP.App;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Volo.Abp.AspNetCore.Mvc;
using static CERP.Web.Pages.Shared.Components.WorkFlowVCModel;
using Volo.Abp.Json;
using System.ComponentModel;
using CERP.App.Helpers;

namespace CERP.Web.Pages.Shared.Components
{
    public class WorkFlowViewComponent : AbpViewComponent
    {
        public IJsonSerializer JsonSerializer { get; set; }

        public WorkFlowViewComponent(IJsonSerializer jsonSerializer)
        {
            JsonSerializer = jsonSerializer;
        }

        public async Task<IViewComponentResult> InvokeAsync(WorkflowModule WorkflowModule, string Id, string ParentTitle, List<WorkflowFormField> externalFormFields)
        {
            WorkFlowVCModel model = new WorkFlowVCModel(Id, WorkflowModule, ParentTitle, externalFormFields, JsonSerializer);

            return View(model);
        }
    }

    public class WorkFlowVCModel
    {
        public IJsonSerializer JsonSerializer { get; set; }
        public WorkFlowVCModel(string id, WorkflowModule workflowModule, string parentTitle, List<WorkflowFormField> externalFormFields, IJsonSerializer jsonSerializer)
        {
            Id = id;
            ParentTitle = parentTitle;
            WorkflowModule = workflowModule;
            Form.FormFields.AddRange(externalFormFields);

            #region GridsConfigs
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
            JsonSerializer = jsonSerializer;
            #endregion
        }

        public string Id { get; set; }
        public WorkflowModule WorkflowModule { get; set; }
        public string ParentTitle { get; set; }

        public WorkflowForm Form { get; } = new WorkflowForm();

        public List<GridColumn> ApprovalRouteGridColumns { get; set; } = new List<GridColumn>();
        public List<GridColumn> TasksGridColumns { get; set; } = new List<GridColumn>();
        public List<GridColumn> APTasksGridColumns { get; set; } = new List<GridColumn>();
        public Grid APSecondaryDetailsGrid { get; set; } = new Grid();

        public List<GridColumn> GetFormFieldsGridColumns()
        {
            List<object> FFCommands = new List<object>();
            FFCommands.Add(new { type = "Delete", buttonOption = new { iconCss = "e-icons e-delete", cssClass = "e-flat e-DeleteButton" } });
            FFCommands.Add(new { type = "MoveUp", buttonOption = new { iconCss = "e-icons e-c-moveup", cssClass = "e-flat" } });
            FFCommands.Add(new { type = "MoveDown", buttonOption = new { iconCss = "e-icons e-c-movedown", cssClass = "e-flat" } });

            List<GridColumn> FFGridColumns = new List<GridColumn>()
            {
                new GridColumn { Field = "id", Visible=false, ShowInColumnChooser=false, IsPrimaryKey=true  },
                new GridColumn { Field = "name", AllowEditing=false, AllowSorting = false, HeaderText = "Name", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "viewIndex", Visible=false, AllowSorting = false, AutoFit=true, HeaderText = "", TextAlign=TextAlign.Center,  MinWidth="10" },
                new GridColumn { Field = "isReadonly", AllowSorting = false, AutoFit=true, HeaderText = "Readonly", EditType="booleanEdit", DisplayAsCheckBox=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "fieldTypeDescription", AllowSorting = false, AllowEditing=false, HeaderText = "Type", TextAlign=TextAlign.Center,  MinWidth="10"  },

                new GridColumn { Width = "50", HeaderText = "", TextAlign=TextAlign.Center, MinWidth="10", Commands = FFCommands }
            };

            return FFGridColumns;
        }
        public string GetFormFieldsAsDS()
        {
            List<WorkflowFormField> formFieldsDS = new List<WorkflowFormField>();

            for (int i = 0; i < Form.FormFields.Count; i++)
            {
                WorkflowFormField field = Form.FormFields[i];
                if(field.IsVisible)
                    formFieldsDS.Add(field);
            }

            return JsonSerializer.Serialize(formFieldsDS);
        }

        public class WorkflowForm
        {
            public List<WorkflowFormField> FormFields { get; set; } = new List<WorkflowFormField>();
        }
        public class WorkflowFormField
        {
            public int Id { get; set; }
            public int ViewIndex { get; set; }
            public string Name { get; set; }
            public string MappingName { get; set; }
            public bool IsReadonly { get; set; }
            public bool IsExternal { get; set; }
            public bool IsVisible { get; set; }

            public string FieldTypeDescription { get => EnumExtensions.GetDescription(FieldType); set => FieldType = EnumExtensions.GetValueFromDescription<WorkflowFormFieldType>(value); }
            public WorkflowFormFieldType FieldType { get; set; }
        }
        public enum WorkflowFormFieldType
        {
            [Description("System")]
            System,
            [Description("Custom")]
            Custom
        }
    }
}
