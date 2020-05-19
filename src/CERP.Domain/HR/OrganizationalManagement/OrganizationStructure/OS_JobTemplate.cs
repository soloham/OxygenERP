using CERP.App;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CERP.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_JobTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_JobTemplate()
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
        public int MaxJobPositions { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        public virtual OS_CompensationMatrixTemplate CompensationMatrix { get; set; }
        [CustomAudited]
        public int CompensationMatrixId { get; set; }

        [CustomAudited]
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        [CustomAudited]
        public int ReviewPeriodDays { get; set; }

        //public virtual ICollection<OS_JobQualificationTemplate> JobQualificationTemplates { get; set; }

        public virtual ICollection<OS_JobTaskTemplate> JobTaskTemplates { get; set; }
        public virtual ICollection<OS_JobFunctionTemplate> JobFunctionTemplates { get; set; }

        public virtual ICollection<OS_JobSkillTemplate> JobSkillTemplates { get; set; }
        public virtual ICollection<OS_JobAcademiaTemplate> JobAcademiaTemplates { get; set; }

        public virtual ICollection<OS_JobWorkshiftTemplate> JobWorkshiftTemplates { get; set; }
    }

    public class OS_JobTaskTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_JobTemplate JobTemplate { get; set; }
        public int JobTemplateId { get; set; }

        public OS_TaskTemplate TaskTemplate { get; set; }
        public int TaskTemplateId { get; set; }
    }
    public class OS_JobFunctionTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_JobTemplate JobTemplate { get; set; }
        public int JobTemplateId { get; set; }

        public OS_FunctionTemplate FunctionTemplate { get; set; }
        public int FunctionTemplateId { get; set; }
    }

    public class OS_JobSkillTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_JobTemplate JobTemplate { get; set; }
        public int JobTemplateId { get; set; }

        public OS_SkillTemplate SkillTemplate { get; set; }
        public int SkillTemplateId { get; set; }
    }
    public class OS_JobAcademiaTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_JobTemplate JobTemplate { get; set; }
        public int JobTemplateId { get; set; }

        public OS_AcademiaTemplate AcademiaTemplate { get; set; }
        public int AcademiaTemplateId { get; set; }
    }
}
