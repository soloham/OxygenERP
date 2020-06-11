using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.Employee.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class PassportTravelDocument : AuditedAggregateTenantRoot<int>
    {
        public PassportTravelDocument()
        {

        }

        public IdentityDocumentType DocumentType { get; set; }
        public DictionaryValue IssuingCountry { get; set; }
        [CustomAudited]
        public Guid IssuingCountryId { get; set; }

        [CustomAudited]
        public string DocumentNumber { get; set; }
        [CustomAudited]
        public string Attachment { get; set; }

        [CustomAudited]
        public bool IsPrimary { get; set; }

        [CustomAudited]
        public string ValidityFromDate { get; set; }
        [CustomAudited]
        public string ValidityToDate { get; set; }
    }
}
