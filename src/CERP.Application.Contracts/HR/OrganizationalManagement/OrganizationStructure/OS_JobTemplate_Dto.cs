using CERP.App.Helpers;
using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
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
        public int MaxJobPositions { get; set; }

        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }

        public string ReviewPeriodDescription { get => EnumExtensions.GetDescription(ReviewPeriod); set => ReviewPeriod = EnumExtensions.GetValueFromDescription<OS_ReviewPeriod>(value); }
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        public int? ReviewPeriodDays { get; set; }

        public virtual OS_CompensationMatrixTemplate_Dto CompensationMatrix { get; set; }
        public int CompensationMatrixId { get; set; }

        //public virtual List<OS_JobQualificationTemplate_Dto> JobQualificationTemplates { get; set; }

        public virtual List<OS_JobTaskTemplate_Dto> JobTaskTemplates { get; set; }
        public virtual List<OS_JobFunctionTemplate_Dto> JobFunctionTemplates { get; set; }

        public virtual List<OS_JobSkillTemplate_Dto> JobSkillTemplates { get; set; }
        public virtual List<OS_JobAcademiaTemplate_Dto> JobAcademiaTemplates { get; set; }

        public virtual List<OS_JobWorkshiftTemplate_Dto> JobWorkshiftTemplates { get; set; }
    }
    public class OS_JobTaskTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_JobTemplate_Dto JobTemplate { get; set; }
        public int JobTemplateId { get; set; }

        public OS_TaskTemplate_Dto TaskTemplate { get; set; }
        public int TaskTemplateId { get; set; }
    }
    public class OS_JobFunctionTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_JobTemplate_Dto JobTemplate { get; set; }
        public int JobTemplateId { get; set; }

        public OS_FunctionTemplate_Dto FunctionTemplate { get; set; }
        public int FunctionTemplateId { get; set; }
    }
    public class OS_JobSkillTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_JobTemplate_Dto JobTemplate { get; set; }
        public int JobTemplateId { get; set; }

        public OS_SkillTemplate_Dto SkillTemplate { get; set; }
        public int SkillTemplateId { get; set; }
    }
    public class OS_JobAcademiaTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_JobTemplate_Dto JobTemplate { get; set; }
        public int JobTemplateId { get; set; }

        public OS_AcademiaTemplate_Dto AcademiaTemplate { get; set; }
        public int AcademiaTemplateId { get; set; }
    }
}