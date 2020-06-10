using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class HomeAddress_Dto : AuditedEntityTenantDto<int>
    {
        public HomeAddress_Dto()
        {

        }

        public DictionaryValue_Dto AddressType { get; set; }
        public Guid AddressTypeId { get; set; }
        public bool RegularAddress { get; set; }
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
