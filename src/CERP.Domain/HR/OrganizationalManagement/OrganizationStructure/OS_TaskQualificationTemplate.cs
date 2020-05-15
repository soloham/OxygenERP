using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CERP.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_TaskQualificationTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_TaskQualificationTemplate()
        {
        }

        [CustomAudited]
        public OS_TaskTemplate TaskTemplate { get; set; }
        [CustomAudited]
        public int TaskTemplateId { get; set; }

        [CustomAudited]
        public DictionaryValue Degree { get; set; }
        [CustomAudited]
        public Guid DegreeId { get; set; }

        [CustomAudited]
        public DictionaryValue Institute { get; set; }
        [CustomAudited]
        public Guid InstituteId { get; set; }

        [CustomAudited]
        public DateTime PeriodStartDate { get; set; }
        [CustomAudited]
        public DateTime PeriodEndDate { get; set; }
    }
}
