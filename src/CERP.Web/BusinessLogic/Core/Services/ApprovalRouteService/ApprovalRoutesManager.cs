using CERP.App;
using CERP.AppServices.App.ApprovalRouteService;
using CERP.AppServices.App.TaskService;
using CERP.HR.Employees.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CERP.Web.BusinessLogic.Core.Services.ApprovalRouteService
{
    public class ApprovalRoutesManager : IApprovalRoutesManager
    {
        public ApprovalRoutesManager(ApprovalRouteTemplatesAppService approvalRouteTemplatesAppService, TaskTemplatesAppService taskTemplatesAppService, ApprovalRouteTemplateItemsAppService approvalRouteTemplateItemsAppService)
        {
            ApprovalRouteTemplatesAppService = approvalRouteTemplatesAppService;
            TaskTemplatesAppService = taskTemplatesAppService;
            ApprovalRouteTemplateItemsAppService = approvalRouteTemplateItemsAppService;

        }

        public ApprovalRouteTemplatesAppService ApprovalRouteTemplatesAppService { get; set; }
        public TaskTemplatesAppService TaskTemplatesAppService { get; set; }
        public ApprovalRouteTemplateItemsAppService ApprovalRouteTemplateItemsAppService { get; set; }

        public async Task<ApprovalRouteTemplate> ProcessApprovalRoutesUpdate(ApprovalRouteViewModelBase VM, ApprovalRouteTemplate _approvalRouteTemplate)
        {
            ApprovalRouteTemplate resultApprovalRouteTemplate = _approvalRouteTemplate;

            List<ApprovalRouteVM> vmApprovalRouteTemplateItems = VM.ApprovalRoute;
            ApprovalRouteTemplate approvalRouteTemplate = _approvalRouteTemplate;
            List<ApprovalRouteTemplateItem> approvalRouteTemplateItems = approvalRouteTemplate.ApprovalRouteTemplateItems.ToList();

            List<ApprovalRouteTemplateItem> toUpdateAPItems = new List<ApprovalRouteTemplateItem>();
            List<TaskTemplateItem> toUpdateAPTaskItems = new List<TaskTemplateItem>();
            List<ApprovalRouteTemplate> toDeleteApprovalRouteTemplates = new List<ApprovalRouteTemplate>();
            List<ApprovalRouteTemplateItemEmployee> toDeleteAPEmployeeItems = new List<ApprovalRouteTemplateItemEmployee>();
            List<TaskTemplate> toDeleteAPTaskTemplates = new List<TaskTemplate>();
            List<TaskTemplateItem> toDeleteAPTaskItems = new List<TaskTemplateItem>();
            List<TaskTemplateItemEmployee> toDeleteAPTaskEmployeeItems = new List<TaskTemplateItemEmployee>();
            for (int i = 0; i < vmApprovalRouteTemplateItems.Count; i++)
            {
                ApprovalRouteVM cur = vmApprovalRouteTemplateItems[i];
                //int curId = -1;
                //int.TryParse(cur.Id, out curId);
                if (!approvalRouteTemplateItems.Any(x => x.Id.ToString() == cur.Id))
                {
                    ApprovalRouteTemplateItem approvalRouteTemplateItem = new ApprovalRouteTemplateItem();

                    approvalRouteTemplateItem.Active = cur.Active;

                    if (cur.IsDepartmentHead)
                    {
                        approvalRouteTemplateItem.IsDepartmentHead = true;
                    }
                    else if (cur.IsReportingTo)
                    {
                        approvalRouteTemplateItem.IsReportingTo = true;
                    }
                    else
                    {
                        approvalRouteTemplateItem.IsDepartmentHead = false;
                        approvalRouteTemplateItem.IsReportingTo = false;

                        approvalRouteTemplateItem.ApprovalRouteItemEmployees = new List<ApprovalRouteTemplateItemEmployee>();
                        for (int y = 0; y < cur.EmployeeIds.Length; y++)
                        {
                            ApprovalRouteTemplateItemEmployee approvalRouteTemplateItemEmployee = new ApprovalRouteTemplateItemEmployee();
                            approvalRouteTemplateItemEmployee.EmployeeId = cur.EmployeeIds[y].Value;

                            approvalRouteTemplateItem.ApprovalRouteItemEmployees.Add(approvalRouteTemplateItemEmployee);
                        }

                        TaskTemplate apItemTaskTemplate = new TaskTemplate();
                        apItemTaskTemplate.TaskModule = TaskModule.LeaveRequest;
                        apItemTaskTemplate.TaskTemplateItems = new List<TaskTemplateItem>();
                        for (int y = 0; y < cur.TaskTemplate.TaskTemplateItems.Count; y++)
                        {
                            LRTaskVM lRTaskVM = cur.TaskTemplate.TaskTemplateItems[y];
                            TaskTemplateItem taskTemplateItem = new TaskTemplateItem();

                            taskTemplateItem.Active = lRTaskVM.Active;
                            taskTemplateItem.TaskDescription = lRTaskVM.TaskDescription;

                            taskTemplateItem.TaskEmployees = new List<TaskTemplateItemEmployee>();
                            for (int z = 0; z < lRTaskVM.EmployeeIds.Length; z++)
                            {
                                TaskTemplateItemEmployee taskTemplateItemEmployee = new TaskTemplateItemEmployee();
                                taskTemplateItemEmployee.EmployeeId = lRTaskVM.EmployeeIds[z].Value;

                                taskTemplateItem.TaskEmployees.Add(taskTemplateItemEmployee);
                            }

                            taskTemplateItem.RouteIndex = y + 1;
                            taskTemplateItem.IsAny = lRTaskVM.IsAny;
                            taskTemplateItem.NotifyEmployee = lRTaskVM.NotifyEmployee;

                            apItemTaskTemplate.TaskTemplateItems.Add(taskTemplateItem);
                        }

                        approvalRouteTemplateItem.TaskTemplate = apItemTaskTemplate;
                    }

                    approvalRouteTemplateItem.RouteIndex = i + 1;

                    approvalRouteTemplateItem.IsAny = cur.IsAny;
                    approvalRouteTemplateItem.NotifyEmployee = cur.NotifyEmployee;
                    approvalRouteTemplateItem.IsPoster = cur.IsPoster;

                    resultApprovalRouteTemplate.ApprovalRouteTemplateItems.Add(approvalRouteTemplateItem);
                }
                else
                {
                    resultApprovalRouteTemplate.ApprovalRouteModule = ApprovalRouteModule.LeaveRequest;

                    ApprovalRouteTemplateItem item = resultApprovalRouteTemplate.ApprovalRouteTemplateItems.First(x => x.Id.ToString() == cur.Id);

                    item.Active = cur.Active;
                    item.RouteIndex = i + 1;

                    item.IsAny = cur.IsAny;
                    item.NotifyEmployee = cur.NotifyEmployee;
                    item.IsPoster = cur.IsPoster;

                    List<Employee_Dto> vmApprovalRouteEmployees = cur.ApprovalRouteItemEmployees.Select(x => x.Employee).ToList();
                    List<ApprovalRouteTemplateItemEmployee> approvalRouteEmployees = item.ApprovalRouteItemEmployees.ToList();
                    for (int j = 0; j < vmApprovalRouteEmployees.Count; j++)
                    {
                        Employee_Dto curVMEMployee = vmApprovalRouteEmployees[j];
                        if (!approvalRouteEmployees.Any(x => x.EmployeeId == curVMEMployee.Id) && curVMEMployee.Id != Guid.Empty)
                        {
                            ApprovalRouteTemplateItemEmployee approvalRouteTemplateItemEmployee = new ApprovalRouteTemplateItemEmployee();
                            approvalRouteTemplateItemEmployee.EmployeeId = curVMEMployee.Id;

                            item.ApprovalRouteItemEmployees.Add(approvalRouteTemplateItemEmployee);
                        }
                    }
                    for (int j = 0; j < approvalRouteEmployees.Count; j++)
                    {
                        ApprovalRouteTemplateItemEmployee curItemEmp = approvalRouteEmployees[j];
                        if (!cur.EmployeeIds.Any(x => x == curItemEmp.EmployeeId))
                        {
                            item.ApprovalRouteItemEmployees.Remove(curItemEmp);
                            toDeleteAPEmployeeItems.Add(curItemEmp);
                        }
                        //toDeleteAPEmployeeItems = new List<ApprovalRouteTemplateItemEmployee>();
                    }

                    if (item.TaskTemplate != null)
                    {
                        TaskTemplate apItemTaskTemplate = item.TaskTemplate;
                        apItemTaskTemplate.TaskModule = TaskModule.LeaveRequest;
                        List<LRTaskVM> vmAPTaskTemplateItems = cur.TaskTemplate.TaskTemplateItems;
                        List<TaskTemplateItem> apTaskTemplateItems = apItemTaskTemplate.TaskTemplateItems.ToList();
                        for (int y = 0; y < vmAPTaskTemplateItems.Count; y++)
                        {
                            LRTaskVM vmAPTaskTemplateItem = vmAPTaskTemplateItems[y];
                            int vmAPTaskTemplateItemId = -1;
                            int.TryParse(vmAPTaskTemplateItem.Id, out vmAPTaskTemplateItemId);
                            if (!apTaskTemplateItems.Any(x => x.Id == vmAPTaskTemplateItemId))
                            {
                                TaskTemplateItem apTaskTemplateItem = new TaskTemplateItem();

                                apTaskTemplateItem.Active = vmAPTaskTemplateItem.Active;
                                apTaskTemplateItem.TaskDescription = vmAPTaskTemplateItem.TaskDescription;

                                apTaskTemplateItem.TaskEmployees = new List<TaskTemplateItemEmployee>();
                                for (int z = 0; z < vmAPTaskTemplateItem.EmployeeIds.Length; z++)
                                {
                                    TaskTemplateItemEmployee taskTemplateItemEmployee = new TaskTemplateItemEmployee();
                                    taskTemplateItemEmployee.EmployeeId = vmAPTaskTemplateItem.EmployeeIds[z].Value;
                                }

                                apTaskTemplateItem.RouteIndex = y + 1;

                                apTaskTemplateItem.IsAny = vmAPTaskTemplateItem.IsAny;
                                apTaskTemplateItem.NotifyEmployee = vmAPTaskTemplateItem.NotifyEmployee;

                                item.TaskTemplate.TaskTemplateItems.Add(apTaskTemplateItem);
                            }
                            else
                            {
                                TaskTemplateItem taskTemplateItem = apTaskTemplateItems.First(x => x.Id == vmAPTaskTemplateItemId);

                                taskTemplateItem.Active = vmAPTaskTemplateItem.Active;
                                taskTemplateItem.TaskDescription = vmAPTaskTemplateItem.TaskDescription;

                                taskTemplateItem.RouteIndex = y + 1;

                                taskTemplateItem.IsAny = vmAPTaskTemplateItem.IsAny;
                                taskTemplateItem.NotifyEmployee = vmAPTaskTemplateItem.NotifyEmployee;

                                toUpdateAPTaskItems.Add(taskTemplateItem);
                            }
                        }
                        if (vmAPTaskTemplateItems.Count == 0 && apTaskTemplateItems.Count > 0)
                            toDeleteAPTaskTemplates.Add(apItemTaskTemplate);
                        else
                        {
                            for (int y = 0; y < apTaskTemplateItems.Count; y++)
                            {
                                TaskTemplateItem curAPTaskItem = apTaskTemplateItems[y];
                                if (!vmAPTaskTemplateItems.Any(x => x.Id == curAPTaskItem.Id.ToString()))
                                {
                                    item.TaskTemplate.TaskTemplateItems.Remove(curAPTaskItem);
                                    toDeleteAPTaskItems.Add(curAPTaskItem);
                                }
                            }
                        }
                    }
                    toUpdateAPItems.Add(item);
                }
            }

            List<ApprovalRouteTemplateItem> toDeleteAPItems = new List<ApprovalRouteTemplateItem>();
            if (vmApprovalRouteTemplateItems.Count == 0 && approvalRouteTemplateItems.Count > 0)
            {
                toDeleteApprovalRouteTemplates.Add(approvalRouteTemplate);
            }
            else
            {
                for (int i = 0; i < approvalRouteTemplateItems.Count; i++)
                {
                    ApprovalRouteTemplateItem cur = approvalRouteTemplateItems[i];
                    if (!vmApprovalRouteTemplateItems.Any(x => x.Id == cur.Id.ToString()))
                    {
                        resultApprovalRouteTemplate.ApprovalRouteTemplateItems.Remove(cur);
                        toDeleteAPTaskTemplates.Add(cur.TaskTemplate);
                        toDeleteAPItems.Add(cur);
                    }
                }
            }

            for (int i = 0; i < toDeleteAPEmployeeItems.Count; i++)
            {
                await ApprovalRouteTemplateItemsAppService.EmployeesRepository.DeleteAsync(x => x.EmployeeId == toDeleteAPEmployeeItems[i].EmployeeId);
            }

            for (int i = 0; i < toDeleteApprovalRouteTemplates.Count; i++)
            {
                await ApprovalRouteTemplatesAppService.Repository.DeleteAsync(toDeleteApprovalRouteTemplates[i].Id);
            }

            for (int i = 0; i < toDeleteAPTaskEmployeeItems.Count; i++)
            {
                await TaskTemplatesAppService.EmployeesRepository.DeleteAsync(x => x.EmployeeId == toDeleteAPTaskEmployeeItems[i].EmployeeId);
            }

            for (int i = 0; i < toDeleteAPTaskItems.Count; i++)
            {
                await TaskTemplatesAppService.ItemsRepository.DeleteAsync(toDeleteAPTaskItems[i]);
            }


            for (int i = 0; i < toUpdateAPTaskItems.Count; i++)
            {
                await TaskTemplatesAppService.ItemsRepository.UpdateAsync(toUpdateAPTaskItems[i]);
            }

            for (int i = 0; i < toDeleteAPItems.Count; i++)
            {
                await ApprovalRouteTemplateItemsAppService.Repository.DeleteAsync(toDeleteAPItems[i]);
            }

            for (int i = 0; i < toDeleteAPTaskTemplates.Count; i++)
            {
                await TaskTemplatesAppService.Repository.DeleteAsync(toDeleteAPTaskTemplates[i].Id);
            }

            for (int i = 0; i < toUpdateAPItems.Count; i++)
            {
                await ApprovalRouteTemplateItemsAppService.Repository.UpdateAsync(toUpdateAPItems[i]);
            }

            return resultApprovalRouteTemplate;
        }
        public ApprovalRouteTemplate_Dto ProcessNewApprovalsRoute(ApprovalRouteViewModelBase VM)
        {
            ApprovalRouteTemplate_Dto resultApprovalRouteTemplate = new ApprovalRouteTemplate_Dto();

            resultApprovalRouteTemplate.ApprovalRouteTemplateItems = new List<ApprovalRouteTemplateItem_Dto>();
            resultApprovalRouteTemplate.ApprovalRouteModule = ApprovalRouteModule.LeaveRequest;

            for (int i = 0; i < VM.ApprovalRoute.Count; i++)
            {
                ApprovalRouteVM lRApprovalRouteVM = VM.ApprovalRoute[i];
                ApprovalRouteTemplateItem_Dto approvalRouteTemplateItem = new ApprovalRouteTemplateItem_Dto();

                approvalRouteTemplateItem.Active = lRApprovalRouteVM.Active;

                if (lRApprovalRouteVM.IsDepartmentHead)
                {
                    approvalRouteTemplateItem.IsDepartmentHead = true;
                }
                else if (lRApprovalRouteVM.IsReportingTo)
                {
                    approvalRouteTemplateItem.IsReportingTo = true;
                }
                else
                {
                    approvalRouteTemplateItem.IsDepartmentHead = false;
                    approvalRouteTemplateItem.IsReportingTo = false;

                    approvalRouteTemplateItem.ApprovalRouteItemEmployees = new List<ApprovalRouteTemplateItemEmployee_Dto>();
                    for (int y = 0; y < lRApprovalRouteVM.EmployeeIds.Length; y++)
                    {
                        if (lRApprovalRouteVM.EmployeeIds[y] != null && lRApprovalRouteVM.EmployeeIds[y].Value != Guid.Empty)
                        {
                            ApprovalRouteTemplateItemEmployee_Dto approvalRouteTemplateItemEmployee = new ApprovalRouteTemplateItemEmployee_Dto();
                            approvalRouteTemplateItemEmployee.EmployeeId = lRApprovalRouteVM.EmployeeIds[y].Value;

                            approvalRouteTemplateItem.ApprovalRouteItemEmployees.Add(approvalRouteTemplateItemEmployee);
                        }
                    }

                    TaskTemplate_Dto apItemTaskTemplate = new TaskTemplate_Dto();
                    apItemTaskTemplate.TaskModule = TaskModule.LeaveRequest;
                    apItemTaskTemplate.TaskTemplateItems = new List<TaskTemplateItem_Dto>();
                    for (int y = 0; y < lRApprovalRouteVM.TaskTemplate.TaskTemplateItems.Count; y++)
                    {
                        LRTaskVM lRTaskVM = lRApprovalRouteVM.TaskTemplate.TaskTemplateItems[y];
                        TaskTemplateItem_Dto taskTemplateItem = new TaskTemplateItem_Dto();

                        taskTemplateItem.Active = lRTaskVM.Active;
                        taskTemplateItem.TaskDescription = lRTaskVM.TaskDescription;

                        taskTemplateItem.TaskEmployees = new List<TaskTemplateItemEmployee_Dto>();
                        for (int z = 0; z < lRTaskVM.EmployeeIds.Length; z++)
                        {
                            if (lRTaskVM.EmployeeIds[z] != null && lRTaskVM.EmployeeIds[z] != Guid.Empty)
                            {
                                TaskTemplateItemEmployee_Dto taskTemplateItemEmployee = new TaskTemplateItemEmployee_Dto();
                                taskTemplateItemEmployee.EmployeeId = lRTaskVM.EmployeeIds[z].Value;

                                taskTemplateItem.TaskEmployees.Add(taskTemplateItemEmployee);
                            }
                        }

                        taskTemplateItem.RouteIndex = y + 1;
                        taskTemplateItem.IsAny = lRTaskVM.IsAny;
                        taskTemplateItem.NotifyEmployee = lRTaskVM.NotifyEmployee;

                        apItemTaskTemplate.TaskTemplateItems.Add(taskTemplateItem);
                    }

                    approvalRouteTemplateItem.TaskTemplate = apItemTaskTemplate;
                }

                approvalRouteTemplateItem.RouteIndex = i + 1;

                approvalRouteTemplateItem.IsAny = lRApprovalRouteVM.IsAny;
                approvalRouteTemplateItem.NotifyEmployee = lRApprovalRouteVM.NotifyEmployee;
                approvalRouteTemplateItem.IsPoster = lRApprovalRouteVM.IsPoster;

                resultApprovalRouteTemplate.ApprovalRouteTemplateItems.Add(approvalRouteTemplateItem);
            }

            return resultApprovalRouteTemplate;
        }
    }

}
