using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Leaves;
using CERP.HR.Workshift.DTOs;
using CERP.HR.Workshifts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.HR.LeaveRequestService
{
    public class LeaveRequestTemplatesAppService : CrudAppService<LeaveRequestTemplate, LeaveRequestTemplate_Dto, int, PagedAndSortedResultRequestDto, LeaveRequestTemplate_Dto, LeaveRequestTemplate_Dto>
    {
        public LeaveRequestTemplatesAppService(IRepository<LeaveRequestTemplate, int> repository, IRepository<LeaveRequestTemplateDepartment> departmentsRepository, IRepository<LeaveRequestTemplatePosition> positionsRepository, IRepository<LeaveRequestTemplateEmploymentType> employeeTypesRepository, IRepository<LeaveRequestTemplateEmployeeStatus> employeeStatusesRepository, IRepository<LeaveRequestTemplateHoliday> holidaysRepository) : base(repository)
        {
            Repository = repository;
            DepartmentsRepository = departmentsRepository;
            PositionsRepository = positionsRepository;
            EmployeeTypesRepository = employeeTypesRepository;
            EmployeeStatusesRepository = employeeStatusesRepository;
            HolidaysRepository = holidaysRepository;
        }

        public IRepository<LeaveRequestTemplate, int> Repository { get; }
        public IRepository<LeaveRequestTemplateDepartment> DepartmentsRepository { get; }
        public IRepository<LeaveRequestTemplatePosition> PositionsRepository { get; }
        public IRepository<LeaveRequestTemplateEmploymentType> EmployeeTypesRepository { get; }
        public IRepository<LeaveRequestTemplateEmployeeStatus> EmployeeStatusesRepository { get; }
        public IRepository<LeaveRequestTemplateHoliday> HolidaysRepository { get; }


        [Route("/api/app/leaveRequestTemplates/getAllAsync")]
        public async Task<List<LeaveRequestTemplate_Dto>> GetAllAsync(bool includeDetails = true)
        {
            List<LeaveRequestTemplate> all = new List<LeaveRequestTemplate>();
            if (!includeDetails) {
                all = Repository.WithDetails(x => x.LeaveType).ToList();
            }
            else
            {
                all = await Repository.GetListAsync(includeDetails);
            }
            List<LeaveRequestTemplate_Dto> mapped = ObjectMapper.Map<List<LeaveRequestTemplate>, List<LeaveRequestTemplate_Dto>>(all);
            return mapped;
        }
        public async Task<LeaveRequestTemplate_Dto> GetCustomAsync(int id)
        {
            return ObjectMapper.Map<LeaveRequestTemplate, LeaveRequestTemplate_Dto>(await Repository.GetAsync(id, true));
        }

        public async Task<LeaveRequestTemplate_Dto> CreateCustomAsync(LeaveRequestTemplate_Dto leaveRequestTemplate)
        {
            var created = await CreateAsync(leaveRequestTemplate);
            return await GetCustomAsync(created.Id);
        }
    }
}
