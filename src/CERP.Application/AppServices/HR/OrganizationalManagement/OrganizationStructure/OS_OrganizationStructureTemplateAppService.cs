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

        public OS_OrganizationStructureTemplateAppService(IRepository<OS_OrganizationStructureTemplate, int> repository) : base(repository)
        {
            Repository = repository;
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
    }
}
