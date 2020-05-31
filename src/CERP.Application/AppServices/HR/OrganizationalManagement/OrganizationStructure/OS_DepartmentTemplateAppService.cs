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
    public class OS_DepartmentTemplateAppService : CrudAppService<OS_DepartmentTemplate, OS_DepartmentTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_DepartmentTemplate_Dto, OS_DepartmentTemplate_Dto>
    {
        public OS_DepartmentTemplateAppService(IRepository<OS_DepartmentTemplate, int> repository, /*IRepository<OS_DepartmentPositionTemplate, int> departmentPositionTemplateRepo,*/ IRepository<OS_DepartmentSubDepartmentTemplate, int> departmentSubDepartmentTemplateRepo, IRepository<OS_PositionTemplate, int> positionTemplateRepo, IRepository<OS_DepartmentCostCenterTemplate, int> departmentCostCentersTemplateRepo) : base(repository)
        {
            Repository = repository;
            //DepartmentPositionTemplateRepo = departmentPositionTemplateRepo;
            DepartmentSubDepartmentTemplateRepo = departmentSubDepartmentTemplateRepo;
            PositionTemplateRepo = positionTemplateRepo;
            DepartmentCostCentersTemplateRepo = departmentCostCentersTemplateRepo;
        }

        public IRepository<OS_DepartmentTemplate, int> Repository { get; }
        //public IRepository<OS_DepartmentPositionTemplate, int> DepartmentPositionTemplateRepo { get; set; }
        public IRepository<OS_DepartmentSubDepartmentTemplate, int> DepartmentSubDepartmentTemplateRepo { get; set; }
        public IRepository<OS_PositionTemplate, int> PositionTemplateRepo { get; set; }

        public IRepository<OS_DepartmentCostCenterTemplate, int> DepartmentCostCentersTemplateRepo { get; set; }

        public async Task<List<OS_DepartmentTemplate_Dto>> GetAllDepartmentTemplatesAsync()
        {
            List<OS_DepartmentTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }

        public async Task<OS_DepartmentTemplate_Dto> GetDepartmentTemplateAsync(int id)
        {   
            OS_DepartmentTemplate_Dto result = ObjectMapper.Map<OS_DepartmentTemplate, OS_DepartmentTemplate_Dto>(await Repository.GetAsync(id, true));
            return result;
        }
    }
}
