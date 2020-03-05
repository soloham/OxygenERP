using CERP.FM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.App
{
    public class DictionaryValue : AuditedAggregateRoot<Guid>
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
        public string Key { get; set; }
        public string Value { get; set; }
        public string ValueLocalizationKey { get; set; }
        public string Abbreviation { get; set; }
        public string Dimension_1_Key { get; set; }
        public string Dimension_1_Value { get; set; }
        public string Dimension_2_Key { get; set; }
        public string Dimension_2_Value { get; set; }
        public string Dimension_3_Key { get; set; }
        public string Dimension_3_Value { get; set; }
        public string Dimension_4_Key { get; set; }
        public string Dimension_4_Value { get; set; }
        public bool? ActiveStatus { get; set; }

        [ForeignKey("ValueTypeId")]
        public DictionaryValueType ValueType { get; set; }  
        public Guid? ValueTypeId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public Guid? CompanyId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public Guid? BranchId { get; set; }
    }
}
