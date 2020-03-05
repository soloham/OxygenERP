using CERP.FM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.App
{
    public class DictionaryValueType : AuditedAggregateRoot<Guid>
    {
        public DictionaryValueType()
        {

        }
        public DictionaryValueType(Guid guid)
        {
            Id = guid;
        }
        public ValueTypeModules ValueTypeFor { get; set; }
        public string ValueTypeCode { get; set; }
        public string ValueTypeName { get; set; }
        public string ValueTypeNameLocalizationKey { get; set; }
        public bool ActiveStatus { get; set; }
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
