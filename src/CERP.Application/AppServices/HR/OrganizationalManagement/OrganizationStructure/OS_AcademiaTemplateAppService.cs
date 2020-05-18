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
    public class OS_AcademiaTemplateAppService : CrudAppService<OS_AcademiaTemplate, OS_AcademiaTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_AcademiaTemplate_Dto, OS_AcademiaTemplate_Dto>
    {
        public OS_AcademiaTemplateAppService(IRepository<OS_AcademiaTemplate, int> repository /*IRepository<OS_DepartmentAcademiaTemplate, int> departmentAcademiaTemplateRepo,*/, IRepository<OS_CompensationMatrixTemplate, int> compensationMatrixRepository) : base(repository)
        {
            Repository = repository;
            CompensationMatrixRepository = compensationMatrixRepository;
        }

        public IRepository<OS_AcademiaTemplate, int> Repository { get; }
        public IRepository<OS_CompensationMatrixTemplate, int> CompensationMatrixRepository { get; }

        public async Task<List<OS_AcademiaTemplate_Dto>> GetAllAcademiaTemplatesAsync()
        {
            List<OS_AcademiaTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }

        public async Task<OS_CompensationMatrixTemplate_Dto> GetCompensationMatrixAsync(int compensationMatrixId)
        {
            OS_CompensationMatrixTemplate_Dto result = ObjectMapper.Map<OS_CompensationMatrixTemplate, OS_CompensationMatrixTemplate_Dto>(await CompensationMatrixRepository.GetAsync(compensationMatrixId, true));
            return result;
        }
    }
}
