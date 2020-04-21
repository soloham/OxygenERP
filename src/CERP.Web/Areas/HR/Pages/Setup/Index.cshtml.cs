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
using CERP.HR.Workshift.DTOs;
using CERP.AppServices.Setup.PositionSetup;
using CERP.AppServices.HR.EmployeeService;
using CERP.AppServices.HR.LeaveRequestService;
using CERP.AppServices.App.ApprovalRouteService;
using CERP.HR.Leaves;
using CERP.AppServices.Setup.Lookup;
using CERP.AppServices.App.TaskService;
using CERP.AppServices.HR.HolidayService;
using CERP.HR.Holidays;
using CERP.HR.Attendance;
using CERP.AppServices.HR.AttendanceService;
using System.Threading;

namespace CERP.Web.Areas.HR.Pages.Setup
{
    public class IndexModel : CERPPageModel
    {
        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo;

        public IGuidGenerator guidGenerator { get; set; }
        public IJsonSerializer JsonSerializer { get; set; }

        public DictionaryValueAppService DictionaryValueAppService { get; set; }
        public DepartmentAppService DepartmentAppService { get; set; }
        public PositionAppService PositionAppService { get; set; }
        public EmployeeAppService EmployeeAppService { get; set; }
        public WorkshiftAppService WorkShiftsAppService { get; set; }
        public ApprovalRouteTemplatesAppService ApprovalRouteTemplatesAppService { get; set; }
        public TaskTemplatesAppService TaskTemplatesAppService { get; set; }
        public LeaveRequestTemplatesAppService LeaveRequestTemplatesAppService { get; set; }
        public HolidaysAppService HolidaysAppService { get; set; }
        public ApprovalRouteTemplateItemsAppService ApprovalRouteTemplateItemsAppService { get; set; }
        public DeductionMethodsAppService DeductionMethodsAppService { get; set; }
        public AttendanceAppService AttendanceAppService { get; set; }

        public bool IsUsingAttendanceSystem { get; set; }

        public IndexModel(IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IGuidGenerator guidGenerator, IJsonSerializer jsonSerializer, DepartmentAppService departmentAppService, WorkshiftAppService workShiftsAppService, DeductionMethodsAppService deductionMethodsAppService, PositionAppService positionAppService, EmployeeAppService employeeAppService, LeaveRequestTemplatesAppService leaveRequestTemplatesAppService, ApprovalRouteTemplatesAppService approvalRouteTemplatesAppService, DictionaryValueAppService dictionaryValueAppService, ApprovalRouteTemplateItemsAppService approvalRouteTemplateItemsAppService, TaskTemplatesAppService taskTemplatesAppService, HolidaysAppService holidaysAppService, AttendanceAppService attendanceAppService)
        {
            DictionaryValuesRepo = dictionaryValuesRepo;
            this.guidGenerator = guidGenerator;
            JsonSerializer = jsonSerializer;
            DepartmentAppService = departmentAppService;
            WorkShiftsAppService = workShiftsAppService;
            DeductionMethodsAppService = deductionMethodsAppService;
            PositionAppService = positionAppService;
            EmployeeAppService = employeeAppService;
            LeaveRequestTemplatesAppService = leaveRequestTemplatesAppService;
            ApprovalRouteTemplatesAppService = approvalRouteTemplatesAppService;
            DictionaryValueAppService = dictionaryValueAppService;
            ApprovalRouteTemplateItemsAppService = approvalRouteTemplateItemsAppService;
            TaskTemplatesAppService = taskTemplatesAppService;
            HolidaysAppService = holidaysAppService;
            AttendanceAppService = attendanceAppService;
        }

        public void OnGet()
        {

        }
        public async Task<JsonResult> OnGetLeaveRequests()
        {
            List<LeaveRequestTemplate_Dto> leaveRequestTemplates = await LeaveRequestTemplatesAppService.GetAllAsync();
            JsonResult jsonResult = new JsonResult(leaveRequestTemplates);
            return jsonResult;
        }
        public async Task<JsonResult> OnGetApprovalRoute(int approvalRouteTemplateId)
        {
            ApprovalRouteTemplate_Dto result = await ApprovalRouteTemplatesAppService.GetAsync(approvalRouteTemplateId);
            return new JsonResult(result);
        }
        public JsonResult OnGetPositions(Guid departmentId)
        {
            List<Position_Dto> result = PositionAppService.GetPositionByDepartmentId(departmentId);
            return new JsonResult(result);
        }
        public JsonResult OnGetDepartmentsPositions(string departmentIds)
        {
            Guid[] _departmentIds = JsonSerializer.Deserialize<Guid[]>(departmentIds);
            List<Position_Dto> positions = new List<Position_Dto>();
            for (int i = 0; i < _departmentIds.Length; i++)
            {
                List<Position_Dto> result = PositionAppService.GetPositionByDepartmentId(_departmentIds[i]);
                positions.AddRange(result);
            }
            return new JsonResult(positions);
        }
        public JsonResult OnGetEmployees(Guid positionId)
        {
            List<object> result = EmployeeAppService.GetEmployeesByPositionId(positionId).Select<Employee_Dto, object>(x => new { Id = x.Id, Name = x.Name }).ToList();
            return new JsonResult(result);
        }
        public async Task<IActionResult> OnPostAttendanceSystem(bool use)
        {
            var attendances = await AttendanceAppService.GetAllAsync();

            if(attendances.Count == 0)
            {
                Attendance_Dto attendance = new Attendance_Dto();
                attendance.UseAttendanceSystem = use;

                await AttendanceAppService.CreateAsync(attendance);
            }
            else
            {
                for (int i = 0; i < attendances.Count; i++)
                {
                    Attendance_Dto attendance = attendances[i];
                    attendance.UseAttendanceSystem = use;

                    await AttendanceAppService.UpdateAsync(attendance.Id, attendance);
                }
            }
            return StatusCode(200);
        }
        public async Task<IActionResult> OnPostAttendanceMappings(string employeeIdMap, string dateMap, string timeInMap, string timeOutMap)
        {
            var attendances = await AttendanceAppService.GetAllAsync();

            if(attendances.Count == 0)
            {
                Attendance_Dto attendance = new Attendance_Dto();
                attendance.EmployeeIDMap = employeeIdMap;
                attendance.DateMap = dateMap;
                attendance.TimeInMap = timeInMap;
                attendance.TimeOutMap = timeOutMap;

                await AttendanceAppService.CreateAsync(attendance);
            }
            else
            {
                for (int i = 0; i < attendances.Count; i++)
                {
                    Attendance_Dto attendance = attendances[i];
                    attendance.EmployeeIDMap = employeeIdMap;
                    attendance.DateMap = dateMap;
                    attendance.TimeInMap = timeInMap;
                    attendance.TimeOutMap = timeOutMap;

                    await AttendanceAppService.UpdateAsync(attendance.Id, attendance);
                }
            }
            return StatusCode(200);
        }

        public async Task<IActionResult> OnDeleteWorkShift()
        {
            List<WorkShift_Dto> workshifts = JsonSerializer.Deserialize<List<WorkShift_Dto>>(Request.Form["workshifts"]);
            try
            {
                for (int i = 0; i < workshifts.Count; i++)
                {
                    WorkShift_Dto workshift = workshifts[i];
                    await WorkShiftsAppService.DeleteAsync(workshift.Id);
                }
                return StatusCode(200);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> OnDeleteDeductionMethod()
        {
            List<DeductionMethod_Dto> deductionMethods = JsonSerializer.Deserialize<List<DeductionMethod_Dto>>(Request.Form["deductionMethods"]);
            try
            {
                for (int i = 0; i < deductionMethods.Count; i++)
                {
                    DeductionMethod_Dto deductionMethod = deductionMethods[i];
                    await DeductionMethodsAppService.DeleteAsync(deductionMethod.Id);
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> OnDeleteLeaveRequest()
        {
            List<LeaveRequestTemplate_Dto> leaveRequests = JsonSerializer.Deserialize<List<LeaveRequestTemplate_Dto>>(Request.Form["leaveRequests"]);
            try
            {
                for (int i = 0; i < leaveRequests.Count; i++)
                {
                    LeaveRequestTemplate_Dto leaveRequest = leaveRequests[i];
                    await LeaveRequestTemplatesAppService.DeleteAsync(leaveRequest.Id);
                }
                return StatusCode(200);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> OnDeleteHoliday()
        {
            List<Holiday_Dto> holidays = JsonSerializer.Deserialize<List<Holiday_Dto>>(Request.Form["holidays"]);
            try
            {
                for (int i = 0; i < holidays.Count; i++)
                {
                    Holiday_Dto holiday = holidays[i];
                    await HolidaysAppService.DeleteAsync(holiday.Id);
                }
                return StatusCode(200);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> OnPostDeductionMethod()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var formData = Request.Form;

                    DeductionMethodViewModel generalInfo = new DeductionMethodViewModel();
                    generalInfo = JsonSerializer.Deserialize<DeductionMethodViewModel>(formData["info"].ToString());

                    if (generalInfo.IsEditing)
                    {
                        DeductionMethod deductionMethod = DeductionMethodsAppService.Repository.First(x => x.Id == generalInfo.Id);
                        deductionMethod.Title = generalInfo.DeductionMethodTitle;
                        deductionMethod.HoursMultiplicationFactor = generalInfo.HoursMultiplicationFactor;

                        DeductionMethod deductionMethodAdded = await DeductionMethodsAppService.Repository.UpdateAsync(deductionMethod);
                        DeductionMethod_Dto deductionMethodDto = ObjectMapper.Map<DeductionMethod, DeductionMethod_Dto>(DeductionMethodsAppService.Repository.First(x => x.Id == deductionMethodAdded.Id));
                        return new JsonResult(deductionMethodDto);
                    }
                    else
                    {
                        DeductionMethod_Dto deductionMethod = new DeductionMethod_Dto();
                        deductionMethod.Title = generalInfo.DeductionMethodTitle;
                        deductionMethod.HoursMultiplicationFactor = generalInfo.HoursMultiplicationFactor;

                        DeductionMethod_Dto deductionMethodAdded = await DeductionMethodsAppService.CreateAsync(deductionMethod);
                        DeductionMethod_Dto deductionMethodDto = ObjectMapper.Map<DeductionMethod, DeductionMethod_Dto>(DeductionMethodsAppService.Repository.First(x => x.Id == deductionMethodAdded.Id));
                        return new JsonResult(deductionMethodDto);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return NoContent();
        }
        public async Task<IActionResult> OnPostWorkshift()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var formData = Request.Form;

                    WorkShiftViewModel generalInfo = new WorkShiftViewModel();
                    generalInfo = JsonSerializer.Deserialize<WorkShiftViewModel>(formData["info"].ToString());
                    generalInfo.Initialize();

                    if (generalInfo.IsEditing)
                    {
                        WorkShift workShift = WorkShiftsAppService.Repository.First(x => x.Id == generalInfo.Id);
                        workShift.Title = generalInfo.Title;
                        workShift.DepartmentId = generalInfo.DepartmentId.HasValue ? generalInfo.DepartmentId.Value : Guid.Empty;
                        workShift.DeductionMethodId = generalInfo.DeductionMethodId;
                        workShift.isSUN = generalInfo.isSUN;
                        workShift.isMON = generalInfo.isMON;
                        workShift.isTUE = generalInfo.isTUE;
                        workShift.isWED = generalInfo.isWED;
                        workShift.isTHU = generalInfo.isTHU;
                        workShift.isFRI = generalInfo.isFRI;
                        workShift.isSAT = generalInfo.isSAT;
                        workShift.StartHour = generalInfo.StartHour;
                        workShift.EndHour = generalInfo.EndHour;

                        WorkShift workShiftAdded = await WorkShiftsAppService.Repository.UpdateAsync(workShift);
                        WorkShift_Dto workShiftDto = ObjectMapper.Map<WorkShift, WorkShift_Dto>(WorkShiftsAppService.Repository.WithDetails(x => x.Department, x => x.DeductionMethod).First(x => x.Id == workShiftAdded.Id));
                        return new JsonResult(workShiftDto);
                    }
                    else
                    {
                        WorkShift_Dto workShift = new WorkShift_Dto();
                        workShift.Title = generalInfo.Title;
                        workShift.DepartmentId = generalInfo.DepartmentId.HasValue ? generalInfo.DepartmentId.Value : Guid.Empty;
                        workShift.DeductionMethodId = generalInfo.DeductionMethodId;
                        workShift.isSUN = generalInfo.isSUN;
                        workShift.isMON = generalInfo.isMON;
                        workShift.isTUE = generalInfo.isTUE;
                        workShift.isWED = generalInfo.isWED;
                        workShift.isTHU = generalInfo.isTHU;
                        workShift.isFRI = generalInfo.isFRI;
                        workShift.isSAT = generalInfo.isSAT;
                        workShift.StartHour = generalInfo.StartHour;
                        workShift.EndHour = generalInfo.EndHour;

                        WorkShift_Dto workShiftAdded = await WorkShiftsAppService.CreateAsync(workShift);
                        WorkShift_Dto workShiftDto = ObjectMapper.Map<WorkShift, WorkShift_Dto>(WorkShiftsAppService.Repository.WithDetails(x => x.Department).First(x => x.Id == workShiftAdded.Id));
                        return new JsonResult(workShiftDto);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return NoContent();
        }
        public async Task<IActionResult> OnPostLeaveRequestTemplate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var formData = Request.Form;

                    LeaveRequestTemplateViewModel lrTemplateVM = new LeaveRequestTemplateViewModel();
                    lrTemplateVM = JsonSerializer.Deserialize<LeaveRequestTemplateViewModel>(formData["info"].ToString());
                    lrTemplateVM.Initialize();

                    if (lrTemplateVM.IsEditing)
                    {
                        LeaveRequestTemplate leaveRequestTemplate = await LeaveRequestTemplatesAppService.Repository.GetAsync(lrTemplateVM.Id);
                        //leaveRequestTemplate.Id = 0;
                        //LeaveRequestTemplate_Dto leaveRequestTemplate = new LeaveRequestTemplate_Dto();

                        leaveRequestTemplate.Title = lrTemplateVM.LRTitle;
                        leaveRequestTemplate.TitleLocalized = lrTemplateVM.LRTitleLocalized;
                        leaveRequestTemplate.Prefix = lrTemplateVM.LRPrefix;
                        leaveRequestTemplate.StartingNo = lrTemplateVM.LRStartingNo;
                        leaveRequestTemplate.LeaveTypeId = lrTemplateVM.LRLeaveTypeId;
                        leaveRequestTemplate.EntitlementDays = lrTemplateVM.LREntitlementDays;

                        Guid[] vmDepIds = lrTemplateVM.LRDepartmentIds;
                        Guid[] depIds = leaveRequestTemplate.Departments.Select(x => x.DepartmentId).ToArray();

                        for (int i = 0; i < vmDepIds.Length; i++)
                        {
                            if(!depIds.Contains(vmDepIds[i]))
                            {
                                leaveRequestTemplate.Departments.Add(new LeaveRequestTemplateDepartment() { DepartmentId = vmDepIds[i] });
                            }
                        }
                        List<Guid> toDeleteDeps = new List<Guid>();
                        for (int i = 0; i < depIds.Length; i++)
                        {
                            if(!vmDepIds.Contains(depIds[i]))
                            {
                                leaveRequestTemplate.Departments.Remove(leaveRequestTemplate.Departments.First(x => x.DepartmentId == depIds[i]));
                                toDeleteDeps.Add(depIds[i]);
                            }
                        }

                        Guid[] vmPosIds = lrTemplateVM.LRPositionsIds;
                        Guid[] posIds = leaveRequestTemplate.Positions.Select(x => x.PositionId).ToArray();

                        for (int i = 0; i < vmPosIds.Length; i++)
                        {
                            if(!posIds.Contains(vmPosIds[i]))
                            {
                                leaveRequestTemplate.Positions.Add(new LeaveRequestTemplatePosition() { PositionId = vmPosIds[i] });
                            }
                        }
                        List<Guid> toDeletePoses = new List<Guid>();
                        for (int i = 0; i < posIds.Length; i++)
                        {
                            if(!vmPosIds.Contains(posIds[i]))
                            {
                                leaveRequestTemplate.Positions.Remove(leaveRequestTemplate.Positions.First(x => x.PositionId == posIds[i]));
                                toDeletePoses.Add(posIds[i]);
                            }
                        }

                        Guid[] vmEmpTypesIds = lrTemplateVM.LREmploymentTypeIds;
                        Guid[] empTypesIds = leaveRequestTemplate.EmploymentTypes.Select(x => x.EmploymentTypeId).ToArray();

                        for (int i = 0; i < vmEmpTypesIds.Length; i++)
                        {
                            if(!empTypesIds.Contains(vmEmpTypesIds[i]))
                            {
                                leaveRequestTemplate.EmploymentTypes.Add(new LeaveRequestTemplateEmploymentType() { EmploymentTypeId = vmEmpTypesIds[i] });
                            }
                        }
                        List<Guid> toDeleteEmpTypes = new List<Guid>();
                        for (int i = 0; i < empTypesIds.Length; i++)
                        {
                            if(!vmEmpTypesIds.Contains(empTypesIds[i]))
                            {
                                leaveRequestTemplate.EmploymentTypes.Remove(leaveRequestTemplate.EmploymentTypes.First(x => x.EmploymentTypeId == empTypesIds[i]));
                                toDeleteEmpTypes.Add(empTypesIds[i]);
                            }
                        }

                        int[] vmHolidaysIds = lrTemplateVM.LRDeductionHolidaysIds;
                        int[] holidaysIds = leaveRequestTemplate.Holidays.Select(x => x.HolidayId).ToArray();

                        for (int i = 0; i < vmHolidaysIds.Length; i++)
                        {
                            if(!holidaysIds.Contains(vmHolidaysIds[i]))
                            {
                                leaveRequestTemplate.Holidays.Add(new LeaveRequestTemplateHoliday() { HolidayId = vmHolidaysIds[i] });
                            }
                        }
                        List<int> toDeleteHolidaysIds = new List<int>();
                        for (int i = 0; i < holidaysIds.Length; i++)
                        {
                            if(!vmHolidaysIds.Contains(holidaysIds[i]))
                            {
                                leaveRequestTemplate.Holidays.Remove(leaveRequestTemplate.Holidays.First(x => x.HolidayId == holidaysIds[i]));
                                toDeleteHolidaysIds.Add(holidaysIds[i]);
                            }
                        }
                        
                        Guid[] vmEmpStatusesIds = lrTemplateVM.LREmployeeStatusIds;
                        Guid[] empStatusesIds = leaveRequestTemplate.EmployeeStatuses.Select(x => x.EmployeeStatusId).ToArray();

                        for (int i = 0; i < vmEmpStatusesIds.Length; i++)
                        {
                            if(!empStatusesIds.Contains(vmEmpStatusesIds[i]))
                            {
                                leaveRequestTemplate.EmployeeStatuses.Add(new LeaveRequestTemplateEmployeeStatus() { EmployeeStatusId = vmEmpStatusesIds[i] });
                            }
                        }
                        List<Guid> toDeleteEmpStatuses = new List<Guid>();
                        for (int i = 0; i < empStatusesIds.Length; i++)
                        {
                            if(!vmEmpStatusesIds.Contains(empStatusesIds[i]))
                            {
                                leaveRequestTemplate.EmployeeStatuses.Remove(leaveRequestTemplate.EmployeeStatuses.First(x => x.EmployeeStatusId == empStatusesIds[i]));
                                toDeleteEmpStatuses.Add(empStatusesIds[i]);
                            }
                        }

                        var vmApprovalRouteTemplateItems = lrTemplateVM.LRApprovalRoute;
                        ApprovalRouteTemplate approvalRouteTemplate = leaveRequestTemplate.ApprovalRouteTemplate;
                        List<ApprovalRouteTemplateItem> approvalRouteTemplateItems = approvalRouteTemplate.ApprovalRouteTemplateItems.ToList();

                        List<ApprovalRouteTemplateItem> toUpdateAPItems = new List<ApprovalRouteTemplateItem>();
                        for (int i = 0; i < vmApprovalRouteTemplateItems.Count; i++)
                        {
                            LeaveRequestTemplateViewModel.LRApprovalRouteVM cur = vmApprovalRouteTemplateItems[i];
                            //int curId = -1;
                            //int.TryParse(cur.Id, out curId);
                            if (!approvalRouteTemplateItems.Any(x => x.Id.ToString() == cur.Id))
                            {
                                ApprovalRouteTemplateItem approvalRouteTemplateItem = new ApprovalRouteTemplateItem();

                                approvalRouteTemplateItem.Active = cur.Active;
                                if (cur.IsDepartmentHead)
                                {
                                    approvalRouteTemplateItem.IsDepartmentHead = true;
                                    approvalRouteTemplateItem.DepartmentId = null;
                                    approvalRouteTemplateItem.PositionId = null;
                                    approvalRouteTemplateItem.EmployeeId = null;
                                }
                                else if (cur.IsReportingTo)
                                {
                                    approvalRouteTemplateItem.IsReportingTo = true;
                                    approvalRouteTemplateItem.DepartmentId = null;
                                    approvalRouteTemplateItem.PositionId = null;
                                    approvalRouteTemplateItem.EmployeeId = null;
                                }
                                else
                                {
                                    approvalRouteTemplateItem.IsDepartmentHead = false;
                                    approvalRouteTemplateItem.IsReportingTo = false;
                                    approvalRouteTemplateItem.DepartmentId = cur.DepartmentId;
                                    approvalRouteTemplateItem.PositionId = cur.PositionId;
                                    approvalRouteTemplateItem.EmployeeId = cur.EmployeeId;
                                }
                                approvalRouteTemplateItem.RouteIndex = i + 1;

                                leaveRequestTemplate.ApprovalRouteTemplate.ApprovalRouteTemplateItems.Add(approvalRouteTemplateItem);
                            }
                            else
                            {
                                ApprovalRouteTemplateItem item = leaveRequestTemplate.ApprovalRouteTemplate.ApprovalRouteTemplateItems.First(x => x.Id.ToString() == cur.Id);

                                item.Active = cur.Active;
                                item.RouteIndex = i + 1;

                                toUpdateAPItems.Add(item);
                            }
                        }
                        List<ApprovalRouteTemplateItem> toDeleteAPItems = new List<ApprovalRouteTemplateItem>();
                        for (int i = 0; i < approvalRouteTemplateItems.Count; i++)
                        {
                            ApprovalRouteTemplateItem cur = approvalRouteTemplateItems[i];
                            if (!vmApprovalRouteTemplateItems.Any(x => x.Id == cur.Id.ToString()))
                            {
                                leaveRequestTemplate.ApprovalRouteTemplate.ApprovalRouteTemplateItems.Remove(cur);
                                toDeleteAPItems.Add(cur);
                            }
                        }

                        var vmTasksTemplateItems = lrTemplateVM.LRTasks;
                        TaskTemplate taskTemplate = leaveRequestTemplate.TaskTemplate;
                        List<TaskTemplateItem> taskTemplateItems = taskTemplate.TaskTemplateItems.ToList();

                        List<TaskTemplateItem> toUpdateTaskItems = new List<TaskTemplateItem>();
                        for (int i = 0; i < vmTasksTemplateItems.Count; i++)
                        {
                            LeaveRequestTemplateViewModel.LRTaskVM cur = vmTasksTemplateItems[i];
                            //int curId = -1;
                            //int.TryParse(cur.Id, out curId);
                            if (!taskTemplateItems.Any(x => x.Id.ToString() == cur.Id))
                            {
                                TaskTemplateItem taskTemplateItem = new TaskTemplateItem();

                                taskTemplateItem.Active = cur.Active;
                                taskTemplateItem.TaskDescription = cur.TaskDescription;

                                taskTemplateItem.DepartmentId = cur.DepartmentId;
                                taskTemplateItem.PositionId = cur.PositionId;
                                taskTemplateItem.EmployeeId = cur.EmployeeId;

                                taskTemplateItem.RouteIndex = i + 1;

                                leaveRequestTemplate.TaskTemplate.TaskTemplateItems.Add(taskTemplateItem);
                            }
                            else
                            {
                                TaskTemplateItem item = leaveRequestTemplate.TaskTemplate.TaskTemplateItems.First(x => x.Id.ToString() == cur.Id);

                                item.Active = cur.Active;
                                item.RouteIndex = i + 1;
                                item.TaskDescription = cur.TaskDescription;

                                toUpdateTaskItems.Add(item);
                            }
                        }
                        List<TaskTemplateItem> toDeleteTaskItems = new List<TaskTemplateItem>();
                        for (int i = 0; i < taskTemplateItems.Count; i++)
                        {
                            TaskTemplateItem cur = taskTemplateItems[i];
                            if (!vmTasksTemplateItems.Any(x => x.Id == cur.Id.ToString()))
                            {
                                leaveRequestTemplate.TaskTemplate.TaskTemplateItems.Remove(cur);
                                toDeleteTaskItems.Add(cur);
                            }
                        }

                        leaveRequestTemplate.HasAdvanceSalaryRequest = lrTemplateVM.LRAdvanceSalaryAD;
                        leaveRequestTemplate.HasAirTicketRequest = lrTemplateVM.LRAirTicketAD;
                        leaveRequestTemplate.HasExitReentryRequest = lrTemplateVM.LRExitReentryAD;

                        leaveRequestTemplate.HasNotesRequirement = lrTemplateVM.LRNotesAR;
                        leaveRequestTemplate.HasAttachmentRequirement = lrTemplateVM.LRAttachmentAR;

                        for (int i = 0; i < toDeleteDeps.Count; i++)
                        {
                            await LeaveRequestTemplatesAppService.DepartmentsRepository.DeleteAsync(x => x.DepartmentId == toDeleteDeps[i]);
                        }
                        for (int i = 0; i < toDeletePoses.Count; i++)
                        {
                            await LeaveRequestTemplatesAppService.PositionsRepository.DeleteAsync(x => x.PositionId == toDeletePoses[i]);
                        }
                        for (int i = 0; i < toDeleteEmpTypes.Count; i++)
                        {
                            await LeaveRequestTemplatesAppService.EmployeeTypesRepository.DeleteAsync(x => x.EmploymentTypeId == toDeleteEmpTypes[i]);
                        }
                        for (int i = 0; i < toDeleteEmpStatuses.Count; i++)
                        {
                            await LeaveRequestTemplatesAppService.EmployeeStatusesRepository.DeleteAsync(x => x.EmployeeStatusId == toDeleteEmpStatuses[i]);
                        }
                        for (int i = 0; i < toDeleteHolidaysIds.Count; i++)
                        {
                            await LeaveRequestTemplatesAppService.HolidaysRepository.DeleteAsync(x => x.HolidayId == toDeleteHolidaysIds[i]);
                        }

                        for (int i = 0; i < toDeleteAPItems.Count; i++)
                        {
                            await ApprovalRouteTemplateItemsAppService.Repository.DeleteAsync(toDeleteAPItems[i]);
                        }
                        for (int i = 0; i < toUpdateAPItems.Count; i++)
                        {
                            await ApprovalRouteTemplateItemsAppService.Repository.UpdateAsync(toUpdateAPItems[i]);
                        }

                        for (int i = 0; i < toDeleteTaskItems.Count; i++)
                        {
                            await TaskTemplatesAppService.ItemsRepository.DeleteAsync(toDeleteTaskItems[i]);
                        }
                        for (int i = 0; i < toUpdateTaskItems.Count; i++)
                        {
                            await TaskTemplatesAppService.ItemsRepository.UpdateAsync(toUpdateTaskItems[i]);
                        }

                        var lrTempUpdated = await LeaveRequestTemplatesAppService.Repository.UpdateAsync(leaveRequestTemplate);

                        return StatusCode(200, lrTempUpdated);
                    }
                    else
                    {
                        LeaveRequestTemplate_Dto leaveRequestTemplate = new LeaveRequestTemplate_Dto();
                        leaveRequestTemplate.Title = lrTemplateVM.LRTitle;
                        leaveRequestTemplate.TitleLocalized = lrTemplateVM.LRTitleLocalized;
                        leaveRequestTemplate.Prefix = lrTemplateVM.LRPrefix;
                        leaveRequestTemplate.StartingNo = lrTemplateVM.LRStartingNo;
                        leaveRequestTemplate.LeaveTypeId = lrTemplateVM.LRLeaveTypeId;
                        leaveRequestTemplate.EntitlementDays = lrTemplateVM.LREntitlementDays;

                        leaveRequestTemplate.Departments = new List<LeaveRequestTemplateDepartment_Dto>();
                        for (int i = 0; i < lrTemplateVM.LRDepartmentIds.Length; i++)
                        {
                            LeaveRequestTemplateDepartment_Dto department = new LeaveRequestTemplateDepartment_Dto();
                            department.DepartmentId = lrTemplateVM.LRDepartmentIds[i];
                            //department.LeaveRequestTemplate = leaveRequestTemplate;

                            leaveRequestTemplate.Departments.Add(department);
                        }
                        leaveRequestTemplate.Positions = new List<LeaveRequestTemplatePosition_Dto>();
                        for (int i = 0; i < lrTemplateVM.LRPositionsIds.Length; i++)
                        {
                            LeaveRequestTemplatePosition_Dto position = new LeaveRequestTemplatePosition_Dto();
                            position.PositionId = lrTemplateVM.LRPositionsIds[i];
                            //position.LeaveRequestTemplate = leaveRequestTemplate;

                            leaveRequestTemplate.Positions.Add(position);
                        }
                        leaveRequestTemplate.EmployeeStatuses = new List<LeaveRequestTemplateEmployeeStatus_Dto>();
                        for (int i = 0; i < lrTemplateVM.LREmployeeStatusIds.Length; i++)
                        {
                            LeaveRequestTemplateEmployeeStatus_Dto employeeStatus = new LeaveRequestTemplateEmployeeStatus_Dto();
                            employeeStatus.EmployeeStatusId = lrTemplateVM.LREmployeeStatusIds[i];
                            //employeeStatus.LeaveRequestTemplate = leaveRequestTemplate;

                            leaveRequestTemplate.EmployeeStatuses.Add(employeeStatus);
                        }
                        leaveRequestTemplate.EmploymentTypes = new List<LeaveRequestTemplateEmploymentType_Dto>();
                        for (int i = 0; i < lrTemplateVM.LREmploymentTypeIds.Length; i++)
                        {
                            LeaveRequestTemplateEmploymentType_Dto employmentType = new LeaveRequestTemplateEmploymentType_Dto();
                            employmentType.EmploymentTypeId = lrTemplateVM.LREmploymentTypeIds[i];
                            //employmentType.LeaveRequestTemplate = leaveRequestTemplate;

                            leaveRequestTemplate.EmploymentTypes.Add(employmentType);
                        }
                        leaveRequestTemplate.Holidays = new List<LeaveRequestTemplateHoliday_Dto>();
                        for (int i = 0; i < lrTemplateVM.LRDeductionHolidaysIds.Length; i++)
                        {
                            LeaveRequestTemplateHoliday_Dto holiday = new LeaveRequestTemplateHoliday_Dto();
                            holiday.HolidayId = lrTemplateVM.LRDeductionHolidaysIds[i];
                            //employmentType.LeaveRequestTemplate = leaveRequestTemplate;

                            leaveRequestTemplate.Holidays.Add(holiday);
                        }

                        ApprovalRouteTemplate_Dto approvalRouteTemplate = new ApprovalRouteTemplate_Dto();
                        approvalRouteTemplate.ApprovalRouteTemplateItems = new List<ApprovalRouteTemplateItem_Dto>();
                        approvalRouteTemplate.ApprovalRouteModule = ApprovalRouteModule.LeaveRequest;

                        for (int i = 0; i < lrTemplateVM.LRApprovalRoute.Count; i++)
                        {
                            LeaveRequestTemplateViewModel.LRApprovalRouteVM lRApprovalRouteVM = lrTemplateVM.LRApprovalRoute[i];
                            ApprovalRouteTemplateItem_Dto approvalRouteTemplateItem = new ApprovalRouteTemplateItem_Dto();

                            approvalRouteTemplateItem.Active = lRApprovalRouteVM.Active;
                            if (lRApprovalRouteVM.IsDepartmentHead)
                            {
                                approvalRouteTemplateItem.IsDepartmentHead = true;
                                approvalRouteTemplateItem.DepartmentId = null;
                                approvalRouteTemplateItem.PositionId = null;
                                approvalRouteTemplateItem.EmployeeId = null;
                            }
                            else if (lRApprovalRouteVM.IsReportingTo)
                            {
                                approvalRouteTemplateItem.IsReportingTo = true;
                                approvalRouteTemplateItem.DepartmentId = null;
                                approvalRouteTemplateItem.PositionId = null;
                                approvalRouteTemplateItem.EmployeeId = null;
                            }
                            else
                            {
                                approvalRouteTemplateItem.IsDepartmentHead = false;
                                approvalRouteTemplateItem.IsReportingTo = false;
                                approvalRouteTemplateItem.DepartmentId = lRApprovalRouteVM.DepartmentId;
                                approvalRouteTemplateItem.PositionId = lRApprovalRouteVM.PositionId;
                                approvalRouteTemplateItem.EmployeeId = lRApprovalRouteVM.EmployeeId;
                            }
                            approvalRouteTemplateItem.RouteIndex = i + 1;

                            approvalRouteTemplate.ApprovalRouteTemplateItems.Add(approvalRouteTemplateItem);
                        }

                        leaveRequestTemplate.ApprovalRouteTemplate = approvalRouteTemplate;
                        

                        TaskTemplate_Dto taskTemplate = new TaskTemplate_Dto();
                        taskTemplate.TaskTemplateItems = new List<TaskTemplateItem_Dto>();
                        taskTemplate.TaskModule = TaskModule.LeaveRequest;

                        for (int i = 0; i < lrTemplateVM.LRTasks.Count; i++)
                        {
                            LeaveRequestTemplateViewModel.LRTaskVM lRTaskVM = lrTemplateVM.LRTasks[i];
                            TaskTemplateItem_Dto taskTemplateItem = new TaskTemplateItem_Dto();

                            taskTemplateItem.Active = lRTaskVM.Active;
                            taskTemplateItem.TaskDescription = lRTaskVM.TaskDescription;

                            taskTemplateItem.DepartmentId = lRTaskVM.DepartmentId;
                            taskTemplateItem.PositionId = lRTaskVM.PositionId;
                            taskTemplateItem.EmployeeId = lRTaskVM.EmployeeId;

                            taskTemplateItem.RouteIndex = i + 1;

                            taskTemplate.TaskTemplateItems.Add(taskTemplateItem);
                        }

                        leaveRequestTemplate.TaskTemplate = taskTemplate;

                        leaveRequestTemplate.HasAdvanceSalaryRequest = lrTemplateVM.LRAdvanceSalaryAD;
                        leaveRequestTemplate.HasAirTicketRequest = lrTemplateVM.LRAirTicketAD;
                        leaveRequestTemplate.HasExitReentryRequest = lrTemplateVM.LRExitReentryAD;

                        leaveRequestTemplate.HasNotesRequirement = lrTemplateVM.LRNotesAR;
                        leaveRequestTemplate.HasAttachmentRequirement = lrTemplateVM.LRAttachmentAR;

                        var lrTempCreated = await LeaveRequestTemplatesAppService.CreateCustomAsync(leaveRequestTemplate);

                        return StatusCode(200, lrTempCreated);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return NoContent();
        }
        public async Task<IActionResult> OnPostHoliday()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var formData = Request.Form;

                    HolidayViewModel holidayVM = new HolidayViewModel();
                    holidayVM = JsonSerializer.Deserialize<HolidayViewModel>(formData["info"].ToString());

                    if (holidayVM.IsEditing)
                    {
                        Holiday Holiday = await HolidaysAppService.Repository.GetAsync(holidayVM.Id, false);
                        //leaveRequestTemplate.Id = 0;
                        //LeaveRequestTemplate_Dto leaveRequestTemplate = new LeaveRequestTemplate_Dto();

                        Holiday.Title = holidayVM.HTitle;
                        Holiday.TitleLocalized = holidayVM.HTitleLocalized;
                       
                        Holiday.HolidayTypeId = holidayVM.HTypeId;
                        Holiday.IsPublic = holidayVM.IsPublic;

                        if (holidayVM.IsPublic)
                        {
                            Holiday.StartDate = holidayVM.HStartDate;
                            Holiday.EndDate = holidayVM.HEndDate;
                            Holiday.ReligiousDenominationId = holidayVM.HReligiousDenominationId;
                        }

                        var holidayUpdated = await HolidaysAppService.Repository.UpdateAsync(Holiday);
                        var returnHoliday = await HolidaysAppService.GetCustomAsync(holidayUpdated.Id);
                        return StatusCode(200, returnHoliday);
                    }
                    else
                    {
                        Holiday_Dto Holiday = new Holiday_Dto();
                        Holiday.Title = holidayVM.HTitle;
                        Holiday.TitleLocalized = holidayVM.HTitleLocalized;

                        Holiday.HolidayTypeId = holidayVM.HTypeId;
                        Holiday.IsPublic = holidayVM.IsPublic;

                        if (holidayVM.IsPublic)
                        {
                            Holiday.StartDate = holidayVM.HStartDate;
                            Holiday.EndDate = holidayVM.HEndDate;
                            Holiday.ReligiousDenominationId = holidayVM.HReligiousDenominationId;
                        }

                        var holidayCreated = await HolidaysAppService.CreateCustomAsync(Holiday);

                        return StatusCode(200, holidayCreated);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            return NoContent();
        }

        public class HolidayViewModel
        {
            public HolidayViewModel()
            {
                IsEditing = false;
            }
            public int Id { get; set; }

            public bool IsEditing { get; set; }
            public string HTitle { get; set; }
            public string HTitleLocalized { get; set; }
            public bool IsPublic { get; set; }
            public Guid HTypeId { get; set; }
            public DateTime? HStartDate { get; set; }
            public DateTime? HEndDate { get; set; }
            public Guid? HReligiousDenominationId { get; set; }
        }
        public class LeaveRequestTemplateViewModel
        {
            public LeaveRequestTemplateViewModel()
            {
                IsEditing = false;
            }

            public void Initialize()
            {
                LRApprovalRoute.ForEach(x => x.Initialize());
                LRTasks.ForEach(x => x.Initialize());
            }

            public int Id { get; set; }

            public bool IsEditing { get; set; }
            public string LRTitle { get; set; }
            public string LRTitleLocalized { get; set; }
            public string LRPrefix { get; set; }
            public int LRStartingNo { get; set; }
            public Guid LRLeaveTypeId { get; set; }
            public int LREntitlementDays { get; set; }
            public Guid[] LRDepartmentIds { get; set; }
            public Guid[] LRPositionsIds { get; set; }
            public Guid[] LREmploymentTypeIds { get; set; }
            public Guid[] LREmployeeStatusIds { get; set; }

            public List<LRTaskVM> LRTasks { get; set; }
            public List<LRApprovalRouteVM> LRApprovalRoute { get; set; }

            public int[] LRDeductionHolidaysIds { get; set; }

            public bool LRAdvanceSalaryAD { get; set; }
            public bool LRExitReentryAD { get; set; }
            public bool LRAirTicketAD { get; set; }

            public bool LRNotesAR { get; set; }
            public bool LRAttachmentAR { get; set; }

            public class LRApprovalRouteVM
            {
                public void Initialize()
                {
                    DepartmentId = Department.Id;
                    PositionId = Position.Id;
                    EmployeeId = Employee.Id;
                }

                public string Id { get; set; }

                public bool IsDepartmentHead { get; set; }
                public bool IsReportingTo { get; set; }

                public Department_Dto Department { get; set; }
                public Guid? DepartmentId { get; set; }
                public Position_Dto Position { get; set; }
                public Guid? PositionId { get; set; }
                public Employee_Dto Employee { get; set; }
                public Guid? EmployeeId { get; set; }
                public bool Active { get; set; }
            }
            public class LRTaskVM
            {
                public void Initialize()
                {
                    DepartmentId = Department.Id;
                    PositionId = Position.Id;
                    EmployeeId = Employee.Id;
                }

                public string Id { get; set; }
                public bool Active { get; set; }
                public string TaskDescription { get; set; }

                public Department_Dto Department { get; set; }
                public Guid? DepartmentId { get; set; }
                public Position_Dto Position { get; set; }
                public Guid? PositionId { get; set; }
                public Employee_Dto Employee { get; set; }
                public Guid? EmployeeId { get; set; }
            }
        }
        public class WorkShiftViewModel
        {
            public WorkShiftViewModel()
            {
                IsEditing = false;
            }

            public void Initialize()
            {
                DepartmentId = Department.Id;
                DeductionMethodId = DeductionMethod.Id;
            }

            public int Id { get; set; }

            public bool IsEditing { get; set; }
            public string Title { get; set; }
            public int StartHour { get; set; }
            public int EndHour { get; set; }

            public bool isSUN { get; set; }
            public bool isMON { get; set; }
            public bool isTUE { get; set; }
            public bool isWED { get; set; }
            public bool isTHU { get; set; }
            public bool isFRI { get; set; }
            public bool isSAT { get; set; }

            public DeductionMethod_Dto DeductionMethod { get; set; }
            public int DeductionMethodId { get; set; }
            public Department_Dto Department { get; set; }
            public Guid? DepartmentId { get; set; }
        }
        public class DeductionMethodViewModel
        {
            public DeductionMethodViewModel()
            {
                IsEditing = false;
            }

            public int Id { get; set; }

            public bool IsEditing { get; set; }
            public string DeductionMethodTitle { get; set; }
            public int HoursMultiplicationFactor { get; set; }
        }
    }
}
