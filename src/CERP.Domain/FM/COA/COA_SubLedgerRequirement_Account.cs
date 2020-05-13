using CERP.Base;
using System;

namespace CERP.FM.COA
{
    public class COA_SubLedgerRequirement_Account : AuditedAggregateTenantRoot<Guid>
    {
        public COA_SubLedgerRequirement_Account()
        {

        }

        public Guid SubLedgerRequirementId { get; set; }
        public Guid AccountId { get; set; }

        public virtual COA_SubLedgerRequirement SubLedgerRequirement { get; set; }
        public virtual COA_Account Account { get; set; }
    }
}
