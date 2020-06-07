using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.Setup;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class BankPaymentType : AuditedAggregateTenantRoot<int>
    {
        public BankPaymentType()
        {

        }
        public DictionaryValue Bank { get; set; }

        [CustomAudited]
        public Guid BankNameId { get; set; }

        [CustomAudited]
        public string BankAccountName { get; set; }
        [CustomAudited]
        public string BankAccountNumber { get; set; }
        [CustomAudited]
        public string BankIBAN { get; set; }
        [CustomAudited]
        public string BankAddress { get; set; }
        [CustomAudited]
        public string City { get; set; }
        public DictionaryValue Country { get; set; }
        [CustomAudited]
        public Guid CountryId { get; set; }

        [CustomAudited]
        public string ValidityFromDate { get; set; }
        [CustomAudited]
        public string ValidityToDate { get; set; }

        [CustomAudited]
        public bool IsPrimary { get; set; }
    }
}
