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
    public class PS_PaySubGroup_Search_Dto : AuditedEntityTenantDto<int>
    {
        public PS_PaySubGroup_Search_Dto()
        {
        }

        public DateTime SearchAsOf { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string NameLocalized { get; set; }
        public string Description { get; set; }

        public PS_PayGroup_Dto[] PayGroupId { get; set; }

        public PS_PayFrequency_Dto[] FrequencyId { get; set; }

        public Company_Dto[] LegalEntityId { get; set; }

        public bool IsCashPaymentAllowed { get; set; }
        public bool IsChequePaymentAllowed { get; set; }
        public bool IsBankPaymentAllowed { get; set; }

        public bool AllowThirdPartyPayments { get; set; }

        public List<PS_PaySubGroupBank_Dto> AllowedBanks { get; set; }

        public string PeriodName { get; set; }
        public PS_PayFrequencyAnnualizationFactor[] PeriodFrequency { get; set; }
        public string PeriodStartDate { get; set; }
        public string PeriodEndDate { get; set; }
        public int ExtraPeriods { get; set; }
        public virtual List<PS_PayPeriod_Dto> PayPeriods { get; set; }
    }
    public class PS_PayrollPeriod_Search_Dto : AuditedEntity<int>, IMultiTenant
    {
        public string Name { get; set; }

        public PS_PayFrequencyAnnualizationFactor PeriodFrequency { get; set; }
        public string PeriodStartDate { get; set; }
        public string PeriodEndDate { get; set; }
        public int ExtraPeriods { get; set; }
        public virtual List<PS_PayPeriod_Dto> PayPeriods { get; set; }

        public Guid? TenantId => throw new NotImplementedException();
    }
}
