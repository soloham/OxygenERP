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
using Volo.Abp.Json;

namespace CERP.Web.Areas.HR.Pages.Employees
{
    public class EditModel : CERPPageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid EmployeeId { get; set; }

        public Employee_Dto EmployeeToEdit { get; set; }
        public IJsonSerializer JsonSerializer { get; set; }

        public EmployeeAppService employeeAppService;
        public DepartmentAppService departmentAppService;
        public PositionAppService positionAppService;
        public WorkShiftsAppService workShiftsAppService;

        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo;

        //public List<PhysicalID_Dto> PhysicalIds = new List<PhysicalID_Dto>();
        public List<PhysicalID_Dto> BasicSalaries = new List<PhysicalID_Dto>();

        public List<Department_Dto> Departments = new List<Department_Dto>();

        public GeneralInfo GeneralInfo { get; set; }
        public FinancialDetails FinancialDetails { get; set; }
        public ContactInformation ContactInformation { get; set; }
        public QualificationDetail QualificationDetail { get; set; }
        public DependantsDetail DependantsDetail { get; set; }
        public WorkShiftDetail WorkShiftDetail { get; set; }

        public EditModel(IRepository<DictionaryValue, Guid> dictionaryValuesRepo, EmployeeAppService employeeAppService, DepartmentAppService departmentAppService, PositionAppService positionAppService, WorkShiftsAppService workShiftsAppService, IJsonSerializer jsonSerializer)
        {
            DictionaryValuesRepo = dictionaryValuesRepo;
            this.employeeAppService = employeeAppService;
            this.departmentAppService = departmentAppService;
            this.positionAppService = positionAppService;
            this.workShiftsAppService = workShiftsAppService;
            JsonSerializer = jsonSerializer;
        }

        public JsonResult OnGetPositions(Guid departmentId)
        {
            List<Position_Dto> result =  positionAppService.GetPositionByDepartmentId(departmentId);
            return new JsonResult(result);
        }
        public async Task<IActionResult> OnGet()
        {
            if (EmployeeId != null && EmployeeId != Guid.Empty)
            {
                EmployeeToEdit = await employeeAppService.GetAsync(EmployeeId);

                GeneralInfo = JsonSerializer.Deserialize<GeneralInfo>(EmployeeToEdit.ExtraProperties["generalInfo"].ToString());
                GeneralInfo.Initialize(DictionaryValuesRepo);
                FinancialDetails = JsonSerializer.Deserialize<FinancialDetails>(EmployeeToEdit.ExtraProperties["financialDetails"].ToString());
                FinancialDetails.Initialize(DictionaryValuesRepo);
                ContactInformation = JsonSerializer.Deserialize<ContactInformation>(EmployeeToEdit.ExtraProperties["contactInformation"].ToString());
                ContactInformation.Initialize(DictionaryValuesRepo);
                DependantsDetail = JsonSerializer.Deserialize<DependantsDetail>(EmployeeToEdit.ExtraProperties["dependantsDetail"].ToString());
                DependantsDetail.Initialize(DictionaryValuesRepo);
                QualificationDetail = JsonSerializer.Deserialize<QualificationDetail>(EmployeeToEdit.ExtraProperties["qualificationDetail"].ToString());
                QualificationDetail.Initialize(DictionaryValuesRepo);
                WorkShiftDetail = JsonSerializer.Deserialize<WorkShiftDetail>(EmployeeToEdit.ExtraProperties["workShiftDetail"].ToString());
                WorkShiftDetail.Initialize(workShiftsAppService.Repository);
            }

            Departments = departmentAppService.GetDepartments();

            return Page();
        }
        public async Task<IActionResult> OnPost(Employee_UV_Dto employee, IList<PhysicalId<Guid>> physicalIDs, IList<BasicSalaryRDTO> basicSalaries, IList<AllowanceRDTO> allowances, IList<BanksRDTO> banks, Contact primaryContact, NationalAddress nationalAddress, IList<Contact> secondaryContacts, IList<Qualification> qualifications, IList<Dependant> dependants, IList<PhysicalId<int>> dependantsIds, IList<WorkShiftRDto> workShifts)
        {
            try
            {
                //for (int i = 0; i < physicalIDs.Count; i++)
                //{
                //    //physicalIDs[i].SetId(GuidGenerator.Create());
                //    physicalIDs[i].IDTypeId = physicalIDs[i].IDType.Id;
                //    physicalIDs[i].IDType = null;
                //    physicalIDs[i].IssuedFromId = physicalIDs[i].IssuedFrom.Id;
                //    physicalIDs[i].IssuedFrom = null;
                //}

                //var empIds = new List<PhysicalID_UV_Dto>();

                //empIds.AddRange(physicalIDs);
                //employee.PhysicalIDs = empIds;
                employee.WorkShiftId = workShifts.Last().WorkShiftId;
                //Employee_UV_Dto employeeObj = JsonSerializer.Deserialize<Employee_UV_Dto>(employee);

                GeneralInfo generalInfo = new GeneralInfo(physicalIDs);
                FinancialDetails financialDetails = new FinancialDetails(basicSalaries, allowances, banks);
                ContactInformation contactInformation = new ContactInformation(primaryContact, nationalAddress, secondaryContacts);
                QualificationDetail qualificationDetail = new QualificationDetail(qualifications);
                DependantsDetail dependantsDetail = new DependantsDetail(dependants, dependantsIds);
                WorkShiftDetail workShiftDetail = new WorkShiftDetail(workShifts);

                employee.ExtraProperties.Add("generalInfo", generalInfo);
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
