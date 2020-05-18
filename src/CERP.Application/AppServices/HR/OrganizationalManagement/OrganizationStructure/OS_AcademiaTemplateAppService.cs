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
    public class AcademiaTemplateAppService : CrudAppService<OS_AcademiaTemplate, OS_AcademiaTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_AcademiaTemplate_Dto, OS_AcademiaTemplate_Dto>
    {
        public AcademiaTemplateAppService(IRepository<OS_AcademiaTemplate, int> repository /*IRepository<OS_DepartmentAcademiaTemplate, int> departmentAcademiaTemplateRepo,*/) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<OS_AcademiaTemplate, int> Repository { get; }

        public async Task<List<OS_AcademiaTemplate_Dto>> GetAllAcademiaTemplatesAsync()
        {
            List<OS_AcademiaTemplate_Dto> list = (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
            return list;
        }
    }
}
