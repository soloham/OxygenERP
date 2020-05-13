using CERP.Base;
using System;

namespace CERP.FM.COA
{
    public class COA_HeadAccount : FullAuditedAggregateTenantRoot<Guid> 
    {
        public COA_HeadAccount()
        {

        }
        public COA_HeadAccount(Guid id)
        {
            Id = id;
        }
        public HeadAccountType HeadCode { get; set; }
        public string AccountName { get; set; }
        public string LocalizationKey { get; set; }
    }
}
