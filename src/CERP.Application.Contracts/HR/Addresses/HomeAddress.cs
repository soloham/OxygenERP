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
        [CustomAudited]
        public Guid AddressTypeId { get; set; }

        [CustomAudited]
        public bool RegularAddress { get; set; }

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

        public DictionaryValue_Dto Country { get; set; }
        [CustomAudited]
        public Guid CountryId { get; set; }

        [CustomAudited]
        public bool IsPrimary { get; set; }
    }
}
