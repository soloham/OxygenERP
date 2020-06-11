using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class Disability : AuditedAggregateTenantRoot<int>
    {
        public Disability()
        {

        }

        [CustomAudited]
        public string CertificateIssuingAuthority { get; set; }
        [CustomAudited]
        public string Attachment { get; set; }
    }
}
