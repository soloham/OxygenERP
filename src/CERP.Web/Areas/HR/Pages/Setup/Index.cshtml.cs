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
        public LeaveRequestTemplatesAppService LeaveRequestTemplatesAppService { get; set; }
        public DeductionMethodsAppService DeductionMethodsAppService { get; set; }

        public bool IsUsingAttendanceSystem { get; set; }

        public IndexModel(IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IGuidGenerator guidGenerator, IJsonSerializer jsonSerializer, DepartmentAppService departmentAppService, WorkshiftAppService workShiftsAppService, DeductionMethodsAppService deductionMethodsAppService, PositionAppService positionAppService, EmployeeAppService employeeAppService, LeaveRequestTemplatesAppService leaveRequestTemplatesAppService, ApprovalRouteTemplatesAppService approvalRouteTemplatesAppService, DictionaryValueAppService dictionaryValueAppService)
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
        public IActionResult OnPostAttendanceSystem(bool use)
        {

            return StatusCode(200);
        }

        public async Task OnDeleteWorkShift()
        {
            List<WorkShift_Dto> workshifts = JsonSerializer.Deserialize<List<WorkShift_Dto>>(Request.Form["workshifts"]);
            for (int i = 0; i < workshifts.Count; i++)
            {
                WorkShift_Dto workshift = workshifts[i];
                await WorkShiftsAppService.DeleteAsync(workshift.Id);
            }
        }

        public async Task OnDeleteDeductionMethod()
        {
            List<DeductionMethod_Dto> deductionMethods = JsonSerializer.Deserialize<List<DeductionMethod_Dto>>(Request.Form["deductionMethods"]);
            for (int i = 0; i < deductionMethods.Count; i++)
            {
                DeductionMethod_Dto deductionMethod = deductionMethods[i];
                await DeductionMethodsAppService.DeleteAsync(deductionMethod.Id);
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
                        LeaveRequestTemplate leaveRequestTemplate = await LeaveRequestTemplatesAppService.Repository.GetAsync(lrTemplateVM.Id, false);
                        //leaveRequestTemplate.Id = 0;
                        //LeaveRequestTemplate_Dto leaveRequestTemplate = new LeaveRequestTemplate_Dto();

                        leaveRequestTemplate.Title = lrTemplateVM.LRTitle;
                        leaveRequestTemplate.TitleLocalized = lrTemplateVM.LRTitleLocalized;
                        leaveRequestTemplate.Prefix = lrTemplateVM.LRPrefix;
                        leaveRequestTemplate.StartingNo = lrTemplateVM.LRStartingNo;
                        leaveRequestTemplate.EntitlementDays = lrTemplateVM.LREntitlementDays;

                        leaveRequestTemplate.HasAdvanceSalaryRequest = lrTemplateVM.LRAdvanceSalaryAD;
                        leaveRequestTemplate.HasAirTicketRequest = lrTemplateVM.LRAirTicketAD;
                        leaveRequestTemplate.HasExitReentryRequest = lrTemplateVM.LRExitReentryAD;

                        leaveRequestTemplate.HasNotesRequirement = lrTemplateVM.LRNotesAR;
                        leaveRequestTemplate.HasAttachmentRequirement = lrTemplateVM.LRAttachmentAR;

                        //var lrTempUpdated = await LeaveRequestTemplatesAppService.Repository.UpdateAsync(_leaveRequestTemplate);
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

        public class LeaveRequestTemplateViewModel
        {
            public LeaveRequestTemplateViewModel()
            {
                IsEditing = false;
            }

            public void Initialize()
            {
                LRApprovalRoute.ForEach(x => x.Initialize());
            }

            public int Id { get; set; }

            public bool IsEditing { get; set; }
            public string LRTitle { get; set; }
            public string LRTitleLocalized { get; set; }
            public string LRPrefix { get; set; }
            public int LRStartingNo { get; set; }
            public int LREntitlementDays { get; set; }
            public Guid[] LRDepartmentIds { get; set; }
            public Guid[] LRPositionsIds { get; set; }
            public Guid[] LREmploymentTypeIds { get; set; }
            public Guid[] LREmployeeStatusIds { get; set; }

            public List<LRApprovalRouteVM> LRApprovalRoute { get; set; }

            public Guid[] LRDeductionHolidaysIds { get; set; }

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
