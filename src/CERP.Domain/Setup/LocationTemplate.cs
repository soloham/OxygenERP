using CERP.App;
using CERP.Base;
using System;
using System.Collections.Generic;

namespace CERP.Setup
{
    public class LocationTemplate : AuditedAggregateTenantRoot<Guid>
    {
        public LocationTemplate()
        {
        }

        public string LocationName { get; set; }
        public string LocationNameLocalized { get; set; }
        public string LocationCode { get; set; }
        public string LocationPhone { get; set; }
        public string LocationMobile { get; set; }
        public string LocationFax { get; set; }
        public string LocationEmail { get; set; }

        public DictionaryValue LocationCountry { get; set; }
        public Guid LocationCountryId { get; set; }

        public LocationStatus Status { get; set; }

        public void UpdateExtraProperties(Dictionary<string, object> extraProperties)
        {
            ExtraProperties = extraProperties;
        }
    }

}
