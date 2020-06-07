using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;

using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.PayrollStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PayFrequency_Dto : AuditedEntityTenantDto<int>
    {
        public PS_PayFrequency_Dto()
        {
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameLocalized { get; set; }
        public string Description { get; set; }
        public int AnnualizationFactor { get; set; }
    }
}
