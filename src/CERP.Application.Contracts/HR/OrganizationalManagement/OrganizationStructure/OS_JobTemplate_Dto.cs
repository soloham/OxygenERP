using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_JobTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_JobTemplate_Dto()
        {
        }

        public string Code { get; set; }

        public string Name { get; set; }
        public string NameLocalized { get; set; }

        public string Description { get; set; }

        public DateTime ActivationDate { get; set; }
        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }

        public virtual List<OS_JobQualificationTemplate_Dto> JobQualificationTemplates { get; set; }
    }
}
