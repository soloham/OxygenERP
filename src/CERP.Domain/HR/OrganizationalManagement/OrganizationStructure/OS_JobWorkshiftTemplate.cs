using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.Workshifts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CERP.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_JobWorkshiftTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_JobWorkshiftTemplate()
        {
        }

        [CustomAudited]
        public OS_JobTemplate JobTemplate { get; set; }
        [CustomAudited]
        public int JobTemplateId { get; set; }

        [CustomAudited]
        public WorkShift Workshift { get; set; }
        [CustomAudited]
        public int WorkshiftId { get; set; }
    }
}
