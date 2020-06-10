using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.Setup;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class BankPaymentType_Dto : AuditedEntityTenantDto<int>
    {
        public BankPaymentType_Dto()
        {

        }
        public DictionaryValue_Dto Bank { get; set; }
        public Guid BankNameId { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankIBAN { get; set; }
        public string BankAddress { get; set; }
        public string City { get; set; }
        public DictionaryValue_Dto Country { get; set; }
        public Guid CountryId { get; set; }
        public string ValidityFromDate { get; set; }
        public string ValidityToDate { get; set; }
        public bool IsPrimary { get; set; }
    }
}
