using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.EmployeeCentral.Employee;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PaymentBank : AuditedAggregateTenantRoot<int>
    {
        public PS_PaymentBank()
        {
        }

        [CustomAudited]
        public string Code { get; set; }

        [CustomAudited]
        public string Name { get; set; }
        [CustomAudited]
        public string NameLocalized { get; set; }

        [CustomAudited]
        public string AddressLine1 { get; set; }
        [CustomAudited]
        public string AddressLine2 { get; set; }
        [CustomAudited]
        public string City { get; set; }
        [CustomAudited]
        public string State { get; set; }
        [CustomAudited]
        public string PostalCode { get; set; }
        public virtual DictionaryValue Country { get; set; }
        [CustomAudited]
        public Guid CountryId { get; set; }


        [CustomAudited]
        public string AccountInitials { get; set; } 
        [CustomAudited]
        public int AccountDigits { get; set; }
        [CustomAudited]
        public bool HasAccountNumberRestriction { get; set; }

        [CustomAudited]
        public string IBANInitials { get; set; }
        [CustomAudited]
        public int IBANDigits { get; set; }
        [CustomAudited]
        public bool HasIBANNumberRestriction { get; set; }


        [CustomAudited]
        public string EffectiveFrom { get; set; }
    }
}
