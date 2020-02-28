using CERP.FM;
using CERP.FM.COA;
using CERP.FM.COA.DTOs;
using CERP.FM.COA.UV_DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP
{
    public class coaSubLedgerRequirementsAppService : CrudAppService<COA_SubLedgerRequirement, COA_SubLedgerRequirement_Dto, Guid, PagedAndSortedResultRequestDto, COA_SubLedgerRequirement_UV_Dto, COA_SubLedgerRequirement_UV_Dto>
    {
        public coaSubLedgerRequirementsAppService(IRepository<COA_SubLedgerRequirement, Guid> repository) : base(repository)
        {

        }
    }
}
