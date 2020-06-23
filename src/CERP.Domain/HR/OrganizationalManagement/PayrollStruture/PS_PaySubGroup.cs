using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.EmployeeCentral.Employee;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.PayrollStructure;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace CERP.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PaySubGroup : AuditedAggregateTenantRoot<int>
    {
        public PS_PaySubGroup()
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

        public virtual PS_PayGroup PayGroup { get; set; }
        [CustomAudited]
        public int? PayGroupId { get; set; }
        
        public virtual PS_PayFrequency Frequency { get; set; }
        [CustomAudited]
        public int FrequencyId { get; set; }

        public virtual Company LegalEntity { get; set; }
        [CustomAudited]
        public Guid LegalEntityId { get; set; }
        [CustomAudited]
        public int? OrganizationStructureTemplateId { get; set; }
        public virtual ICollection<PS_PaySubGroupBusinessUnit> BusinessUnits { get; set; }

        [CustomAudited]
        public bool IsCashPaymentAllowed { get; set; }
        [CustomAudited]
        public bool IsChequePaymentAllowed { get; set; }
        [CustomAudited]
        public bool IsBankPaymentAllowed { get; set; }  

        [CustomAudited]
        public bool AllowThirdPartyPayments { get; set; }

        public virtual ICollection<PS_PaySubGroupBank> AllowedBanks { get; set; }

        public virtual PS_PayrollPeriod PayrollPeriod { get; set; }
        public virtual int PayrollPeriodId { get; set; }
        //Bank Upload File
        //EOSB Selection
        //GOSI Selection

        //Policy Documents -> Link Label, Attachment / Hyperlink
    }
    public class PS_PayrollPeriod : AuditedAggregateTenantRoot<int>, IMultiTenant
    {
        [CustomAudited]
        public string Name { get; set; }

        [CustomAudited]
        public PS_PayFrequencyAnnualizationFactor PeriodFrequency { get; set; }
        [CustomAudited]
        public string PeriodStartDate { get; set; }
        [CustomAudited]
        public string PeriodEndDate { get; set; }
        [CustomAudited]
        public int ExtraPeriods { get; set; }
        public virtual ICollection<PS_PayPeriod> PayPeriods { get; set; }

        public Guid? TenantId { get; set; }
    }

    public class PS_PaySubGroupBank : AuditedEntity<int>, IMultiTenant
    {
        public int PaySubGroupId { get; set; }
        public PS_PaymentBank Bank { get; set; }
        public int BankId { get; set; }

        public bool IsThirdParty { get; set; }

        public Guid? TenantId { get; set; }
    }

    public class PS_PaySubGroupBusinessUnit : AuditedEntity<int>, IMultiTenant
    {
        public int PaySubGroupId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public int BusinessUnitId { get; set; }

        public virtual ICollection<PS_PaySubGroupBusinessUnitDivision> Divisions { get; set; }

        public Guid? TenantId { get; set; }
    }
    public class PS_PaySubGroupBusinessUnitDivision : AuditedEntity<int>, IMultiTenant
    {
        public int PaySubGroupId { get; set; }
        public int BusinessUnitId { get; set; }
        public int BusinessUnitDivisionId { get; set; }

        public virtual ICollection<PS_PaySubGroupBusinessUnitDivisionDepartment> Departments { get; set; }
        public Guid? TenantId { get; set; }
    }
    public class PS_PaySubGroupBusinessUnitDivisionDepartment : AuditedEntity<int>, IMultiTenant
    {
        public int PaySubGroupId { get; set; }
        public int BusinessUnitId { get; set; }
        public int BusinessUnitDivisionId { get; set; }
        public int BusinessUnitDivisionHeadDepartmentId { get; set; }
        public int BusinessUnitDivisionDepartmentId { get; set; }

        public Guid? TenantId { get; set; }
    }
}
