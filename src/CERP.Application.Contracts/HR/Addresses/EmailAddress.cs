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
        public Guid EmailTypeId { get; set; }
        public string Email { get; set; }
        public bool IsPrimary { get; set; }
    }
}
