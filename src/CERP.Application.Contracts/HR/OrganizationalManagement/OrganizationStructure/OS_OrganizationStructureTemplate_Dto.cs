using CERP.Attributes;
using CERP.Base;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CERP.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_OrganizationStructureTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_OrganizationStructureTemplate_Dto()
        {
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string NameLocalized { get; set; }
        public string Description { get; set; }
        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }
        public OS_StructureStatus StructureStatus { get; set; }
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        public int? ReviewPeriodDays { get; set; }
    }
}
