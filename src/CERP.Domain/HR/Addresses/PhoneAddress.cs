using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class PhoneAddress : AuditedAggregateTenantRoot<int>
    {
        public PhoneAddress()
        {

        }

        public DictionaryValue PhoneType { get; set; }
        [CustomAudited]
        public Guid PhoneTypeId { get; set; }

        [CustomAudited]
        public string PhoneNumber { get; set; }
        [CustomAudited]
        public string Extension { get; set; }

        [CustomAudited]
        public bool IsPrimary { get; set; }
    }
}
