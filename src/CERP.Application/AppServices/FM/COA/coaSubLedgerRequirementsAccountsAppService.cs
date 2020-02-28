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
    public class coaSubLedgerRequirementsAccountsAppService : CrudAppService<COA_SubLedgerRequirement_Account, COA_SubLedgerRequirement_Account_Dto, Guid, PagedAndSortedResultRequestDto, COA_SubLedgerRequirement_Account_UV_Dto, COA_SubLedgerRequirement_Account_UV_Dto>
    {
        public coaSubLedgerRequirementsAccountsAppService(IRepository<COA_SubLedgerRequirement_Account, Guid> repository) : base(repository)
        {

        }
    }
}
