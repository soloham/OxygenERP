using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.EmployeeCentral.DTOs.Employee;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class PrimaryValidityAttachment_Dto : AuditedEntityTenantDto<int>
    {
        public PrimaryValidityAttachment_Dto()
        {

        }

        public EmployeePrimaryValidityAttachment_Dto EmployeePrimaryValidityAttachment { get; set; }
        public int EmployeePrimaryValidityAttachmentId { get; set; }

        public string Attachment { get; set; }
        public bool IsPrimary { get; set; }
        public string ValidityFromDate { get; set; }
        public string ValidityToDate { get; set; }
    }
}
