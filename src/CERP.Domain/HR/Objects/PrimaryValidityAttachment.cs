using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.EmployeeCentral.Employee;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class PrimaryValidityAttachment : AuditedAggregateTenantRoot<int>
    {
        public PrimaryValidityAttachment()
        {

        }

        public EmployeePrimaryValidityAttachment EmployeePrimaryValidityAttachment { get; set; }
        [CustomAudited]
        public int EmployeePrimaryValidityAttachmentId { get; set; }

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
