using CERP.Base;
using CERP.FM.COA.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CERP.FM.COA.UV_DTOs
{
    public class COA_SubLedgerRequirement_Account_UV_Dto : AuditedEntityTenantDto<Guid>
    {
        [Required]
        public Guid SubLedgerRequirementId { get; set; }
        [Required]
        public Guid AccountId { get; set; }

        public virtual COA_SubLedgerRequirement_Dto SubLedgerRequirement { get; set; }
        public virtual COA_Account_Dto Account { get; set; }
    }
}
