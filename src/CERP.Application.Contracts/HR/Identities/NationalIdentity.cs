using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class NationalIdentity_Dto : AuditedEntityTenantDto<int>
    {
        public NationalIdentity_Dto()
        {

        }

        public DictionaryValue_Dto IdType { get; set; }
        [CustomAudited]
        public Guid IdTypeId { get; set; }

        [CustomAudited]
        public string IDNumber { get; set; }
        [CustomAudited]
        public string IDAttachment { get; set; }

        [CustomAudited]
        public bool IsPrimary { get; set; }

        [CustomAudited]
        public string ValidityFromDate { get; set; }
        [CustomAudited]
        public string ValidityToDate { get; set; }
    }
}
