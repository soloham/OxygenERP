using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class EmailAddress : AuditedAggregateTenantRoot<int>
    {
        public EmailAddress()
        {

        }

        public DictionaryValue EmailType { get; set; }
        [CustomAudited]
        public Guid EmailTypeId { get; set; }

        [CustomAudited]
        public string Email { get; set; }

        [CustomAudited]
        public bool IsPrimary { get; set; }
    }
}
