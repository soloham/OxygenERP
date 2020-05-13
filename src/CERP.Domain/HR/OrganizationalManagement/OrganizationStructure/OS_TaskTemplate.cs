using CERP.Attributes;
using CERP.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CERP.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_TaskTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_TaskTemplate()
        {
        }

        [CustomAudited]
        public string Code { get; set; }

        [CustomAudited]
        public string Name { get; set; }
        [CustomAudited]
        public string NameLocalized { get; set; }

        [CustomAudited]
        public DateTime ActivationDate { get; set; }
        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }
    }
}
