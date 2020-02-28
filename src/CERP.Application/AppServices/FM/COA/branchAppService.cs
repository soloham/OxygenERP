using CERP.FM;
using CERP.FM.COA;
using CERP.FM.DTOs;
using CERP.FM.UV_DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP
{
    public class branchAppService : CrudAppService<Branch, Branch_Dto, Guid, PagedAndSortedResultRequestDto, Branch_UV_Dto, Branch_UV_Dto>
    {
        public branchAppService(IRepository<Branch, Guid> repository) : base(repository)
        {
        }
    }
}
