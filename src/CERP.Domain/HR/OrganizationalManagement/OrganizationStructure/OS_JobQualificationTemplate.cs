using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CERP.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_JobQualificationTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_JobQualificationTemplate()
        {
        }

        [CustomAudited]
        public OS_JobTemplate JobTemplate { get; set; }
        [CustomAudited]
        public int JobTemplateId { get; set; }

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
