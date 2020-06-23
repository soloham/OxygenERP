using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;

using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using CERP.HR.Setup.OrganizationalManagement.PayrollStructure;
using CERP.App.Helpers;
using CERP.FM.DTOs;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PaySubGroup_Dto : AuditedEntityTenantDto<int>
    {
        public PS_PaySubGroup_Dto()
        {
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameLocalized { get; set; }
        public string Description { get; set; }

        public PS_PayGroup_Dto PayGroup { get; set; }
        public int? PayGroupId { get; set; }

        public PS_PayFrequency_Dto Frequency { get; set; }
        public int FrequencyId { get; set; }

        public Company_Dto LegalEntity { get; set; }
        public Guid LegalEntityId { get; set; }
        public int? OrganizationStructureTemplateId { get; set; }
        public List<PS_PaySubGroupBusinessUnit_Dto> BusinessUnits { get; set; }

        public bool IsCashPaymentAllowed { get; set; }
        public bool IsChequePaymentAllowed { get; set; }
        public bool IsBankPaymentAllowed { get; set; }

        public bool AllowThirdPartyPayments { get; set; }

        public List<PS_PaySubGroupBank_Dto> AllowedBanks { get; set; }

        public PS_PayrollPeriod_Dto PayrollPeriod { get; set; } = new PS_PayrollPeriod_Dto();
        public int PayrollPeriodId { get; set; }
    }

    public class PS_PayrollPeriod_Dto : AuditedEntityTenantDto<int>, IMultiTenant
    {
        public string Name { get; set; }

        public PS_PayFrequencyAnnualizationFactor PeriodFrequency { get; set; }
        public string PeriodStartDate { get; set; }
        public string PeriodEndDate { get; set; }
        public int ExtraPeriods { get; set; }
        public virtual List<PS_PayPeriod_Dto> PayPeriods { get; set; } = new List<PS_PayPeriod_Dto>();

        public Guid? TenantId { get; set; }
    }
    public class PS_PaySubGroupBank_Dto : AuditedEntity<int>, IMultiTenant
    {
        public int PaySubGroupId { get; set; }
        public PS_PaymentBank_Dto Bank { get; set; }
        public int BankId { get; set; }

        public bool IsThirdParty { get; set; }

        public Guid? TenantId { get; set; }
    }

    public class PS_PaySubGroupBusinessUnit_Dto : AuditedEntity<int>, IMultiTenant
    {
        public int PaySubGroupId { get; set; }
        public int BusinessUnitId { get; set; }

        public List<PS_PaySubGroupBusinessUnitDivision_Dto> Divisions { get; set; }

        public Guid? TenantId { get; set; }
    }
    public class PS_PaySubGroupBusinessUnitDivision_Dto : AuditedEntity<int>, IMultiTenant
    {
        public int PaySubGroupId { get; set; }
        public int BusinessUnitId { get; set; }
        public int BusinessUnitDivisionId { get; set; }

        public List<PS_PaySubGroupBusinessUnitDivisionDepartment_Dto> Departments { get; set; }
        public Guid? TenantId { get; set; }
    }
    public class PS_PaySubGroupBusinessUnitDivisionDepartment_Dto : AuditedEntity<int>, IMultiTenant
    {
        public int PaySubGroupId { get; set; }
        public int BusinessUnitId { get; set; }
        public int BusinessUnitDivisionId { get; set; }
        public int BusinessUnitDivisionHeadDepartmentId { get; set; }
        public int BusinessUnitDivisionDepartmentId { get; set; }

        public Guid? TenantId { get; set; }
    }
}
