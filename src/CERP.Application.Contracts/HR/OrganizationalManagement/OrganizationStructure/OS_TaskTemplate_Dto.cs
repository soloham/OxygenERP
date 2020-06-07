using CERP.App.Helpers;
using CERP.Base;
using CERP.FM;

using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_TaskTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_TaskTemplate_Dto()
        {
        }

        public string Code { get; set; }

        public string Name { get; set; }
        public string NameLocalized { get; set; }

        public string Description { get; set; }
        public bool DoesKPI { get; set; }
        public bool WorkflowLinkability { get; set; }

        public string ReviewPeriodDescription { get => EnumExtensions.GetDescription(ReviewPeriod); set => ReviewPeriod = EnumExtensions.GetValueFromDescription<OS_ReviewPeriod>(value); }
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        public int? ReviewPeriodDays { get; set; }

        //public virtual List<OS_TaskQualificationTemplate_Dto> TaskQualificationTemplates { get; set; }

        public virtual OS_CompensationMatrixTemplate_Dto CompensationMatrix { get; set; }
        public int CompensationMatrixId { get; set; }

        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }

        public virtual List<OS_TaskSkillTemplate_Dto> TaskSkillTemplates { get; set; }
        public virtual List<OS_TaskAcademiaTemplate_Dto> TaskAcademiaTemplates { get; set; }
    }
    public class OS_TaskSkillTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_TaskTemplate_Dto TaskTemplate { get; set; }
        public int TaskTemplateId { get; set; }

        public OS_SkillTemplate_Dto SkillTemplate { get; set; }
        public int SkillTemplateId { get; set; }
    }
    public class OS_TaskAcademiaTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_TaskTemplate_Dto TaskTemplate { get; set; }
        public int TaskTemplateId { get; set; }

        public OS_AcademiaTemplate_Dto AcademiaTemplate { get; set; }
        public int AcademiaTemplateId { get; set; }
    }
}
