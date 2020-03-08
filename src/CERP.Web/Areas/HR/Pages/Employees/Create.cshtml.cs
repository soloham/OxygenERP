using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Helpers;
using CERP.App;
using CERP.AppServices.HR.EmployeeService;
using CERP.AppServices.HR.WorkShiftService;
using CERP.AppServices.Setup.DepartmentSetup;
using CERP.AppServices.Setup.PositionSetup;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.EMPLOYEE.RougeDTOs;
using CERP.HR.Employees;
using CERP.HR.Employees.DTOs;
using CERP.HR.Employees.UV_DTOs;
using CERP.Setup;
using CERP.Setup.DTOs;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Base;
using Volo.Abp.Domain.Repositories;

namespace CERP.Web.Areas.HR.Pages.Employees
{
    public class CreateModel : CERPPageModel
    {
        public EmployeeAppService employeeAppService;
        public DepartmentAppService departmentAppService;
        public PositionAppService positionAppService;
        public WorkShiftsAppService workShiftsAppService;

        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo;
        public IRepository<PhysicalID, int> PhysicalIdsRepo;

        public List<PhysicalID_Dto> PhysicalIds = new List<PhysicalID_Dto>();
        public List<PhysicalID_Dto> BasicSalaries = new List<PhysicalID_Dto>();

        public List<Department_Dto> Departments = new List<Department_Dto>();

        public CreateModel(IRepository<DictionaryValue, Guid> dictionaryValuesRepo, EmployeeAppService employeeAppService, IRepository<PhysicalID, int> physicalIdsRepo, DepartmentAppService departmentAppService, PositionAppService positionAppService, WorkShiftsAppService workShiftsAppService)
        {
            DictionaryValuesRepo = dictionaryValuesRepo;
            this.employeeAppService = employeeAppService;
            PhysicalIdsRepo = physicalIdsRepo;
            this.departmentAppService = departmentAppService;
            this.positionAppService = positionAppService;
            this.workShiftsAppService = workShiftsAppService;
        }

        public JsonResult OnGetPositions(Guid departmentId)
        {
            List<Position_Dto> result =  positionAppService.GetPositionByDepartmentId(departmentId);
            return new JsonResult(result);
        }
        public void OnGet()
        {
            PhysicalIds = ObjectMapper.Map<List<PhysicalID>, List<PhysicalID_Dto>>(PhysicalIdsRepo.WithDetails().ToList());
            BasicSalaries = ObjectMapper.Map<List<PhysicalID>, List<PhysicalID_Dto>>(PhysicalIdsRepo.WithDetails().ToList());

            Departments = departmentAppService.GetDepartments();

        }
        public IActionResult OnPostEditPartial([FromBody] CRUDModel<_DialogEditPartialModel> value)
        {
            //var order = OrdersDetails.GetAllRecords();
            //ViewBag.datasource = order;
            return PartialView("_DialogEditPartial", value.Value);
        }

        public async Task<IActionResult> OnPostAddPhysicalId(PhysicalID physicalId)
        {
            try
            {
                var result = await PhysicalIdsRepo.InsertAsync(physicalId);
                PhysicalIds = ObjectMapper.Map<List<PhysicalID>, List<PhysicalID_Dto>>(PhysicalIdsRepo.WithDetails().ToList());
            }
            catch(Exception ex)
            {

            }
            return Page();
        }

        public async Task<IActionResult> OnPost(Employee_UV_Dto employee, IList<PhysicalID_UV_Dto> physicalIDs, IList<BasicSalaryRDTO> basicSalaries, IList<AllowanceRDTO> allowances, IList<BanksRDTO> banks, Contact primaryContact, NationalAddress nationalAddress, IList<Contact> secondaryContacts, IList<Qualification> qualifications, IList<Dependant> dependants, IList<PhysicalId<int>> dependantsIds, IList<WorkShiftRDto> workShifts)
        {
            try
            {
                for (int i = 0; i < physicalIDs.Count; i++)
                {
                    //physicalIDs[i].SetId(GuidGenerator.Create());
                    physicalIDs[i].IDTypeId = physicalIDs[i].IDType.Id;
                    physicalIDs[i].IDType = null;
                    physicalIDs[i].IssuedFromId = physicalIDs[i].IssuedFrom.Id;
                    physicalIDs[i].IssuedFrom = null;
                }

                var empIds = new List<PhysicalID_UV_Dto>();

                empIds.AddRange(physicalIDs);
                //employee.PhysicalIDs = empIds;
                employee.WorkShiftId = workShifts.Last().WorkShiftId;
                //Employee_UV_Dto employeeObj = JsonSerializer.Deserialize<Employee_UV_Dto>(employee);

                FinancialDetails financialDetails = new FinancialDetails(basicSalaries, allowances, banks);
                ContactInformation contactInformation = new ContactInformation(primaryContact, nationalAddress, secondaryContacts);
                QualificationDetail qualificationDetail = new QualificationDetail(qualifications);
                DependantsDetail dependantsDetail = new DependantsDetail(dependants, dependantsIds);
                WorkShiftDetail workShiftDetail = new WorkShiftDetail(workShifts);

                employee.ExtraProperties.Add("financialDetails", financialDetails);
                employee.ExtraProperties.Add("contactInformation", contactInformation);
                employee.ExtraProperties.Add("qualificationDetail", qualificationDetail);
                employee.ExtraProperties.Add("dependantsDetail", dependantsDetail);
                employee.ExtraProperties.Add("workShiftDetail", workShiftDetail);
                Employee_Dto empAdded = await employeeAppService.CreateEmployee(employee);
            }
            catch(Exception ex)
            {

            }
            return Page();
        }
    }
}
