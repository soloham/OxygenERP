using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections;
using System.Collections.Generic;
using Volo.Abp.Auditing;

namespace CERP.HR.OrganizationalManagement.OrganizationStructure
{
    [DisableAuditing]
    public class OS_PositionTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_PositionTemplate()
        {
        }

        [CustomAudited]
        public string Code { get; set; }

        [CustomAudited]
        public string Name { get; set; }

        [CustomAudited]
        public string NameLocalized { get; set; }

        [CustomAudited]
        public OS_PositionLevel Level { get; set; }

        [CustomAudited]
        public int MaxPositionsPerDepartment { get; set; }

        [CustomAudited]
        public DictionaryValue CostCenter { get; set; }
        [CustomAudited]
        public Guid CostCenterId { get; set; }

        [CustomAudited]
        public DateTime ActivationDate { get; set; }
        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        [CustomAudited]
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        [CustomAudited]
        public int? ReviewPeriodDays { get; set; }

        [CustomAudited]
        public OS_PositionHiringType HiringType { get; set; }

        [CustomAudited]
        public OS_DepartmentTemplate DepartmentTemplate { get; set; }
        [CustomAudited]
        public int DepartmentTemplateId { get; set; }

        public virtual ICollection<OS_PositionJobTemplate> PositionJobTemplates { get; set; }
        public virtual ICollection<OS_PositionTaskTemplate> PositionTaskTemplates { get; set; }
    }
    public class OS_PositionJobTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_PositionTemplate PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }
        
        public OS_JobTemplate JobTemplate { get; set; }
        public int JobTemplateId { get; set; }
    }
    public class OS_PositionTaskTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_PositionTemplate PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }
        
        public OS_TaskTemplate TaskTemplate { get; set; }
        public int TaskTemplateId { get; set; }
    }
}
