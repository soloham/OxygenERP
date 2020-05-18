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
    public class OS_SkillTemplateAppService : CrudAppService<OS_SkillTemplate, OS_SkillTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_SkillTemplate_Dto, OS_SkillTemplate_Dto>
    {
        public OS_SkillTemplateAppService(IRepository<OS_SkillTemplate, int> repository /*IRepository<OS_DepartmentSkillTemplate, int> departmentSkillTemplateRepo,*/, IRepository<OS_CompensationMatrixTemplate, int> compensationMatrixRepository) : base(repository)
        {
            Repository = repository;
            CompensationMatrixRepository = compensationMatrixRepository;
        }

        public IRepository<OS_SkillTemplate, int> Repository { get; }
        public IRepository<OS_CompensationMatrixTemplate, int> CompensationMatrixRepository { get; }

        public async Task<List<OS_SkillTemplate_Dto>> GetAllSkillTemplatesAsync()
        {
            List<OS_SkillTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }

        public async Task<OS_CompensationMatrixTemplate_Dto> GetCompensationMatrixAsync(int compensationMatrixId)
        {
            OS_CompensationMatrixTemplate_Dto result = ObjectMapper.Map<OS_CompensationMatrixTemplate, OS_CompensationMatrixTemplate_Dto>(await CompensationMatrixRepository.GetAsync(compensationMatrixId, true));
            return result;
        }
    }
}
