using CERP.App;
using CERP.App.Helpers;
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

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_AcademiaTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_AcademiaTemplate_Dto()
        {
        }

        public string Code { get; set; }

        public string Name { get; set; }
        public string NameLocalized { get; set; }

        public DictionaryValue_Dto Institute { get; set; }
        public Guid InstituteId { get; set; }

        public string AcademicTypeDescription { get => EnumExtensions.GetDescription(AcademicType); set { try { AcademicType = EnumExtensions.GetValueFromDescription<OS_AcademicType>(value); } catch { } } }
        public OS_AcademicType AcademicType { get; set; }
        public string AcademiaCertificateTypeDescription { get => EnumExtensions.GetDescription(AcademiaCertificateType); set { try { AcademiaCertificateType = EnumExtensions.GetValueFromDescription<OS_AcademiaCertificateType>(value); } catch { } } }
        public OS_AcademiaCertificateType AcademiaCertificateType { get; set; }

        public DictionaryValue_Dto AcademiaCertificateSubType { get; set; }
        public Guid AcademiaCertificateSubTypeId { get; set; }

        public string Description { get; set; }
        public bool DoesKPI { get; set; }

        public int PassoutYear { get; set; }

        public string ReviewPeriodDescription { get => EnumExtensions.GetDescription(ReviewPeriod); set => ReviewPeriod = EnumExtensions.GetValueFromDescription<OS_ReviewPeriod>(value); }
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        public int ReviewPeriodDays { get; set; }

        public virtual OS_CompensationMatrixTemplate_Dto CompensationMatrix { get; set; }
        public int CompensationMatrixId { get; set; }
    }
}
