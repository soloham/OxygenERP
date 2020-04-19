using CERP.App;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Leaves;
using CERP.HR.Workshift.DTOs;
using CERP.HR.Workshifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.App.ApprovalRouteService
{
    public class ApprovalRouteTemplatesAppService : CrudAppService<ApprovalRouteTemplate, ApprovalRouteTemplate_Dto, int, PagedAndSortedResultRequestDto, ApprovalRouteTemplate_Dto, ApprovalRouteTemplate_Dto>
    {
        public ApprovalRouteTemplatesAppService(IRepository<ApprovalRouteTemplate, int> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<ApprovalRouteTemplate, int> Repository { get; }

        public async Task<ApprovalRouteTemplate_Dto> GetFull(int id)
        {
            return ObjectMapper.Map<ApprovalRouteTemplate, ApprovalRouteTemplate_Dto>(await Repository.GetAsync(id, true));
        }
    }
}
