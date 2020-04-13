using CERP.Base;
using CERP.FM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace CERP.App
{
    [DisableAuditing]
    public class DictionaryValueType : AuditedAggregateTenantRoot<Guid>
    {
        public DictionaryValueType()
        {

        }
        public DictionaryValueType(Guid guid)
        {
            Id = guid;
        }
        [Audited]
        public ValueTypeModules ValueTypeFor { get; set; }
        [Audited]
        public string ValueTypeCode { get; set; }
        [Audited]
        public string ValueTypeName { get; set; }
        [Audited]
        public string ValueTypeNameLocalizationKey { get; set; }
        [Audited]
        public bool ActiveStatus { get; set; }
        [Audited]
        public bool Locked { get; set; }

        //[ForeignKey("ValueTypeId")]
        public virtual ICollection<DictionaryValue> Values { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public Guid? CompanyId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public Guid? BranchId { get; set; }
    }
}
