using CERP.App;
using CERP.App.Helpers;
using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_PositionTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_PositionTemplate_Dto()
        {
        }

        public string Code { get; set; }

        public string Name { get; set; }
        public string NameLocalized { get; set; }

        public string LevelDescription { get => EnumExtensions.GetDescription(Level); set => Level = EnumExtensions.GetValueFromDescription<OS_PositionLevel>(value); }
        public OS_PositionLevel Level { get; set; }

        public int MaxPositionsPerDepartment { get; set; }

        public string HiringTypeDescription { get => EnumExtensions.GetDescription(HiringType); set => HiringType = EnumExtensions.GetValueFromDescription<OS_PositionHiringType>(value); }
        public OS_PositionHiringType HiringType { get; set; }
        public int? ReviewPeriodDays { get; set; }

        public DictionaryValue_Dto CostCenter { get; set; }
        public Guid CostCenterId { get; set; }

        public DateTime ActivationDate { get; set; }
        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }

        public string ReviewPeriodDescription { get => EnumExtensions.GetDescription(ReviewPeriod); set => ReviewPeriod = EnumExtensions.GetValueFromDescription<OS_ReviewPeriod>(value); }
        public OS_ReviewPeriod ReviewPeriod { get; set; }

        public OS_DepartmentTemplate_Dto DepartmentTemplate { get; set; }
        public int DepartmentTemplateId { get; set; }

        public List<OS_PositionJobTemplate_Dto> PositionJobTemplates { get; set; } = new List<OS_PositionJobTemplate_Dto>();
        public List<OS_PositionTaskTemplate_Dto> PositionTaskTemplates { get; set; } = new List<OS_PositionTaskTemplate_Dto>();
    }

    public class OS_PositionJobTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_PositionTemplate_Dto PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        public OS_JobTemplate_Dto JobTemplate { get; set; }
        public int JobTemplateId { get; set; }
    }
    public class OS_PositionTaskTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_PositionTemplate_Dto PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        public OS_TaskTemplate_Dto TaskTemplate { get; set; }
        public int TaskTemplateId { get; set; }
    }
}
