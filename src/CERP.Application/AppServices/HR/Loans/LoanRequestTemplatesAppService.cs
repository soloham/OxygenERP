using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Loans;
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

namespace CERP.AppServices.HR.LoanRequestService
{
    public class LoanRequestTemplatesAppService : CrudAppService<LoanRequestTemplate, LoanRequestTemplate_Dto, int, PagedAndSortedResultRequestDto, LoanRequestTemplate_Dto, LoanRequestTemplate_Dto>
    {
        public LoanRequestTemplatesAppService(IRepository<LoanRequestTemplate, int> repository, IRepository<LoanRequestTemplateDepartment> departmentsRepository, IRepository<LoanRequestTemplatePosition> positionsRepository, IRepository<LoanRequestTemplateEmploymentType> employeeTypesRepository, IRepository<LoanRequestTemplateEmployeeStatus> employeeStatusesRepository) : base(repository)
        {
            Repository = repository;
            DepartmentsRepository = departmentsRepository;
            PositionsRepository = positionsRepository;
            EmployeeTypesRepository = employeeTypesRepository;
            EmployeeStatusesRepository = employeeStatusesRepository;
        }

        public IRepository<LoanRequestTemplate, int> Repository { get; }
        public IRepository<LoanRequestTemplateDepartment> DepartmentsRepository { get; }
        public IRepository<LoanRequestTemplatePosition> PositionsRepository { get; }
        public IRepository<LoanRequestTemplateEmploymentType> EmployeeTypesRepository { get; }
        public IRepository<LoanRequestTemplateEmployeeStatus> EmployeeStatusesRepository { get; }


        [Route("/api/app/LoanRequestTemplates/getAllAsync")]
        public async Task<List<LoanRequestTemplate_Dto>> GetAllAsync(bool includeDetails = true)
        {
            List<LoanRequestTemplate> all = new List<LoanRequestTemplate>();
            if (!includeDetails) {
                all = Repository.WithDetails(x => x.LoanType).ToList();
            }
            else
            {
                all = await Repository.GetListAsync(includeDetails);
            }
            List<LoanRequestTemplate_Dto> mapped = ObjectMapper.Map<List<LoanRequestTemplate>, List<LoanRequestTemplate_Dto>>(all);
            return mapped;
        }
        public async Task<LoanRequestTemplate_Dto> GetCustomAsync(int id)
        {
            LoanRequestTemplate source = await Repository.GetAsync(id, true);
            return ObjectMapper.Map<LoanRequestTemplate, LoanRequestTemplate_Dto>(source);
        }

        public async Task<LoanRequestTemplate_Dto> CreateCustomAsync(LoanRequestTemplate_Dto LoanRequestTemplate)
        {
            var created = await CreateAsync(LoanRequestTemplate);
            return await GetCustomAsync(created.Id);
        }
    }
}
