using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CERP.App;
using CERP.AppServices.HR.EmployeeService;
using CERP.HR.Employees;
using CERP.HR.Employees.DTOs;
using CERP.HR.Employees.UV_DTOs;
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
        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo;
        public IRepository<PhysicalID, int> PhysicalIdsRepo;

        public List<PhysicalID_Dto> PhysicalIds = new List<PhysicalID_Dto>();
        public List<PhysicalID_Dto> BasicSalaries = new List<PhysicalID_Dto>();

        public CreateModel(IRepository<DictionaryValue, Guid> dictionaryValuesRepo, EmployeeAppService employeeAppService, IRepository<PhysicalID, int> physicalIdsRepo)
        {
            DictionaryValuesRepo = dictionaryValuesRepo;
            this.employeeAppService = employeeAppService;
            PhysicalIdsRepo = physicalIdsRepo;
        }

        public void OnGet()
        {
            PhysicalIds = ObjectMapper.Map<List<PhysicalID>, List<PhysicalID_Dto>>(PhysicalIdsRepo.WithDetails().ToList());
            BasicSalaries = ObjectMapper.Map<List<PhysicalID>, List<PhysicalID_Dto>>(PhysicalIdsRepo.WithDetails().ToList());
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

        public async Task<IActionResult> OnPost(Employee_UV_Dto employee)
        {
            Employee_Dto empAdded = await employeeAppService.CreateEmployee(employee);

            return Page();
        }
    }
}
