using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class HomeAddress : AuditedAggregateTenantRoot<int>
    {
        public HomeAddress()
        {

        }

        public DictionaryValue AddressType { get; set; }
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

        public DictionaryValue Country { get; set; }
        [CustomAudited]
        public Guid CountryId { get; set; }

        [CustomAudited]
        public bool IsPrimary { get; set; }
    }
}
