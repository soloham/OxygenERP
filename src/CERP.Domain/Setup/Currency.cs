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
    public class Currency : AuditedAggregateTenantRoot<int>
    {
        public Currency()
        {
        }

        public string CurrencyName { get; set; }
        public string CurrencyNameLocal { get; set; }
        public string CurrencyCode { get; set; }
        public CurrencyStatus Status { get; set; }

        public void UpdateExtraProperties(Dictionary<string, object> extraProperties)
        {
            ExtraProperties = extraProperties;
        }
    }

}
