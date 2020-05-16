using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Timesheets;
using CERP.HR.Workshifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_PositionTemplateAppService : CrudAppService<OS_PositionTemplate, OS_PositionTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_PositionTemplate_Dto, OS_PositionTemplate_Dto>
    {
        public OS_PositionTemplateAppService(IRepository<OS_PositionTemplate, int> repository, /*IRepository<OS_DepartmentPositionTemplate, int> departmentPositionTemplateRepo,*/ IRepository<OS_PositionJobTemplate, int> positionJobsTemplateRepo, IRepository<OS_PositionTaskTemplate, int> positionTasksTemplateRepo) : base(repository)
        {
            Repository = repository;
            //DepartmentPositionTemplateRepo = departmentPositionTemplateRepo;
            PositionJobsTemplateRepo = positionJobsTemplateRepo;
            PositionTasksTemplateRepo = positionTasksTemplateRepo;
        }

        public IRepository<OS_PositionTemplate, int> Repository { get; }
        public IRepository<OS_PositionJobTemplate, int> PositionJobsTemplateRepo { get; }
        public IRepository<OS_PositionTaskTemplate, int> PositionTasksTemplateRepo { get; }
        //public IRepository<OS_DepartmentPositionTemplate, int> DepartmentPositionTemplateRepo { get; }

        public async Task<List<OS_PositionTemplate_Dto>> GetAllPositionTemplatesAsync()
        {
            List<OS_PositionTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }
    }
}
