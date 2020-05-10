using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;

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
        public LocationStatus Status { get; set; }

        public void UpdateExtraProperties(Dictionary<string, object> extraProperties)
        {
            ExtraProperties = extraProperties;
        }
    }

}
