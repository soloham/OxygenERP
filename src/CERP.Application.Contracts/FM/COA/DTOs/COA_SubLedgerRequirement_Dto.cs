using CERP.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM.COA.DTOs
{
    public class COA_SubLedgerRequirement_Dto : FullAuditedEntityTenantDto<Guid> 
    {
        public COA_SubLedgerRequirement_Dto()
        {

        }
        public COA_SubLedgerRequirement_Dto(Guid id)
        {
            Id = id;
        }
        public string Title { get; set; }
        public string TitleLocalizationKey { get; set; }

        public List<COA_SubLedgerRequirement_Account_Dto> SubLedgerRequirementAccounts { get; set; }
    }
}
