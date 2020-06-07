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

namespace CERP.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PayComponent : AuditedAggregateTenantRoot<int>
    {
        public PS_PayComponent()
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
        public PS_PayComponentStatus PayComponentStatus { get; set; }

        public PS_PayComponentType PayComponentType { get; set; }
        [CustomAudited]
        public int PayComponentTypeId { get; set; }

        [CustomAudited]
        public bool IsEarning { get; set; }

        public Currency Currency { get; set; }
        [CustomAudited]
        public int CurrencyId { get; set; }

        [CustomAudited]
        public double PayComponentValue { get; set; }

        public PS_PayFrequency PayFrequency { get; set; }
        [CustomAudited]
        public int PayFrequencyId { get; set; }

        [CustomAudited]
        public bool IsRecurring { get; set; }
        [CustomAudited]
        public bool IsIncomeTaxTreatment { get; set; }
        [CustomAudited]
        public bool IsGOSITreatment { get; set; }
        [CustomAudited]
        public bool IsEOSBTreatment { get; set; }
        [CustomAudited]
        public bool CanOverride { get; set; }

        [CustomAudited]
        public bool SelfServiceVisibility { get; set; }
        [CustomAudited]
        public string SelfServiceDescription { get; set; }

        [CustomAudited]
        public bool IsUsedForCompPlanning { get; set; }
        [CustomAudited]
        public bool IsRecurringPaymentAndDeduction { get; set; }
        [CustomAudited]
        public int MaxDecimalPlaces { get; set; }
        public string EffectiveDate { get; set; }
    }
}
