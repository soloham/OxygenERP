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
    public class CompensationMatrixTemplateAppService : CrudAppService<OS_CompensationMatrixTemplate, OS_CompensationMatrixTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_CompensationMatrixTemplate_Dto, OS_CompensationMatrixTemplate_Dto>
    {
        public CompensationMatrixTemplateAppService(IRepository<OS_CompensationMatrixTemplate, int> repository /*IRepository<OS_DepartmentCompensationMatrixTemplate, int> departmentCompensationMatrixTemplateRepo,*/) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<OS_CompensationMatrixTemplate, int> Repository { get; }

        public async Task<List<OS_CompensationMatrixTemplate_Dto>> GetAllCompensationMatrixTemplatesAsync()
        {
            List<OS_CompensationMatrixTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }
    }
}
