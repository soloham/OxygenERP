using CERP.Base;
using System.Collections.Generic;

namespace CERP.Setup
{
    public class Currency : AuditedAggregateTenantRoot<int>
    {
        public Currency()
        {
        }

        public string CurrencyName { get; set; }
        public string CurrencyNameLocal { get; set; }
        public string CurrencyCode { get; set; }

        public void UpdateExtraProperties(Dictionary<string, object> extraProperties)
        {
            ExtraProperties = extraProperties;
        }
    }

}
