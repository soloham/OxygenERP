using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.Setup;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class CashPaymentType : AuditedAggregateTenantRoot<int>
    {
        public CashPaymentType()
        {

        }

        public LocationTemplate CollectionLocation { get; set; }
        [CustomAudited]
        public Guid CollectionLocationId { get; set; }

        [CustomAudited]
        public string ValidityFromDate { get; set; }
        [CustomAudited]
        public string ValidityToDate { get; set; }

        [CustomAudited]
        public bool IsPrimary { get; set; }
    }
}
