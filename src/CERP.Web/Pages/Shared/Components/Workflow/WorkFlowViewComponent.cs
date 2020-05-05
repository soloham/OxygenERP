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

            List<ActionNotificationSetting> actionNotificationSettings = new List<ActionNotificationSetting>();
            actionNotificationSettings.Add(new ActionNotificationSetting() { Action = ActionType.Start });
            actionNotificationSettings.Add(new ActionNotificationSetting() { Action = ActionType.Successful });
            actionNotificationSettings.Add(new ActionNotificationSetting() { Action = ActionType.Failed });
            actionNotificationSettings.Add(new ActionNotificationSetting() { Action = ActionType.Deligated });
            actionNotificationSettings.Add(new ActionNotificationSetting() { Action = ActionType.Edit });

            Notifications.ActionNotificationSettings = actionNotificationSettings;

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
        public ActionNotifications Notifications { get; } = new ActionNotifications();

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
                new GridColumn { Field = "id", AutoFit=true, Visible=false, ShowInColumnChooser=false, IsPrimaryKey=true  },
                new GridColumn { Field = "name", AutoFit=true, AllowEditing=false, AllowSorting = false, HeaderText = "Name", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "viewIndex", AutoFit=true, Visible=false, AllowSorting = false, HeaderText = "", TextAlign=TextAlign.Center,  MinWidth="10" },
                new GridColumn { Field = "isView", AllowSorting = false, AutoFit=true, HeaderText = "View", EditType="booleanEdit", DisplayAsCheckBox=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "isEdit", AutoFit=true, AllowSorting = false, HeaderText = "Edit", EditType="booleanEdit", DisplayAsCheckBox=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "fieldTypeDescription", AllowSorting = false, AllowEditing=false, HeaderText = "Type", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "isEditNotification", AllowSorting = false, AutoFit=true, HeaderText = "Show Notifications", EditType="booleanEdit", DisplayAsCheckBox=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "editNotification", AllowSorting = false, AutoFit=true, HeaderText = "Edit Notification", TextAlign=TextAlign.Center,  MinWidth="10"  },

                new GridColumn { Width = "50", HeaderText = "", TextAlign=TextAlign.Center, MinWidth="10", Commands = FFCommands }
            };

            return FFGridColumns;
        }
        public List<GridColumn> GetCustomFormFieldsGridColumns()
        {
            List<object> FFCommands = new List<object>();
            FFCommands.Add(new { type = "Delete", buttonOption = new { iconCss = "e-icons e-delete", cssClass = "e-flat e-DeleteButton" } });

            List<GridColumn> FFGridColumns = new List<GridColumn>()
            {
                new GridColumn { Field = "id", Visible=false, ShowInColumnChooser=false, IsPrimaryKey=true  },
                new GridColumn { Field = "type", AllowEditing=false, AllowSorting = false, HeaderText = "Type", TextAlign=TextAlign.Center,  MinWidth="10" },
                new GridColumn { Field = "fieldName", AllowEditing=true, AllowSorting = true, HeaderText = "Name", TextAlign=TextAlign.Center,  MinWidth="10"  },

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
        public List<GridColumn> GetNotificationsGridColumns()
        {
            List<GridColumn> FFGridColumns = new List<GridColumn>()
            {
                new GridColumn { Field = "action", Visible=false, IsPrimaryKey=true },
                new GridColumn { Field = "actionDescription", AutoFit=true, HeaderText = "Action", AllowEditing=false, TextAlign=TextAlign.Center, MinWidth="10" },
                new GridColumn { Field = "requester", AutoFit=true, HeaderText = "Requester", EditType="booleanedit", DisplayAsCheckBox=true, AllowEditing=true, TextAlign=TextAlign.Center,  MinWidth="10" },
                new GridColumn { Field = "head", AutoFit=true, HeaderText = "Department Head", EditType="booleanedit", DisplayAsCheckBox=true, AllowEditing=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "preceding", AutoFit=true, HeaderText = "Preceding", EditType="booleanedit", DisplayAsCheckBox=true, AllowEditing=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "workflowManager", AutoFit=true, HeaderText = "Workflow Manager", EditType="booleanedit", DisplayAsCheckBox=true, AllowEditing=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "customMessage", AutoFit=true, HeaderText = "Custom Message", AllowEditing=true, TextAlign=TextAlign.Center,  MinWidth="10"  },
            };

            return FFGridColumns;
        }
        public string GetNotificationsAsDS()
        {
            return JsonSerializer.Serialize(Notifications.ActionNotificationSettings);
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
            public bool IsView { get; set; }
            public bool IsEdit { get; set; }
            public bool IsEditNotification { get; set; }
            public string EditNotification { get; set; }
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

        public class ActionNotifications
        {
            public List<ActionNotificationSetting> ActionNotificationSettings { get; set; } = new List<ActionNotificationSetting>();
        }
        public class ActionNotificationSetting
        {
            public ActionType Action { get; set; }
            public string ActionDescription { get => EnumExtensions.GetDescription(Action); set => Action = EnumExtensions.GetValueFromDescription<ActionType>(value); }

            public bool Requester { get; set; } = true;
            public bool Head { get; set; } = true;
            public bool Preceding { get; set; } = true;
            public bool WorkflowManager { get; set; } = true;
            public string CustomMessage { get; set; } = "";
        }
        public enum ActionType
        {
            [Description("Start")]
            Start,
            [Description("Successful")]
            Successful,
            [Description("Failed")]
            Failed,
            [Description("Deligated")]
            Deligated,
            [Description("Edit")]
            Edit
        }
    }
}
