using CERP.FM;
using CERP.FM.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CERP.App
{
    public class DictionaryValueType_Dto : AuditedEntityDto<Guid>
    {
        public DictionaryValueType_Dto()
        {

        }
        public DictionaryValueType_Dto(Guid guid)
        {
            Id = guid;
        }
        public ValueTypeModules ValueTypeFor { get; set; }
        public string ValueTypeCode { get; set; }
        public string ValueTypeName { get; set; }
        public string ValueTypeNameLocalizationKey { get; set; }
        public bool ActiveStatus { get; set; }
        public bool Locked { get; set; }

        public virtual ICollection<DictionaryValue_Dto> Values { get; set; }

        public Company_Dto Company { get; set; }
        public Guid? CompanyId { get; set; }

        public Branch_Dto Branch { get; set; }
        public Guid? BranchId { get; set; }
    }
}
