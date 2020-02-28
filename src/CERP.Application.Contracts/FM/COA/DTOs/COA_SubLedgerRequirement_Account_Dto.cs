using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CERP.FM.COA.DTOs
{
    public class COA_SubLedgerRequirement_Account_Dto : AuditedEntityDto<Guid>
    {
        public Guid SubLedgerRequirementId { get; set; }
        public Guid AccountId { get; set; }

        public COA_SubLedgerRequirement_Dto SubLedgerRequirement { get; set; }
        public COA_Account_Dto Account { get; set; }
    }
}
