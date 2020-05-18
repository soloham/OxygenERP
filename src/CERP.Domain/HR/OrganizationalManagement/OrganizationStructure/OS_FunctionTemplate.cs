using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.Attributes;
using CERP.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CERP.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_FunctionTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_FunctionTemplate()
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
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        public virtual OS_CompensationMatrixTemplate CompensationMatrix { get; set; }
        [CustomAudited]
        public int CompensationMatrixId { get; set; }

        public virtual ICollection<OS_FunctionSkillTemplate> FunctionSkillTemplates { get; set; }
        public virtual ICollection<OS_FunctionAcademiaTemplate> FunctionAcademiaTemplates { get; set; }
    }
    public class OS_FunctionSkillTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_FunctionTemplate FunctionTemplate { get; set; }
        public int FunctionTemplateId { get; set; }

        public OS_SkillTemplate SkillTemplate { get; set; }
        public int SkillTemplateId { get; set; }
    }
    public class OS_FunctionAcademiaTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_FunctionTemplate FunctionTemplate { get; set; }
        public int FunctionTemplateId { get; set; }

        public OS_AcademiaTemplate AcademiaTemplate { get; set; }
        public int AcademiaTemplateId { get; set; }
    }
}
