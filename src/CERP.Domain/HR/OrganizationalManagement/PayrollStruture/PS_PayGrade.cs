using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.PayrollStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PayGrade : AuditedAggregateTenantRoot<int>
    {
        public PS_PayGrade()
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
        public PS_PayGradeStatus PayGradeStatus { get; set; }

        [CustomAudited] 
        public PS_PayGradeLevel PayGradeLevel { get; set; }

        public PS_PayRange PayRange { get; set; }
        [CustomAudited]
        public int PayRangeId { get; set; }
    }
}
