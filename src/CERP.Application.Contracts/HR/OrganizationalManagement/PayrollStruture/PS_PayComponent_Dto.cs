using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.PayrollStructure;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using CERP.Setup.DTOs;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PayComponent_Dto : AuditedEntityTenantDto<int>
    {
        public PS_PayComponent_Dto()
        {
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameLocalized { get; set; }
        public string Description { get; set; }
        public PS_PayComponentStatus PayGradeStatus { get; set; }

        public PS_PayComponentType_Dto PayComponentType { get; set; }
        public int PayComponentTypeId { get; set; }
        public bool IsEarning { get; set; }

        public Currency_Dto Currency { get; set; }
        public int CurrencyId { get; set; }
        public double PayComponentValue { get; set; }

        public PS_PayFrequency_Dto PayFrequency { get; set; }
        public int PayFrequencyId { get; set; }
        public bool IsRecurring { get; set; }
        public bool IsIncomeTaxTreatment { get; set; }
        public bool IsGOSITreatment { get; set; }
        public bool IsEOSBTreatment { get; set; }
        public bool CanOverride { get; set; }
        public bool SelfServiceVisibility { get; set; }
        public string SelfServiceDescription { get; set; }
        public bool IsUsedForCompPlanning { get; set; }
        public bool IsRecurringPaymentAndDeduction { get; set; }
        public int MaxDecimalPlaces { get; set; }
    }
}
