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
    public class OS_JobTemplateAppService : CrudAppService<OS_JobTemplate, OS_JobTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_JobTemplate_Dto, OS_JobTemplate_Dto>
    {
        public OS_JobTemplateAppService(IRepository<OS_JobTemplate, int> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<OS_JobTemplate, int> Repository { get; }

        public async Task<List<OS_JobTemplate_Dto>> GetAllJobTemplatesAsync()
        {
            return (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
        }
    }
}
