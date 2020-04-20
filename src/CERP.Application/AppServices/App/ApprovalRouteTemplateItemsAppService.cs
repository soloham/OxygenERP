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
    public class ApprovalRouteTemplateItemsAppService : CrudAppService<ApprovalRouteTemplateItem, ApprovalRouteTemplate_Dto, int, PagedAndSortedResultRequestDto, ApprovalRouteTemplateItem_Dto, ApprovalRouteTemplateItem_Dto>
    {
        public ApprovalRouteTemplateItemsAppService(IRepository<ApprovalRouteTemplateItem, int> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<ApprovalRouteTemplateItem, int> Repository { get; }
    }
}
