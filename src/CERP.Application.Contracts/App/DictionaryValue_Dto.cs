using CERP.Base;
using CERP.FM;
using CERP.FM.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CERP.App
{
    public class DictionaryValue_Dto : AuditedEntityTenantDto<Guid>
    {
        public DictionaryValue_Dto()
        {

        }
        public DictionaryValue_Dto(Guid guid)
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

        public DictionaryValueType_Dto ValueType { get; set; }
        public Guid? ValueTypeId { get; set; }

        public Company_Dto Company { get; set; }
        public Guid? CompanyId { get; set; }

        public Branch_Dto Branch { get; set; }
        public Guid? BranchId { get; set; }
    }
}
