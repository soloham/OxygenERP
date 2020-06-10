using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class PhoneAddress_Dto : AuditedEntityTenantDto<int>
    {
        public PhoneAddress_Dto()
        {

        }

        public DictionaryValue_Dto PhoneType { get; set; }
        public Guid PhoneTypeId { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public bool IsPrimary { get; set; }
    }
}
