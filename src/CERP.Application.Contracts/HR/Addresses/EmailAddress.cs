using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class EmailAddress_Dto : AuditedEntityTenantDto<int>
    {
        public EmailAddress_Dto()
        {

        }

        public DictionaryValue_Dto EmailType { get; set; }
        [CustomAudited]
        public Guid EmailTypeId { get; set; }

        [CustomAudited]
        public string Email { get; set; }

        [CustomAudited]
        public bool IsPrimary { get; set; }
    }
}
