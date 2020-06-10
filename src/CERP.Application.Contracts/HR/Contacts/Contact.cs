using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class Contact_Dto : AuditedEntityTenantDto<int>
    {
        public Contact_Dto()
        {

        }

        public DictionaryValue_Dto RelationshipType { get; set; }
        public Guid RelationshipTypeId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string AlternatePhone { get; set; }
        public bool IsEmergencyContact { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public DictionaryValue_Dto Country { get; set; }
        public Guid CountryId { get; set; }
        public bool IsPrimary { get; set; }
    }
}
