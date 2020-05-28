using CERP.App;
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
    public class OS_SkillTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_SkillTemplate_Dto()
        {
        }


        public string Code { get; set; }

        public string Name { get; set; }
        public string NameLocalized { get; set; }

        public string SkillAquisitionTypeDescription { get => EnumExtensions.GetDescription(SkillAquisitionType); set => SkillAquisitionType = EnumExtensions.GetValueFromDescription<OS_SkillAquisitionType>(value); }
        public OS_SkillAquisitionType SkillAquisitionType { get; set; }
        public string SkillTypeDescription { get => EnumExtensions.GetDescription(SkillType); set => SkillType = EnumExtensions.GetValueFromDescription<OS_SkillType>(value); }
        public OS_SkillType SkillType { get; set; }

        public DictionaryValue_Dto SkillSubType { get; set; }
        public Guid SkillSubTypeId { get; set; }

        public string Description { get; set; }

        public bool DoesKPI { get; set; }

        public string ReviewPeriodDescription { get => EnumExtensions.GetDescription(ReviewPeriod); set => ReviewPeriod = EnumExtensions.GetValueFromDescription<OS_ReviewPeriod>(value); }
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        public int? ReviewPeriodDays { get; set; }

        public string SkillUpdatePeriodDescription { get => EnumExtensions.GetDescription(SkillUpdatePeriod); set => SkillUpdatePeriod = EnumExtensions.GetValueFromDescription<OS_SkillUpdatePeriod>(value); }
        public OS_SkillUpdatePeriod SkillUpdatePeriod { get; set; }

        public virtual OS_CompensationMatrixTemplate_Dto CompensationMatrix { get; set; }

        public int CompensationMatrixId { get; set; }
    }
}
