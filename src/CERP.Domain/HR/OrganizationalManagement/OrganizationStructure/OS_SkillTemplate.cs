using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CERP.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_SkillTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_SkillTemplate()
        {
        }

        [CustomAudited]
        public string Code { get; set; }

        [CustomAudited]
        public string Name { get; set; }
        [CustomAudited]
        public string NameLocalized { get; set; }

        [CustomAudited]
        public OS_SkillAquisitionType SkillAquisitionType { get; set; }
        [CustomAudited]
        public OS_SkillType SkillType { get; set; }
        [CustomAudited]
        public DictionaryValue SkillSubType { get; set; }
        public Guid SkillSubTypeId { get; set; }

        [CustomAudited]
        public string Description { get; set; }

        [CustomAudited]
        public bool DoesKPI { get; set; }

        [CustomAudited]
        public OS_SkillUpdatePeriod SkillUpdatePeriod { get; set; }

        public virtual OS_CompensationMatrixTemplate CompensationMatrix { get; set; }
        [CustomAudited]
        public int CompensationMatrixId { get; set; }
    }
}
