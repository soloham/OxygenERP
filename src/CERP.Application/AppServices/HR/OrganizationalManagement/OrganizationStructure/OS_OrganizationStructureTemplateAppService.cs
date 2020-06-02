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
    public class OS_OrganizationStructureTemplateAppService : CrudAppService<OS_OrganizationStructureTemplate, OS_OrganizationStructureTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_OrganizationStructureTemplate_Dto, OS_OrganizationStructureTemplate_Dto>
    {
        public IRepository<OS_OrganizationStructureTemplate, int> Repository { get; }
        public IRepository<OS_OrganizationStructureTemplateBusinessUnit, int> BusinessUnitsRepository { get; }
        public IRepository<OS_OrganizationStructureTemplateBusinessUnitPosition, int> BusinessUnitPositionsRepository { get; }
        public IRepository<OS_OrganizationStructureTemplateDivision, int> DivisionsRepository { get; }
        public IRepository<OS_OrganizationStructureTemplateDivisionPosition, int> DivisionPositionsRepository { get; }
        public IRepository<OS_OrganizationStructureTemplateDepartment, int> DepartmentsRepository { get; }
        public IRepository<OS_OrganizationStructureTemplateDepartmentPosition, int> DepartmentPositionsRepository { get; }

        public OS_OrganizationStructureTemplateAppService(IRepository<OS_OrganizationStructureTemplate, int> repository, IRepository<OS_OrganizationStructureTemplateBusinessUnit, int> businessUnitsRepository, IRepository<OS_OrganizationStructureTemplateBusinessUnitPosition, int> businessUnitPositionsRepository, IRepository<OS_OrganizationStructureTemplateDivision, int> divisionsRepository, IRepository<OS_OrganizationStructureTemplateDivisionPosition, int> divisionPositionsRepository, IRepository<OS_OrganizationStructureTemplateDepartment, int> departmentsRepository, IRepository<OS_OrganizationStructureTemplateDepartmentPosition, int> departmentPositionsRepository) : base(repository)
        {
            Repository = repository;
            BusinessUnitsRepository = businessUnitsRepository;
            BusinessUnitPositionsRepository = businessUnitPositionsRepository;
            DivisionsRepository = divisionsRepository;
            DivisionPositionsRepository = divisionPositionsRepository;
            DepartmentsRepository = departmentsRepository;
            DepartmentPositionsRepository = departmentPositionsRepository;
        }

        public async Task<List<OS_OrganizationStructureTemplate_Dto>> GetAllOrganizationStructureTemplatesAsync()
        {
            List<OS_OrganizationStructureTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }
        public async Task<OS_OrganizationStructureTemplate_Dto> GetOrganizationStructureTemplateAsync(int id)
        {
            OS_OrganizationStructureTemplate_Dto obj = ObjectMapper.Map< OS_OrganizationStructureTemplate, OS_OrganizationStructureTemplate_Dto>(await Repository.GetAsync(id, true));
            return obj;
        }

        public async Task<List<OS_OrganizationStructureTemplateBusinessUnit_Dto>> GetBusinessUnitsAsync(int osId)
        {
            List<OS_OrganizationStructureTemplateBusinessUnit_Dto> obj = ObjectMapper.Map<List<OS_OrganizationStructureTemplateBusinessUnit>, List<OS_OrganizationStructureTemplateBusinessUnit_Dto>>(BusinessUnitsRepository.WithDetails().Where(x => x.OrganizationStructureTemplateId == osId).ToList());
            return obj;
        }
        public async Task<List<OS_OrganizationStructureTemplateDivision_Dto>> GetDivisionsAsync(int osId)
        {
            List<OS_OrganizationStructureTemplateDivision_Dto> obj = ObjectMapper.Map<List<OS_OrganizationStructureTemplateDivision>, List<OS_OrganizationStructureTemplateDivision_Dto>>(DivisionsRepository.WithDetails().Where(x => x.OrganizationStructureTemplateId == osId).ToList());
            return obj;
        }
        public async Task<List<OS_OrganizationStructureTemplateDepartment_Dto>> GetDepartmentsAsync(int osId)
        {
            List<OS_OrganizationStructureTemplateDepartment_Dto> obj = ObjectMapper.Map<List<OS_OrganizationStructureTemplateDepartment>, List<OS_OrganizationStructureTemplateDepartment_Dto>>(DepartmentsRepository.WithDetails().Where(x => x.OrganizationStructureTemplateId == osId).ToList());
            return obj;
        }
    }
}
