using CERP.Attributes;
using CERP.Base;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CERP.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_CompensationMatrixTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_CompensationMatrixTemplate()
        {
        }

        [CustomAudited]
        public string Code { get; set; }

        [CustomAudited]
        public string Name { get; set; }
        [CustomAudited]
        public string NameLocalized { get; set; }

        [CustomAudited]
        public string Description { get; set; }

        [CustomAudited]
        public string CompensationMatrixData { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        [CustomAudited]
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        [CustomAudited]
        public int ReviewPeriodDays { get; set; }

    }
}
