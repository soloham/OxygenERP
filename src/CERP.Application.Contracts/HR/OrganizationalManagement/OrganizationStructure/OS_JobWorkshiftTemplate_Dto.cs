using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.Workshift.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_JobWorkshiftTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_JobWorkshiftTemplate_Dto()
        {
        }

        [CustomAudited]
        public OS_JobTemplate_Dto JobTemplate { get; set; }
        [CustomAudited]
        public int JobTemplateId { get; set; }

        [CustomAudited]
        public WorkShift_Dto Workshift { get; set; }
        [CustomAudited]
        public int WorkshiftId { get; set; }
    }
}
