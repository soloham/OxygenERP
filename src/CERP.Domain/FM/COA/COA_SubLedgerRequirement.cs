using CERP.Base;
using System;
using System.Collections.Generic;

namespace CERP.FM.COA
{
    public class COA_SubLedgerRequirement : FullAuditedAggregateTenantRoot<Guid> 
    {
        public COA_SubLedgerRequirement()
        {

        }
        public COA_SubLedgerRequirement(Guid id)
        {
            Id = id;
        }
        public string Title { get; set; }
        public string TitleLocalizationKey { get; set; }

        public virtual ICollection<COA_SubLedgerRequirement_Account> SubLedgerRequirementAccounts { get; set; }
    }
}
