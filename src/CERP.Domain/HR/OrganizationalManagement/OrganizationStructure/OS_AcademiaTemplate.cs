using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_AcademiaTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_AcademiaTemplate()
        {
        }

        [CustomAudited]
        public string Code { get; set; }

        [CustomAudited]
        public string Name { get; set; }
        [CustomAudited]
        public string NameLocalized { get; set; }

        public DictionaryValue Institute { get; set; }
        [CustomAudited]
        public Guid InstituteId { get; set; }

        [CustomAudited]
        public OS_AcademicType AcademicType { get; set; }
        [CustomAudited]
        public OS_AcademiaCertificateType AcademiaCertificateType { get; set; }

        [CustomAudited]
        public DictionaryValue AcademiaCertificateSubType { get; set; }
        [CustomAudited]
        public Guid AcademiaCertificateSubTypeId { get; set; }

        [CustomAudited]
        public string Description { get; set; }
        [CustomAudited]
        public bool DoesKPI { get; set; }

        [CustomAudited]
        public int PassoutYear { get; set; }

        [CustomAudited]
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        [CustomAudited]
        public int ReviewPeriodDays { get; set; }

        public virtual OS_CompensationMatrixTemplate CompensationMatrix { get; set; }
        [CustomAudited]
        public int CompensationMatrixId { get; set; }
    }
}
