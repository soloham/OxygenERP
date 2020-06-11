using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.EmployeeCentral.DTOs.Attributes
{
    public class Disability_Dto : AuditedEntityTenantDto<int>
    {
        public Disability_Dto()
        {

        }

        public string CertificateIssuingAuthority { get; set; }
        public string Attachment { get; set; }
    }
}
