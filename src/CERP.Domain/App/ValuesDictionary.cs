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
    public class DictionaryValue : AuditedAggregateTenantRoot<Guid>
    {
        public void SetId(Guid id)
        {
            Id = id;
        }
        public DictionaryValue()
        {

        }
        public DictionaryValue(Guid guid)
        {
            Id = guid;
        }
        [Audited]
        public string Key { get; set; }
        [Audited]
        public string Value { get; set; }
        [Audited]
        public string ValueLocalizationKey { get; set; }
        [Audited]
        public string Abbreviation { get; set; }
        [Audited]
        public string Dimension_1_Key { get; set; }
        [Audited]
        public string Dimension_1_Value { get; set; }
        [Audited]
        public string Dimension_2_Key { get; set; }
        [Audited]
        public string Dimension_2_Value { get; set; }
        [Audited]
        public string Dimension_3_Key { get; set; }
        [Audited]
        public string Dimension_3_Value { get; set; }
        [Audited]
        public string Dimension_4_Key { get; set; }
        [Audited]
        public string Dimension_4_Value { get; set; }
        [Audited]
        public bool? ActiveStatus { get; set; }
        [ForeignKey("ValueTypeId")]
        public DictionaryValueType ValueType { get; set; }  
        [Audited]
        public Guid? ValueTypeId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public Guid? CompanyId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public Guid? BranchId { get; set; }
    }
}
