using CERP.ApplicationContracts.HR.OrganizationalManagement;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.OrganizationalManagement;
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
        public OS_PositionTemplateAppService(IRepository<OS_PositionTemplate, int> repository, /*IRepository<OS_DepartmentPositionTemplate, int> departmentPositionTemplateRepo,*/ IRepository<OS_PositionJobTemplate, int> positionJobsTemplateRepo, IRepository<OS_PositionTaskTemplate, int> positionTasksTemplateRepo, IRepository<OS_PositionCostCenterTemplate, int> positionCostCentersTemplateRepo) : base(repository)
        {
            Repository = repository;
            //DepartmentPositionTemplateRepo = departmentPositionTemplateRepo;
            PositionJobsTemplateRepo = positionJobsTemplateRepo;
            PositionTasksTemplateRepo = positionTasksTemplateRepo;
            PositionCostCentersTemplateRepo = positionCostCentersTemplateRepo;
        }

        public IRepository<OS_PositionTemplate, int> Repository { get; }
        public IRepository<OS_PositionJobTemplate, int> PositionJobsTemplateRepo { get; }
        public IRepository<OS_PositionTaskTemplate, int> PositionTasksTemplateRepo { get; }

        public IRepository<OS_PositionCostCenterTemplate, int> PositionCostCentersTemplateRepo { get; set; }

        //public IRepository<OS_DepartmentPositionTemplate, int> DepartmentPositionTemplateRepo { get; }

        public async Task<List<OS_PositionTemplate_Dto>> GetAllPositionTemplatesAsync()
        {
            List<OS_PositionTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }

        public async Task<List<EntityReference>> GetAllReferences(int id)
        {
            List<EntityReference> entityReferences = new List<EntityReference>();

            entityReferences.AddRange(Repository.WithDetails(x => x.DepartmentTemplate).Where(x => x.Id == id)
                .ToList()
                .Select(x => new EntityReference() { Id = entityReferences.Count + 1, Name = x.DepartmentTemplate.Name, Code = x.DepartmentTemplate.Code, Type = "Department" }));

            return entityReferences;
        }
    }
}
