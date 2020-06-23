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

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PaymentBank_Dto : AuditedEntityTenantDto<int>
    {
        public PS_PaymentBank_Dto()
        {
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameLocalized { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public virtual DictionaryValue_Dto Country { get; set; }
        public Guid CountryId { get; set; }
        public string AccountInitials { get; set; }
        public int AccountDigits { get; set; }
        public bool HasAccountNumberRestriction { get; set; }
        public string IBANInitials { get; set; }
        public int IBANDigits { get; set; }
        public bool HasIBANNumberRestriction { get; set; }
        public string EffectiveFrom { get; set; }
    }
}
