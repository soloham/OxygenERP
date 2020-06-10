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
        public Guid IdTypeId { get; set; }
        public string IDNumber { get; set; }
        public string IDAttachment { get; set; }
        public bool IsPrimary { get; set; }
        public string ValidityFromDate { get; set; }
        public string ValidityToDate { get; set; }
    }
}
