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
    public class OS_TaskTemplateAppService : CrudAppService<OS_TaskTemplate, OS_TaskTemplate_Dto, int, PagedAndSortedResultRequestDto, OS_TaskTemplate_Dto, OS_TaskTemplate_Dto>
    {
        public OS_TaskTemplateAppService(IRepository<OS_TaskTemplate, int> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<OS_TaskTemplate, int> Repository { get; }

        public async Task<List<OS_TaskTemplate_Dto>> GetAllTaskTemplatesAsync()
        {
            return (await Repository.GetListAsync(true)).Select(MapToGetListOutputDto).ToList();
        }
    }
}
