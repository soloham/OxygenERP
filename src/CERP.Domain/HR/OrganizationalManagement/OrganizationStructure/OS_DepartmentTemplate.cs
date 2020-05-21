using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using Volo.Abp.Auditing;

namespace CERP.HR.OrganizationalManagement.OrganizationStructure
{
    [DisableAuditing]
    public class OS_DepartmentTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_DepartmentTemplate()
        {
        }

        [CustomAudited]
        public string Name { get; set; }
        [CustomAudited]
        public string NameLocalized { get; set; }
        [CustomAudited]
        public string Code { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        [CustomAudited]
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        [CustomAudited]
        public int? ReviewPeriodDays { get; set; }

        public virtual ICollection<OS_PositionTemplate> PositionTemplates { get; set; }
        public virtual ICollection<OS_DepartmentSubDepartmentTemplate> SubDepartmentTemplates { get; set; }
        public virtual ICollection<OS_DepartmentCostCenterTemplate> DepartmentCostCenterTemplates { get; set; }

        public bool ContainsDepartment(int id)
        {
            bool result = false;
            if(SubDepartmentTemplates != null && SubDepartmentTemplates.Count > 0)
                result = SubDepartmentTemplates.Any(x => x.SubDepartmentTemplate.ContainsDepartment(id));
            return result;
        }
    }
    public class OS_DepartmentCostCenterTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_DepartmentTemplate DepartmentTemplate { get; set; }
        public int DepartmentTemplateId { get; set; }

        public DictionaryValue CostCenter { get; set; }
        public Guid CostCenterId { get; set; }

        public double Percentage { get; set; }
    }
    public class OS_DepartmentPositionTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_DepartmentTemplate DepartmentTemplate { get; set; }
        public int DepartmentTemplateId { get; set; }

        public OS_PositionTemplate PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }
    }
    public class OS_DepartmentSubDepartmentTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_DepartmentTemplate DepartmentTemplate { get; set; }
        public int DepartmentTemplateId { get; set; }

        public string Name { get; set; }
        public OS_SubDepartmentRelationshipType SubDepartmentRelationshipType { get; set; }

        public OS_DepartmentTemplate SubDepartmentTemplate { get; set; }
        public int SubDepartmentTemplateId { get; set; }
    }
}
