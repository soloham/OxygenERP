using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
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
        public string Description { get; set; }

        [CustomAudited]
        public bool DoesKPI { get; set; }
        [CustomAudited]
        public bool WorkflowLinkability { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        [CustomAudited]
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        [CustomAudited]
        public int ReviewPeriodDays { get; set; }

        //public virtual ICollection<OS_TaskQualificationTemplate> TaskQualificationTemplates { get; set; }

        public virtual OS_CompensationMatrixTemplate CompensationMatrix { get; set; }
        [CustomAudited]
        public int CompensationMatrixId { get; set; }

        public virtual ICollection<OS_TaskSkillTemplate> TaskSkillTemplates { get; set; }
        public virtual ICollection<OS_TaskAcademiaTemplate> TaskAcademiaTemplates { get; set; }
    }
    public class OS_TaskSkillTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_TaskTemplate TaskTemplate { get; set; }
        public int TaskTemplateId { get; set; }

        public OS_SkillTemplate SkillTemplate { get; set; }
        public int SkillTemplateId { get; set; }
    }
    public class OS_TaskAcademiaTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_TaskTemplate TaskTemplate { get; set; }
        public int TaskTemplateId { get; set; }

        public OS_AcademiaTemplate AcademiaTemplate { get; set; }
        public int AcademiaTemplateId { get; set; }
    }
}
